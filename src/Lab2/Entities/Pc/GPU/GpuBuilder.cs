using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

public class GpuBuilder : IGpuBuilder
{
    private IGpuValidator _gpuValidator = new GpuValidator();
    private string _name = string.Empty;
    private Cm _height = new Cm();
    private Cm _length = new Cm();
    private Gb _videoMemory = new Gb();
    private Pcie _pcie = new Pcie();
    private Hz _coreFrequency = new Hz();
    private Watt _powerConsumption = new Watt();

    public IGpuBuilder SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw GpuException.InvalidgpuName();

        _name = name;
        return this;
    }

    public IGpuBuilder SetHeight(Cm height)
    {
        ArgumentNullException.ThrowIfNull(height);
        _height = height;
        return this;
    }

    public IGpuBuilder SetLength(Cm length)
    {
        ArgumentNullException.ThrowIfNull(length);
        _length = length;
        return this;
    }

    public IGpuBuilder SetVideoMemory(Gb memoryValue)
    {
        ArgumentNullException.ThrowIfNull(memoryValue);
        _videoMemory = memoryValue;
        return this;
    }

    public IGpuBuilder SetPcie(Pcie pcieVersion)
    {
        ArgumentNullException.ThrowIfNull(pcieVersion);
        _pcie = pcieVersion;
        return this;
    }

    public IGpuBuilder SetCoreFrequency(Hz frequency)
    {
        ArgumentNullException.ThrowIfNull(frequency);
        _coreFrequency = frequency;
        return this;
    }

    public IGpuBuilder SetPowerConsumption(Watt powerConsumption)
    {
        ArgumentNullException.ThrowIfNull(powerConsumption);
        _powerConsumption = powerConsumption;
        return this;
    }

    public IGpuBuilder ImportGpu(Gpu gpu)
    {
        ArgumentNullException.ThrowIfNull(gpu);
        _gpuValidator.CheckImportValid(gpu);

        _name = gpu.Name;
        _height = gpu.Height;
        _pcie = gpu.Pcie;
        _coreFrequency = gpu.CoreFrequency;
        _powerConsumption = gpu.PowerConsumption;
        _length = gpu.Length;
        _videoMemory = gpu.VideoMemory;

        return this;
    }

    public Gpu Build()
    {
        if (string.IsNullOrEmpty(_name) || _height.Centimetre == 0 || _coreFrequency.Herz == 0 || _powerConsumption.WattValue == 0 || _length.Centimetre == 0 || _videoMemory.GbValue == 0 || _pcie.Version == 0)
            throw GpuException.NotAllAttributesAreSetException();

        return new Gpu(_height, _length, _videoMemory, _pcie, _coreFrequency, _powerConsumption, _name);
    }
}