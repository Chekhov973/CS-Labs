using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Hz
{
    private int _herz;
    public Hz(int herz)
    {
        if (herz < 1)
            throw CommonModelsException.InvalidHerzValue(herz);

        _herz = herz;
    }

    public Hz()
    {
        _herz = 0;
    }

    public int Herz => _herz;
}