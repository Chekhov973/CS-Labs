using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class PcBuilderException : Exception
{
    private PcBuilderException(string message)
        : base(message)
    {
    }

    private PcBuilderException()
    {
    }

    private PcBuilderException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static PcBuilderException CpuAndMotherboardSocketAreIncompatibleException(string? cpuSocket, string? motherboardSocket)
    {
        throw new PcBuilderException($"Cpu and motherboard sockets are incompatible: CPU socket : {cpuSocket}, Motherboard socket : {motherboardSocket}");
    }

    public static PcBuilderException CpuCoolerSocketAndMotherboardSocketAreIncompatibleException(string? motherboardSocket)
    {
        throw new PcBuilderException($"Motherboard and CPU cooler sockets are incompatible: motherboard socket {motherboardSocket}");
    }

    public static PcBuilderException NotEnoughPowerSupplyMaxPowerException(int powerSupplyMaxPower, int componentMaxPower)
    {
        throw new PcBuilderException($"Not enough max power of power supply: power supply max power {powerSupplyMaxPower}, needed {componentMaxPower}");
    }

    public static PcBuilderException InvalidMotherboardFormFactorException(string? motherboardForm)
    {
        throw new PcBuilderException($"Invalid motherboard formFactor: you can install this motherboard in frame with {motherboardForm} form factor");
    }

    public static PcBuilderException MotherboardIsNotInstalledYetException()
    {
        throw new PcBuilderException($"You can't install CPU because motherboard isn't installed yet");
    }

    public static PcBuilderException CpuIsNotInstalledYetException()
    {
        throw new PcBuilderException($"You can't install CPU cooler because CPU isn't installed yet");
    }

    public static PcBuilderException NoFrameException()
    {
        throw new PcBuilderException($"You can't install anything with no frame :)");
    }

    public static PcBuilderException TooMuchRamException()
    {
        throw new PcBuilderException($"You can't install so much ram");
    }

    public static PcBuilderException NotEnoughFreePciePorts()
    {
        throw new PcBuilderException($"You have not enough free PCI-E ports");
    }

    public static PcBuilderException NotEnoughCoolerDissipatedTdp()
    {
        throw new PcBuilderException($"Not enough cooler dissipated tdp");
    }

    public static PcBuilderException CpuIsNotSupported()
    {
        throw new PcBuilderException($"This cpu is not supported for motherboard bios");
    }

    public static PcBuilderException InvalidMetrics()
    {
        throw new PcBuilderException($"Something is too big for this frame");
    }
}