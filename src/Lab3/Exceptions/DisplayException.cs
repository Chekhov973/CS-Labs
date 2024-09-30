using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class DisplayException : Exception
{
    private DisplayException(string message)
        : base(message)
    {
    }

    private DisplayException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private DisplayException()
    {
    }

    public static DisplayException InvalidColorException()
    {
        throw new DisplayException($"Invalid color");
    }
}