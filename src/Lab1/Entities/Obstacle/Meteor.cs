namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteor : Obstacle
{
    private const int Damage = 10;

    public Meteor()
    : base(Damage)
    {
    }
}