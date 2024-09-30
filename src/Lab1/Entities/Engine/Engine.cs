using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class Engine
{
    protected Engine(FuelType fuelType)
    {
        ArgumentNullException.ThrowIfNull(fuelType);

        FuelType = fuelType;
    }

    protected FuelType FuelType { get; }
    protected abstract int FuelConsumptionCoefficient { get; }
    protected abstract int StartFuelConsumption { get; }
    protected abstract int Speed { get; }
    public abstract int FuelCount(int distance);
    public abstract int TimeCount(int distance);
}
