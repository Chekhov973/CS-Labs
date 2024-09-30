using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Avgur : Ship
{
    private const int WayDistance = 1000;
    private const int Hp = 51;
    public Avgur(bool blinkProtector)
        : base(Hp, false, WayDistance, new ImpulseEngineE(), new DeflectorThirdClass(blinkProtector), new JumpEngineAlpha())
    {
    }
}