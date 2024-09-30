using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

public class Gpu
{
    private string _name;
    private Cm _height;
    private Cm _length;
    private Gb _videoMemory;
    private Pcie _pcie;
    private Hz _coreFrequency;
    private Watt _powerConsumption;

    public Gpu(Cm height, Cm length, Gb videoMemory, Pcie pcie, Hz coreFrequency, Watt powerConsumption, string name)
    {
        ArgumentNullException.ThrowIfNull(height);
        ArgumentNullException.ThrowIfNull(length);
        ArgumentNullException.ThrowIfNull(videoMemory);
        ArgumentNullException.ThrowIfNull(pcie);
        ArgumentNullException.ThrowIfNull(coreFrequency);
        ArgumentNullException.ThrowIfNull(powerConsumption);

        if (string.IsNullOrEmpty(name))
            throw GpuException.InvalidgpuName();

        _name = name;
        _height = height;
        _length = length;
        _videoMemory = videoMemory;
        _pcie = pcie;
        _coreFrequency = coreFrequency;
        _powerConsumption = powerConsumption;
    }

    public Gpu()
    {
        _name = string.Empty;
        _height = new Cm();
        _length = new Cm();
        _videoMemory = new Gb();
        _pcie = new Pcie();
        _coreFrequency = new Hz();
        _powerConsumption = new Watt();
    }

    public string Name => _name;
    public Cm Height => _height;
    public Cm Length => _length;
    public Gb VideoMemory => _videoMemory;
    public Pcie Pcie => _pcie;
    public Hz CoreFrequency => _coreFrequency;
    public Watt PowerConsumption => _powerConsumption;
}