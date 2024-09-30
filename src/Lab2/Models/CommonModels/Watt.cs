using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Watt
{
    private int _wattValue;

    public Watt(int wattValue)
    {
        if (wattValue < 1)
            throw CommonModelsException.InvalidWattValueException(wattValue);

        _wattValue = wattValue;
    }

    public Watt()
    {
        _wattValue = 0;
    }

    public int WattValue => _wattValue;
}