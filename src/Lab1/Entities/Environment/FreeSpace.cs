using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class FreeSpace : Environment
{
    public override void AddObstacle(Obstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);

        if (obstacle is not Meteor or Asteroid)
            throw EnvironmentException.InvalidObstacleType(obstacle);

        base.AddObstacle(obstacle);
    }
}