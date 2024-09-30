using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class GroupException : Exception
{
    private GroupException(string message)
        : base(message)
    {
    }

    private GroupException()
    {
    }

    private GroupException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static GroupException NoAdressInList()
    {
        throw new GroupException($"List of adresses doesn't contain adress");
    }
}