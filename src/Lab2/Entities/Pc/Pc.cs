using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupplies;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiAdapters;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;

public class Pc
{
    private Cpu _cpu;
    private CpuCooler _cpuCooler;
    private Frame _frame;
    private Gpu _gpu;
    private Motherboard _motherboard;
    private PowerSupply _powerSupply;
    private List<Ram> _rams;
    private List<Storage> _storages;
    private WifiAdapter _wifiAdapter;

    public Pc(Cpu cpu, CpuCooler cpuCooler, Frame frame, Gpu gpu, Motherboard motherboard, PowerSupply powerSupply, IReadOnlyCollection<Ram> rams, IReadOnlyCollection<Storage> storages, WifiAdapter wifiAdapter)
    {
        ArgumentNullException.ThrowIfNull(cpuCooler);
        ArgumentNullException.ThrowIfNull(cpu);
        ArgumentNullException.ThrowIfNull(frame);
        ArgumentNullException.ThrowIfNull(gpu);
        ArgumentNullException.ThrowIfNull(motherboard);
        ArgumentNullException.ThrowIfNull(powerSupply);
        ArgumentNullException.ThrowIfNull(rams);
        ArgumentNullException.ThrowIfNull(storages);
        ArgumentNullException.ThrowIfNull(wifiAdapter);

        _cpuCooler = cpuCooler;
        _cpu = cpu;
        _frame = frame;
        _gpu = gpu;
        _motherboard = motherboard;
        _powerSupply = powerSupply;
        _rams = (List<Ram>)rams;
        _storages = (List<Storage>)storages;
        _wifiAdapter = wifiAdapter;
    }

    public Cpu Cpu => _cpu;
    public CpuCooler CpuCooler => _cpuCooler;
    public Frame Frame => _frame;
    public Gpu Gpu => _gpu;
    public Motherboard Motherboard => _motherboard;
    public PowerSupply PowerSupply => _powerSupply;
    public IReadOnlyCollection<Ram> Rams => _rams;
    public IReadOnlyCollection<Storage> Storages => _storages;
    public WifiAdapter WifiAdapter => _wifiAdapter;
}