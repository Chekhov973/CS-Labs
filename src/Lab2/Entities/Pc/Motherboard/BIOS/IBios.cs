using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;

public interface IBios
{
    string BiosType { get; }
    float BiosVersion { get; }
    IReadOnlyCollection<string> SupportedCpus { get; }
}