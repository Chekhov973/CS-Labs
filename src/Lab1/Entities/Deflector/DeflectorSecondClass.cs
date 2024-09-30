namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorSecondClass : Deflector
{
    private const int Hp = 50;
    public DeflectorSecondClass(bool photonDeflectorStatus)
        : base(photonDeflectorStatus, Hp)
    {
    }
}