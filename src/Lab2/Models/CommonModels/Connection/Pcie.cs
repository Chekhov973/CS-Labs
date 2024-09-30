using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Pcie : IConnection
{
    private float _pcieVersion;

    public Pcie(float pcieVersion)
    {
        if (pcieVersion < 1)
            throw CommonModelsException.InvalidPcieVersionException(pcieVersion);

        _pcieVersion = pcieVersion;
    }

    public Pcie()
    {
        _pcieVersion = 0;
    }

    public float Version => _pcieVersion;
}