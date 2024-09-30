using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

public class CpuBuilder : ICpuBuilder
{
    private CpuValidator _cpuValidator = new CpuValidator();
    private string _name = string.Empty;
    private int _coreQuantity;
    private Hz _coreFrequency = new Hz();
    private Socket _socket = new Socket();
    private bool _isIntegratedGraphics;
    private List<Hz> _supportedFrequencies = new List<Hz>();
    private Watt _tdp = new Watt();
    private Watt _powerConsumption = new Watt();

    public ICpuBuilder SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw CpuException.InvalidCpuNameException();

        _name = name;
        return this;
    }

    public ICpuBuilder SetCoreQuantity(int coreQuantity)
    {
        if (coreQuantity < 1)
            throw CpuException.InvalidCoreQuantityException(coreQuantity);

        _coreQuantity = coreQuantity;
        return this;
    }

    public ICpuBuilder SetCoreFrequency(Hz coreFrequency)
    {
        ArgumentNullException.ThrowIfNull(coreFrequency);
        if (coreFrequency.Herz < 1)
            throw CpuException.InvalidCoreFrequencyException(coreFrequency.Herz);

        _coreFrequency = coreFrequency;
        return this;
    }

    public ICpuBuilder SetSocket(Socket socket)
    {
        ArgumentNullException.ThrowIfNull(socket);

        _socket = socket;
        return this;
    }

    public ICpuBuilder SetIntegratedGraphics(bool isIntegratedGraphics)
    {
        _isIntegratedGraphics = isIntegratedGraphics;
        return this;
    }

    public ICpuBuilder SetSupportedFrequencies(ICollection<Hz> supportedFrequencies)
    {
        ArgumentNullException.ThrowIfNull(supportedFrequencies);

        _supportedFrequencies.AddRange(supportedFrequencies);
        return this;
    }

    public ICpuBuilder SetTdp(Watt tdp)
    {
        ArgumentNullException.ThrowIfNull(tdp);
        if (tdp.WattValue < 1)
            throw CpuException.InvalidTdpException(tdp.WattValue);

        _tdp = tdp;
        return this;
    }

    public ICpuBuilder SetPowerConsumption(Watt powerConsumption)
    {
        ArgumentNullException.ThrowIfNull(powerConsumption);
        if (powerConsumption.WattValue < 1)
            throw CpuException.InvalidPowerConsumptionException(powerConsumption.WattValue);

        _powerConsumption = powerConsumption;
        return this;
    }

    public ICpuBuilder ImportCpu(Cpu cpu)
    {
        _cpuValidator.CheckImportValid(cpu);

        _name = cpu.Name;
        _name = cpu.Name;
        _socket = cpu.Socket;
        _powerConsumption = cpu.PowerConsumption;
        _coreFrequency = cpu.CoreFrequency;
        _tdp = cpu.Tdp;
        _coreQuantity = cpu.CoreQuantity;

        if (_supportedFrequencies.Count > 0)
            throw CpuException.InvalidFrequencyDataException();

        _supportedFrequencies.AddRange(cpu.SupportedFrequencies);
        _isIntegratedGraphics = cpu.IsIntegratedGraphics;

        return this;
    }

    public Cpu Build()
    {
        if (string.IsNullOrEmpty(_name) || _coreQuantity == 0 || _coreFrequency.Herz == 0 || string.IsNullOrEmpty(_socket.SocketName) || _isIntegratedGraphics || _supportedFrequencies.Count == 0 || _tdp.WattValue == 0 || _powerConsumption.WattValue == 0)
            throw CpuException.NotAllAttributesAreSetException();

        return new Cpu(_name, _coreQuantity, _coreFrequency, _isIntegratedGraphics, _socket, _supportedFrequencies, _tdp, _powerConsumption);
    }
}