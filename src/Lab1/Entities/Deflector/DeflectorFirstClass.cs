namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorFirstClass : Deflector
{
    private const int Hp = 10;

    public DeflectorFirstClass(bool photonDeflectorStatus)
        : base(photonDeflectorStatus, Hp)
    {
    }
}