using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class RamValidator : IRamValidator
{
    public void CheckImportValid(Ram ram)
    {
        ArgumentNullException.ThrowIfNull(ram);
        ArgumentNullException.ThrowIfNull(ram.RamFormFactor);
        ArgumentNullException.ThrowIfNull(ram.GbValue);
        ArgumentNullException.ThrowIfNull(ram.Ddr);
        ArgumentNullException.ThrowIfNull(ram.PowerConsumption);
        ArgumentNullException.ThrowIfNull(ram.XmpProfiles);
        if (ram.XmpProfiles.Count == 0)
            throw RamException.InvalidXmpData();

        if (string.IsNullOrEmpty(ram.Name))
            throw RamException.InvalidRamName();
    }
}