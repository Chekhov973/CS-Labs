using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class MotherboardValidator : IMotherboardValidator
{
    public void CheckImportValid(Motherboard motherboard)
    {
        ArgumentNullException.ThrowIfNull(motherboard);
        ArgumentNullException.ThrowIfNull(motherboard.DdrVersion);
        ArgumentNullException.ThrowIfNull(motherboard.FormFactor);
        ArgumentNullException.ThrowIfNull(motherboard.Bios);
        ArgumentNullException.ThrowIfNull(motherboard.Socket);
        ArgumentNullException.ThrowIfNull(motherboard.Chipset);
        ArgumentNullException.ThrowIfNull(motherboard.PcieAmount);
        ArgumentNullException.ThrowIfNull(motherboard.SataAmount);
        ArgumentNullException.ThrowIfNull(motherboard.MemPortAmount);

        if (string.IsNullOrEmpty(motherboard.Name))
            throw MotherboardException.InvalidMotherboardName();
    }
}