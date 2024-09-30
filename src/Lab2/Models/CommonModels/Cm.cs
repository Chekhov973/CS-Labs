using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Cm
{
    private int _centimetre;

    public Cm(int cm)
    {
        if (cm < 1)
            throw CommonModelsException.InvalidCmValueException(cm);

        _centimetre = cm;
    }

    public Cm()
    {
        _centimetre = 0;
    }

    public int Centimetre => _centimetre;
}