using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ssd : Storage
{
    public Ssd(IConnection connection, Gb gbValue, Watt powerConsumption, Mbps readingSpeed)
    : base(connection, gbValue, powerConsumption)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ArgumentNullException.ThrowIfNull(gbValue);
        ArgumentNullException.ThrowIfNull(powerConsumption);
        ArgumentNullException.ThrowIfNull(readingSpeed);

        ReadingSpeed = readingSpeed;
    }

    public new IConnection Connection => base.Connection;
    public new Gb GbValue => base.GbValue;
    public new Watt PowerConsumption => base.PowerConsumption;
    public Mbps ReadingSpeed { get; }
}