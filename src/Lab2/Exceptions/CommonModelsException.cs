using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class CommonModelsException : Exception
{
    private CommonModelsException(string message)
        : base(message)
    {
    }

    private CommonModelsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private CommonModelsException()
    {
    }

    public static CommonModelsException InvalidCmValueException(int cm)
    {
        throw new CommonModelsException($"Invalid cm value {cm}");
    }

    public static CommonModelsException InvalidGigabyteValueException(int gbValue)
    {
        throw new CommonModelsException($"Invalid gigabyte value {gbValue}");
    }

    public static CommonModelsException InvalidWattValueException(int wattValue)
    {
        throw new CommonModelsException($"Invalid watt value given {wattValue}");
    }

    public static CommonModelsException InvalidPcieVersionException(float pcieVersion)
    {
        throw new CommonModelsException($"Invalid PCI-E version {pcieVersion}");
    }

    public static CommonModelsException InvalidHerzValue(int herz)
    {
        throw new CommonModelsException($"Invalid Herz value {herz}");
    }

    public static CommonModelsException InvalidSataVersion(float sataVersion)
    {
        throw new CommonModelsException($"Invalid SATA versdion {sataVersion}");
    }

    public static CommonModelsException InvalidMbpsValue(int mbps)
    {
        throw new CommonModelsException($"Invalid Mbps value {mbps}");
    }

    public static CommonModelsException InvalidBiosType()
    {
        throw new CommonModelsException($"Bios type is invalid");
    }

    public static CommonModelsException InvalidBiosVersion()
    {
        throw new CommonModelsException($"Bios version is invalid");
    }
}