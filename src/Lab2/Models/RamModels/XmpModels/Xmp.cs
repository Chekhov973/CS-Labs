using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Xmp
{
    public Xmp(string xmp, IXmpValidator xmpValidator, Hz frequency)
    {
        ArgumentNullException.ThrowIfNull(xmpValidator);
        ArgumentNullException.ThrowIfNull(xmp);
        ArgumentNullException.ThrowIfNull(frequency);

        if (!xmpValidator.IsXmpValid(xmp))
            throw RamException.InvalidXmp(xmp);

        XmpProfile = xmp;
        Frequency = frequency;
    }

    public string XmpProfile { get; }
    public Hz Frequency { get; }
}