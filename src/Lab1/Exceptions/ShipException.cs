using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class ShipException : Exception
{
    private ShipException()
    {
    }

    private ShipException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private ShipException(string message)
        : base(message)
    {
    }

    public static ShipException InvalidHpValue(int hp)
    {
        throw new ShipException($"Invalid hp {hp} entered");
    }

    public static ShipException InvalidWayRange(int wayRange)
    {
        throw new ShipException($"invalid way range {wayRange} etered");
    }
}