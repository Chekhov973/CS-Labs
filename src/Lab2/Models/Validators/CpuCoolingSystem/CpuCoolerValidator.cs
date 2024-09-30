using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class CpuCoolerValidator : ICpuCoolerValidator
{
    public void CheckImportValid(CpuCooler cpuCooler)
    {
        ArgumentNullException.ThrowIfNull(cpuCooler);
        ArgumentNullException.ThrowIfNull(cpuCooler.Height);
        ArgumentNullException.ThrowIfNull(cpuCooler.SupportedSockets);
        ArgumentNullException.ThrowIfNull(cpuCooler.MaxDissipatedTdp);

        if (string.IsNullOrEmpty(cpuCooler.Name))
            throw CpuCoolerException.InvalidCoolerName();

        if (cpuCooler.SupportedSockets.Count == 0)
            throw CpuCoolerException.InvalidSupportedSocketsData();
    }
}