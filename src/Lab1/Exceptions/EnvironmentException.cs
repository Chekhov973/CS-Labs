using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class EnvironmentException : Exception
{
    private EnvironmentException()
    {
    }

    private EnvironmentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private EnvironmentException(string message)
             : base(message)
    {
    }

    public static EnvironmentException InvalidObstacleType(Obstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);
        throw new EnvironmentException($"Invalid obstacle type gor {obstacle.GetType()}");
    }
}