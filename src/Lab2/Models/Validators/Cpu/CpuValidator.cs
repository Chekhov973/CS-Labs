using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class CpuValidator : ICpuValidator
{
    public void CheckImportValid(Cpu cpu)
    {
        ArgumentNullException.ThrowIfNull(cpu);
        ArgumentNullException.ThrowIfNull(cpu.PowerConsumption);
        ArgumentNullException.ThrowIfNull(cpu.Socket);
        ArgumentNullException.ThrowIfNull(cpu.Tdp);
        ArgumentNullException.ThrowIfNull(cpu.CoreFrequency);
        ArgumentNullException.ThrowIfNull(cpu.CoreQuantity);
        ArgumentNullException.ThrowIfNull(cpu.SupportedFrequencies);
        ArgumentNullException.ThrowIfNull(cpu.IsIntegratedGraphics);

        if (string.IsNullOrEmpty(cpu.Name))
            throw CpuException.InvalidCpuNameException();

        if (cpu.SupportedFrequencies.Count == 0)
            throw CpuException.InvalidFrequencyDataException();
    }
}