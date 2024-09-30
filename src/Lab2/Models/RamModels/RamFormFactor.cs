using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class RamFormFactor
{
    private string _ramFormFactor;

    public RamFormFactor(string ramFormFactor)
    {
        ArgumentNullException.ThrowIfNull(ramFormFactor);

        _ramFormFactor = ramFormFactor;
    }

    public RamFormFactor()
    {
        _ramFormFactor = string.Empty;
    }

    public string FormFactor => _ramFormFactor;
}