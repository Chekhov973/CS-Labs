using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;

public class Chipset
{
    private List<Hz> _xmpFrequencies = new List<Hz>();

    public Chipset(ICollection<Hz> frequencies)
    {
        if (frequencies is null)
            throw ChipsetException.InvalidFrequenciesList();

        _xmpFrequencies.AddRange(frequencies);
    }

    public Chipset()
    {
        _xmpFrequencies = new List<Hz>();
    }

    public IReadOnlyCollection<Hz> XmpFrequencies => _xmpFrequencies;
}