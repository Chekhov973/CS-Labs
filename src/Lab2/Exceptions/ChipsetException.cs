using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class ChipsetException : Exception
{
    private ChipsetException(string message)
        : base(message)
    {
    }

    private ChipsetException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private ChipsetException()
    {
    }

    public static ChipsetException InvalidFrequenciesList()
    {
        throw new ChipsetException($"Invlaid list of frequencies given");
    }
}