using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpEngineOmega : Engine
{
    private const int FuelConsumptionPart = 100;
    private const int FuelConsumption = 10;
    private const int IgniteFuelConsumption = 5;
    private const int SpeedConst = 600;
    private const int MinDistance = 1;

    public JumpEngineOmega()
        : base(FuelType.GravityMatter)
    {
        FuelConsumptionCoefficient = FuelConsumption;
        StartFuelConsumption = IgniteFuelConsumption;
        Speed = SpeedConst;
    }

    public int WayRange { get; } = 2000;
    protected override int FuelConsumptionCoefficient { get; }
    protected override int StartFuelConsumption { get; }
    protected override int Speed { get; }

    public override int FuelCount(int distance)
    {
        if (distance < MinDistance)
            throw Exceptions.EngineException.InvalidDistanceException(distance);

        return StartFuelConsumption + (int)Math.Log(distance / FuelConsumptionPart / FuelConsumptionCoefficient);
    }

    public override int TimeCount(int distance)
    {
        if (distance < MinDistance)
            throw Exceptions.EngineException.InvalidDistanceException(distance);

        return distance / Speed;
    }
}