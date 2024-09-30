using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class CpuCoolerException : Exception
{
    private CpuCoolerException(string message)
        : base(message)
    {
    }

    private CpuCoolerException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private CpuCoolerException()
    {
    }

    public static CpuCoolerException InvalidHeight(int height)
    {
        throw new CpuCoolerException($"Invalid cpu cooler hight {height}");
    }

    public static CpuCoolerException InvalidSupportedSocketsData()
    {
        throw new CpuCoolerException($"Invalid supported sockets data");
    }

    public static CpuCoolerException InvalidMaxDissipatedTdp(int maxDissipatedTdp)
    {
        throw new CpuCoolerException($"Invalid maximum dissipated tdp {maxDissipatedTdp}");
    }

    public static CpuCoolerException NotAllAttributesAreSetException()
    {
        throw new CpuCoolerException($"Building is impossible: not all attributes are set");
    }

    public static CpuCoolerException InvalidCoolerName()
    {
        throw new CpuCoolerException($"Invalid cpu cooler name");
    }
}