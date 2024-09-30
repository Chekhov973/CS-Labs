using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class WifiAdapterException : Exception
{
    private WifiAdapterException(string message)
        : base(message)
    {
    }

    private WifiAdapterException()
    {
    }

    private WifiAdapterException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static WifiAdapterException NotAllAttributesAreSetException()
    {
        throw new WifiAdapterException($"Building is impossible: not all attributes are set");
    }
}