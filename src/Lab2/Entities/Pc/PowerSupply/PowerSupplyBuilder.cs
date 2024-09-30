using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupplies;

public class PowerSupplyBuilder : IPowersupplyBuilder
{
    private Watt _maxPower = new Watt();
    private string _name = string.Empty;

    public IPowersupplyBuilder SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw PowerSupplyException.InvalidPowerSupplyName();

        _name = name;
        return this;
    }

    public IPowersupplyBuilder SetMaxPower(Watt maxPower)
    {
        ArgumentNullException.ThrowIfNull(maxPower);

        _maxPower = maxPower;
        return this;
    }

    public PowerSupply Build()
    {
        if (_maxPower.WattValue == 0 || string.IsNullOrEmpty(_name))
            throw PowerSupplyException.NotAllAttributesAreSetException();

        return new PowerSupply(_name, _maxPower);
    }
}