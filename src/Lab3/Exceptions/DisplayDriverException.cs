using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class DisplayDriverException : Exception
{
    private DisplayDriverException(string message)
        : base(message)
    {
    }

    private DisplayDriverException()
    {
    }

    private DisplayDriverException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static DisplayDriverException InvalidColorNameException()
    {
        throw new DisplayDriverException($"Invalid color name");
    }
}