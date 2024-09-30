namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Asteroid : Obstacle
{
    private const int Damage = 5;
    public Asteroid()
    : base(Damage)
    {
    }
}