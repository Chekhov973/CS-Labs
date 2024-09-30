using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class Storage
{
    protected Storage(IConnection connection, Gb gbValue, Watt powerConsumption)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ArgumentNullException.ThrowIfNull(gbValue);
        ArgumentNullException.ThrowIfNull(powerConsumption);

        GbValue = gbValue;
        Connection = connection;
        PowerConsumption = powerConsumption;
    }

    public IConnection Connection { get; }

    public Gb GbValue { get; }

    public Watt PowerConsumption { get; }
}