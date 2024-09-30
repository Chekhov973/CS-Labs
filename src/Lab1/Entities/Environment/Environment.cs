using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public abstract class Environment
{
    private List<Obstacle> _obstacles = new();

    public IReadOnlyCollection<Obstacle> Obstacles => _obstacles;
    public virtual void AddObstacle(Obstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);
        _obstacles.Add(obstacle);
    }
}
