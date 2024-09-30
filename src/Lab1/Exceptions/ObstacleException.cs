using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class ObstacleException : Exception
{
    private ObstacleException()
    {
    }

    private ObstacleException(string message)
        : base(message)
    {
    }

    private ObstacleException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static ObstacleException InvalidObstacleDamage(int damage)
    {
        throw new ObstacleException($"Invalid obstacle damage {damage} given");
    }
}