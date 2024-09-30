using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class PleasureShuttle : Ship
{
    private const int WayDistance = 0;
    private const int Hp = 6;

    public PleasureShuttle()
        : base(Hp, false, WayDistance, new ImpulseEngineC())
    {
    }
}