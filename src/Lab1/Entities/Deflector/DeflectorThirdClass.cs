namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorThirdClass : Deflector
{
    private const int Hp = 100;
    public DeflectorThirdClass(bool photonDeflectorStatus)
        : base(photonDeflectorStatus, Hp)
    {
    }
}