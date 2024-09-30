using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Stella : Ship
{
    private const int WayDistance = 3000;
    private const int Hp = 6;

    public Stella(bool blinkProtector)
        : base(Hp, false, WayDistance, new ImpulseEngineE(), new DeflectorThirdClass(blinkProtector), new JumpEngineOmega())
    {
        AddEngine(new ImpulseEngineC());
        AddEngine(new JumpEngineOmega());
    }
}