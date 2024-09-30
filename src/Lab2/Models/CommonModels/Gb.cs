using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Gb
{
    private int _gbValue;

    public Gb(int gb)
    {
        if (gb < 1)
            throw CommonModelsException.InvalidGigabyteValueException(gb);

        _gbValue = gb;
    }

    public Gb()
    {
        _gbValue = 0;
    }

    public int GbValue => _gbValue;
}