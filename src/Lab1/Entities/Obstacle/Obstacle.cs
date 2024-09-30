using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public abstract class Obstacle
{
    private const int MinDamage = 0;

    protected Obstacle(int damagePower)
    {
        if (damagePower < MinDamage)
            throw ObstacleException.InvalidObstacleDamage(damagePower);

        DamagePower = damagePower;
    }

    public int DamagePower { get; }
}