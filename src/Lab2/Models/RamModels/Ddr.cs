using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Ddr
{
    private int _ddrVersion;

    public Ddr(int ddrVersion)
    {
        if (ddrVersion < 1)
            throw RamException.InvalidDdrVersion(ddrVersion);

        _ddrVersion = ddrVersion;
    }

    public Ddr()
    {
        _ddrVersion = 0;
    }

    public int DdrVersion => _ddrVersion;
}