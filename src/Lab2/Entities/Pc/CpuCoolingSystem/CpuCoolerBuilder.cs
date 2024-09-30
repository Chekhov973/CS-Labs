using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCoolingSystem;

public class CpuCoolerBuilder : ICpuCoolerBuilder
{
    private ICpuCoolerValidator _cpuCoolerValidator = new CpuCoolerValidator();
    private Cm _height = new Cm();
    private List<Socket> _supportedSockets = new List<Socket>();
    private Watt _maxDissipatedTdp = new Watt();
    private string _name = string.Empty;

    public ICpuCoolerBuilder SetHeight(Cm height)
    {
        ArgumentNullException.ThrowIfNull(height);
        if (height.Centimetre < 1)
            throw CpuCoolerException.InvalidHeight(height.Centimetre);

        _height = height;
        return this;
    }

    public ICpuCoolerBuilder SetSupportedSockets(ICollection<Socket> supportedSockets)
    {
        if (supportedSockets is null)
            throw CpuCoolerException.InvalidSupportedSocketsData();

        _supportedSockets.AddRange(supportedSockets);
        return this;
    }

    public ICpuCoolerBuilder SetMaxDissipatedTdp(Watt maxDissipatedTdp)
    {
        ArgumentNullException.ThrowIfNull(maxDissipatedTdp);
        if (maxDissipatedTdp.WattValue < 1)
            throw CpuCoolerException.InvalidMaxDissipatedTdp(maxDissipatedTdp.WattValue);

        _maxDissipatedTdp = maxDissipatedTdp;
        return this;
    }

    public ICpuCoolerBuilder SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw CpuCoolerException.InvalidCoolerName();

        _name = name;
        return this;
    }

    public ICpuCoolerBuilder ImportCpuCooler(CpuCooler cpuCooler)
    {
        ArgumentNullException.ThrowIfNull(cpuCooler);

        _cpuCoolerValidator.CheckImportValid(cpuCooler);

        _name = cpuCooler.Name;
        _height = cpuCooler.Height;
        _maxDissipatedTdp = cpuCooler.MaxDissipatedTdp;

        if (_supportedSockets.Count > 0)
            throw CpuCoolerException.InvalidSupportedSocketsData();

        _supportedSockets.AddRange(cpuCooler.SupportedSockets);

        return this;
    }

    public CpuCooler Build()
    {
        if (_height.Centimetre == 0 || _supportedSockets.Count == 0 || _maxDissipatedTdp.WattValue == 0 || string.IsNullOrEmpty(_name))
            throw CpuCoolerException.NotAllAttributesAreSetException();

        return new CpuCooler(_height, _supportedSockets, _maxDissipatedTdp, _name);
    }
}