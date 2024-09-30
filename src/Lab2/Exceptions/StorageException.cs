using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class StorageException : Exception
{
    private StorageException(string message)
        : base(message)
    {
    }

    private StorageException()
    {
    }

    private StorageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static StorageException InvalidSpidnleSpeed(int spindleSpeed)
    {
        throw new StorageException($"Invalid spindle speed {spindleSpeed}");
    }

    public static StorageException NotAllAttributesAreSet()
    {
        throw new StorageException($"Not all attributes are set");
    }

    public static StorageException InvalidConnectionType()
    {
        throw new StorageException($"Invalid connection type");
    }
}