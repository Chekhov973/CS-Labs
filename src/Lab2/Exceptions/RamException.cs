using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class RamException : Exception
{
    private RamException(string message)
        : base(message)
    {
    }

    private RamException()
    {
    }

    private RamException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static RamException InvalidXmp(string xmp)
    {
        throw new RamException($"Invalid xmp {xmp}");
    }

    public static RamException InvalidDdrVersion(int ddreVersion)
    {
        throw new RamException($"Invalid DDR version {ddreVersion}");
    }

    public static RamException NotAllAttributesAreSetException()
    {
        throw new RamException($"Building is impossible: not all attributes are set");
    }

    public static RamException InvalidRamName()
    {
        throw new RamException($"Invalid ram name");
    }

    public static RamException InvalidXmpData()
    {
        throw new RamException($"Invalid xmp data");
    }
}