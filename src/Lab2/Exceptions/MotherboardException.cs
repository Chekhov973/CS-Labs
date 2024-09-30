using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class MotherboardException : Exception
{
    private MotherboardException(string message)
        : base(message)
    {
    }

    private MotherboardException()
    {
    }

    private MotherboardException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static MotherboardException InvalidPcieAmount(int pcieAmount)
    {
        throw new MotherboardException($"Invalid PCI-E amount {pcieAmount}");
    }

    public static MotherboardException InvalidSataAmount(int sataAmount)
    {
        throw new MotherboardException($"Invalid SATA amount {sataAmount}");
    }

    public static MotherboardException InvalidDdrVersion(int ddrVersion)
    {
        throw new MotherboardException($"invalid DDR version {ddrVersion}");
    }

    public static MotherboardException InvalidMemPortAmount(int memPortAmount)
    {
        throw new MotherboardException($"Invalid memory ports amount {memPortAmount}");
    }

    public static MotherboardException NotAllAttributesAreSetException()
    {
        throw new MotherboardException($"Building is impossible: not all attributes are set");
    }

    public static MotherboardException InvalidMotherboardName()
    {
        throw new MotherboardException($"Invalid motherboard name");
    }
}