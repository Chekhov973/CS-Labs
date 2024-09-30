using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class GpuException : Exception
{
    private GpuException(string message)
        : base(message)
    {
    }

    private GpuException()
    {
    }

    private GpuException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static GpuException NotAllAttributesAreSetException()
    {
        throw new GpuException($"Building is impossible: not all attributes are set");
    }

    public static GpuException InvalidgpuName()
    {
        throw new GpuException($"Invalid gpu name");
    }
}