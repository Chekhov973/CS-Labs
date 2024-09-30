using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class CpuException : Exception
{
    private CpuException(string message)
        : base(message)
    {
    }

    private CpuException()
    {
    }

    private CpuException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static CpuException InvalidCpuNameException()
    {
        throw new CpuException($"Cpu name is null or empty");
    }

    public static CpuException InvalidCoreQuantityException(int coreQuantity)
    {
        throw new CpuException($"Invalid core quantity {coreQuantity} entered");
    }

    public static CpuException InvalidCoreFrequencyException(int coreFrequency)
    {
        throw new CpuException($"Invalid core frequency {coreFrequency} entered");
    }

    public static CpuException InvalidTdpException(int tdp)
    {
        throw new CpuException($"Invalid TDP entered {tdp}");
    }

    public static CpuException InvalidPowerConsumptionException(int powerConsumption)
    {
        throw new CpuException($"Invalid cpu power consumption entered {powerConsumption}");
    }

    public static CpuException InvalidFrequencyDataException()
    {
        throw new CpuException($"Invalid frequency data given");
    }

    public static CpuException NotAllAttributesAreSetException()
    {
        throw new CpuException($"Building is impossible: not all attributes are set");
    }
}