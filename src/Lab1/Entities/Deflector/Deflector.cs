namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class Deflector
{
    private const int BlinkProtectionStartValue = 3;
    private int _blinkProtection;
    protected Deflector(bool photonDeflectorStatus, int deflectorHp)
    {
        ActiveStatus = true;
        DeflectorHp = deflectorHp;
        IsPhotonDeflector = photonDeflectorStatus;

        if (photonDeflectorStatus)
        {
            _blinkProtection = BlinkProtectionStartValue;
        }
    }

    public bool ActiveStatus { get; set; }
    public int DeflectorHp { get; private set; }

    public bool IsPhotonDeflector { get; private set; }

    public void BlinkProtectionReduced()
    {
        if (_blinkProtection == 0)
            throw Exceptions.DeflectorException.BlinkProtectionIsAlreadyDisabled();

        _blinkProtection--;
        if (_blinkProtection == 0)
            IsPhotonDeflector = false;
    }

    public void DeflectorHpReduced(int damage)
    {
        if (DeflectorHp > damage)
        {
            DeflectorHp -= damage;
        }
        else
        {
            ActiveStatus = false;
        }
    }
}