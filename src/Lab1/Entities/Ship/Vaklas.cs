using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Vaklas : Ship
{
    private const int WayDistance = 2000;
    private const int Hp = 26;
    public Vaklas(bool blinkProtector)
        : base(Hp, false, WayDistance, new ImpulseEngineE(), new DeflectorFirstClass(blinkProtector), new JumpEngineGamma())
    {
    }
}