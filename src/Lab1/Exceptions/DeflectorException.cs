using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class DeflectorException : Exception
{
    private DeflectorException()
    {
    }

    private DeflectorException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private DeflectorException(string message)
        : base(message)
    {
    }

    public static DeflectorException BlinkProtectionIsAlreadyDisabled()
    {
        return new DeflectorException($"Blink protection is already disabled");
    }

    public static DeflectorException InvalidDamageGiven(int damage)
    {
        return new DeflectorException($"Invalid damage {damage} given");
    }
}