using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Sata : IConnection
{
    private float _sataVersion;

    public Sata(float sataVersion)
    {
        if (sataVersion < 1)
            throw CommonModelsException.InvalidSataVersion(sataVersion);

        _sataVersion = sataVersion;
    }

    public float Version => _sataVersion;
}