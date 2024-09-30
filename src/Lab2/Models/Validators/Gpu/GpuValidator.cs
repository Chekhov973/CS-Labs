using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class GpuValidator : IGpuValidator
{
    public void CheckImportValid(Gpu gpu)
    {
        ArgumentNullException.ThrowIfNull(gpu);
        ArgumentNullException.ThrowIfNull(gpu.Height);
        ArgumentNullException.ThrowIfNull(gpu.Pcie);
        ArgumentNullException.ThrowIfNull(gpu.CoreFrequency);
        ArgumentNullException.ThrowIfNull(gpu.PowerConsumption);
        ArgumentNullException.ThrowIfNull(gpu.Length);
        ArgumentNullException.ThrowIfNull(gpu.VideoMemory);

        if (string.IsNullOrEmpty(gpu.Name))
            throw GpuException.InvalidgpuName();
    }
}