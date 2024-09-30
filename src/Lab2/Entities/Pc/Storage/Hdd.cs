using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Hdd : Storage
{
    private int _spindleSpeed;

    public Hdd(Watt powerConsumption, Gb gbValue, IConnection connection, int spindleSpeed)
    : base(connection, gbValue, powerConsumption)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ArgumentNullException.ThrowIfNull(gbValue);
        ArgumentNullException.ThrowIfNull(powerConsumption);

        if (spindleSpeed < 1)
            throw StorageException.InvalidSpidnleSpeed(spindleSpeed);
        _spindleSpeed = spindleSpeed;
    }

    public new IConnection Connection => base.Connection;
    public new Gb GbValue => base.GbValue;
    public new Watt PowerConsumption => base.PowerConsumption;
    public int SpindleSpeed => _spindleSpeed;
}