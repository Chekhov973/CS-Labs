using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class EngineException : Exception
{
    private EngineException()
    {
    }

    private EngineException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private EngineException(string message)
             : base(message)
    { }
    public static EngineException InvalidDistanceException(int distance)
    {
        return new EngineException($"Distance {distance} is incorrect");
    }
}