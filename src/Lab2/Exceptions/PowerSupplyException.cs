using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class PowerSupplyException : Exception
{
    private PowerSupplyException(string message)
        : base(message)
    {
    }

    private PowerSupplyException()
    {
    }

    private PowerSupplyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static PowerSupplyException NotAllAttributesAreSetException()
    {
        throw new PowerSupplyException($"Building is impossible: not all attributes are set");
    }

    public static PowerSupplyException InvalidPowerSupplyName()
    {
        throw new PowerSupplyException($"Invalid power supply name");
    }
}