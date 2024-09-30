using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;

public interface IChipset
{
    public IReadOnlyCollection<string> XmpFrequencies { get; }
}