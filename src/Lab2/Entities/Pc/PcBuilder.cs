using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupplies;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiAdapters;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcBuilder;

public class PcBuilder : IPcBuilder
{
    private Cpu _cpu = new Cpu();
    private CpuCooler _cpuCooler = new CpuCooler();
    private Frame _frame = new Frame();
    private Gpu _gpu = new Gpu();
    private Motherboard _motherboard = new Motherboard();
    private PowerSupply _powerSupply = new PowerSupply();
    private List<Ram> _ram = new List<Ram>();
    private List<Storage> _storages = new List<Storage>();
    private WifiAdapter _wifiAdapter = new WifiAdapter();

    public IReadOnlyCollection<Ram>? Rams => _ram;

    public IPcBuilder SetCpu(Cpu cpu)
    {
        ArgumentNullException.ThrowIfNull(cpu);
        ArgumentNullException.ThrowIfNull(_motherboard);
        ArgumentNullException.ThrowIfNull(_motherboard.Bios);

        if (_motherboard is null)
            throw PcBuilderException.MotherboardIsNotInstalledYetException();

        if (!_motherboard.Bios.SupportedCpus.Any(x => x == cpu.Name))
            throw PcBuilderException.CpuIsNotSupported();

        if (cpu.Socket != _motherboard.Socket)
            throw PcBuilderException.CpuAndMotherboardSocketAreIncompatibleException(cpu.Socket?.SocketName, _motherboard.Socket?.SocketName);

        _cpu = cpu;
        return this;
    }

    public IPcBuilder SetCpuCooler(CpuCooler cpuCooler)
    {
        ArgumentNullException.ThrowIfNull(cpuCooler);
        ArgumentNullException.ThrowIfNull(_motherboard);
        ArgumentNullException.ThrowIfNull(_frame);

        if (cpuCooler.Height.Centimetre > _frame.Depth.Centimetre)
            throw PcBuilderException.InvalidMetrics();

        if (_cpu is null)
            throw PcBuilderException.CpuIsNotInstalledYetException();

        if (cpuCooler.SupportedSockets.All(x => x.SocketName != _motherboard.Socket.SocketName))
            throw PcBuilderException.CpuCoolerSocketAndMotherboardSocketAreIncompatibleException(_motherboard.Socket.SocketName);

        if (cpuCooler.MaxDissipatedTdp.WattValue < _cpu.Tdp.WattValue)
            throw PcBuilderException.NotEnoughCoolerDissipatedTdp();

        _cpuCooler = cpuCooler;
        return this;
    }

    public IPcBuilder SetFrame(Frame frame)
    {
        ArgumentNullException.ThrowIfNull(frame);

        _frame = frame;
        return this;
    }

    public IPcBuilder SetGpu(Gpu gpu)
    {
        ArgumentNullException.ThrowIfNull(gpu);
        ArgumentNullException.ThrowIfNull(_powerSupply);
        ArgumentNullException.ThrowIfNull(_frame);

        if (gpu.Height.Centimetre > _frame.Depth.Centimetre)
            throw PcBuilderException.InvalidMetrics();

        if (_motherboard is null)
            throw PcBuilderException.MotherboardIsNotInstalledYetException();

        if (gpu.PowerConsumption.WattValue >= _powerSupply.MaxPower.WattValue)
            throw PcBuilderException.NotEnoughPowerSupplyMaxPowerException(_powerSupply.MaxPower.WattValue, gpu.PowerConsumption.WattValue);

        _gpu = gpu;
        return this;
    }

    public IPcBuilder SetMotherboard(Motherboard motherboard)
    {
        ArgumentNullException.ThrowIfNull(motherboard);

        if (_frame is null)
            throw PcBuilderException.NoFrameException();

        if (_frame.Formats.All(x => x.Name != motherboard.FormFactor.Name))
            throw PcBuilderException.InvalidMotherboardFormFactorException(motherboard.FormFactor.Name);

        _motherboard = motherboard;
        return this;
    }

    public IPcBuilder SetPowerSupply(PowerSupply powerSupply)
    {
        ArgumentNullException.ThrowIfNull(powerSupply);

        if (_frame is null)
            throw PcBuilderException.NoFrameException();

        _powerSupply = powerSupply;
        return this;
    }

    public IPcBuilder SetRam(ICollection<Ram> rams)
    {
        ArgumentNullException.ThrowIfNull(rams);

        if (_motherboard is null)
            throw PcBuilderException.MotherboardIsNotInstalledYetException();

        if (rams.Count > _motherboard.MemPortAmount)
            throw PcBuilderException.TooMuchRamException();

        _ram = rams.ToList();
        return this;
    }

    public IPcBuilder SetSsd(Ssd ssd)
    {
        ArgumentNullException.ThrowIfNull(ssd);

        if (_motherboard is null)
            throw PcBuilderException.MotherboardIsNotInstalledYetException();

        _storages.Add(ssd);
        return this;
    }

    public IPcBuilder SetHdd(Hdd hdd)
    {
        ArgumentNullException.ThrowIfNull(hdd);

        if (_motherboard is null)
            throw PcBuilderException.MotherboardIsNotInstalledYetException();

        _storages.Add(hdd);
        return this;
    }

    public IPcBuilder SetWifiAdapter(WifiAdapter wifiAdapter)
    {
        ArgumentNullException.ThrowIfNull(wifiAdapter);

        if (_motherboard is null)
            throw PcBuilderException.MotherboardIsNotInstalledYetException();

        if (_motherboard.PcieAmount < 2)
            throw PcBuilderException.NotEnoughFreePciePorts();

        _wifiAdapter = wifiAdapter;
        return this;
    }

    public int GetNeededEnergy()
    {
        int storagesPowerConsumption = _storages.Sum(storage => storage.PowerConsumption.WattValue);
        int ramsPowerConsumption = _ram.Sum(ram => ram.PowerConsumption.WattValue);

        return _cpu.PowerConsumption.WattValue + _gpu.PowerConsumption.WattValue + storagesPowerConsumption + ramsPowerConsumption;
    }

    public Pc Build()
    {
        int neededEnergy = GetNeededEnergy();
        if (neededEnergy > _powerSupply.MaxPower.WattValue)
            throw PcBuilderException.NotEnoughPowerSupplyMaxPowerException(_powerSupply.MaxPower.WattValue, neededEnergy);

        return new Pc(_cpu, _cpuCooler, _frame, _gpu, _motherboard, _powerSupply, _ram, _storages, _wifiAdapter);
    }
}