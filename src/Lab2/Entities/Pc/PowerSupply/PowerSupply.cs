using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupplies;

public class PowerSupply
{
    public PowerSupply(string name, Watt maxPower)
    {
        ArgumentNullException.ThrowIfNull(maxPower);
        if (string.IsNullOrEmpty(name))
            throw PowerSupplyException.InvalidPowerSupplyName();
        Name = name;
        MaxPower = maxPower;
    }

    public PowerSupply()
    {
        Name = string.Empty;
        MaxPower = new Watt();
    }

    public string Name { get; }
    public Watt MaxPower { get; }
}