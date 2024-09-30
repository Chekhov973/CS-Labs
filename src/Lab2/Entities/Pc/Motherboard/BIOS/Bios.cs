using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;

public class Bios : IBios
{
    private string _biosType;
    private float _biosVersion;
    private List<string> _supportedCpus = new List<string>();

    public Bios(ICollection<string> supportedCpus, string biosType, float biosVersion)
    {
        ArgumentNullException.ThrowIfNull(supportedCpus);
        if (string.IsNullOrEmpty(biosType))
            throw CommonModelsException.InvalidBiosType();

        if (biosVersion < 1)
            throw CommonModelsException.InvalidBiosVersion();

        _supportedCpus.AddRange(supportedCpus);
        _biosType = biosType;
        _biosVersion = biosVersion;
    }

    public Bios()
    {
        _biosType = string.Empty;
        _biosVersion = 0;
        _supportedCpus = new List<string>();
    }

    public string BiosType => _biosType;
    public float BiosVersion => _biosVersion;
    public IReadOnlyCollection<string> SupportedCpus => _supportedCpus;
}