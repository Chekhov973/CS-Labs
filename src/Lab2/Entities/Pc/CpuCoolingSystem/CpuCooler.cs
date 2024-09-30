using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCoolingSystem;

public class CpuCooler
{
    private string _name;
    private Cm _height;
    private List<Socket> _supportedSockets;
    private Watt _maxDissipatedTdp;

    public CpuCooler(Cm height, IReadOnlyCollection<Socket> supportedSockets, Watt maxDissipatedTdp, string name)
    {
        ArgumentNullException.ThrowIfNull(height);
        ArgumentNullException.ThrowIfNull(supportedSockets);
        ArgumentNullException.ThrowIfNull(maxDissipatedTdp);

        _height = height;
        _supportedSockets = new List<Socket>(supportedSockets);
        _maxDissipatedTdp = maxDissipatedTdp;
        _name = name;
    }

    public CpuCooler()
    {
        _height = new Cm();
        _supportedSockets = new List<Socket>();
        _maxDissipatedTdp = new Watt();
        _name = string.Empty;
    }

    public Cm Height => _height;
    public IReadOnlyCollection<Socket> SupportedSockets => _supportedSockets;
    public Watt MaxDissipatedTdp => _maxDissipatedTdp;
    public string Name => _name;
}
