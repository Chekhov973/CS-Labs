using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Meridian : Ship
{
    private const int WayDistance = 0;
    private const int Hp = 26;
    public Meridian(bool blinkProtector)
        : base(Hp, true, WayDistance, new ImpulseEngineE(), new DeflectorSecondClass(blinkProtector))
    {
    }
}