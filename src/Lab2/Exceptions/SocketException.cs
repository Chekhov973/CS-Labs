using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class SocketException : Exception
{
    private SocketException(string message)
        : base(message)
    {
    }

    private SocketException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private SocketException()
    {
    }

    public static SocketException InvalidSocketNameException(string socketName)
    {
        throw new SocketException($"Invalid socket name {socketName}");
    }
}
