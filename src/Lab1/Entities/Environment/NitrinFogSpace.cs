using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NitrinFogSpace : Environment
{
    public override void AddObstacle(Obstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);

        if (obstacle is not SpaceWhale)
            throw EnvironmentException.InvalidObstacleType(obstacle);

        base.AddObstacle(obstacle);
    }
}