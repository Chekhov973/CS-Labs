using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Mbps
{
    private int _mbps;

    public Mbps(int mbps)
    {
        if (mbps < 1)
            throw CommonModelsException.InvalidMbpsValue(mbps);

        _mbps = mbps;
    }

    public Mbps()
    {
        _mbps = 0;
    }

    public int MbpsValue => _mbps;
}