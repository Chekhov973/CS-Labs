using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineC : Engine
{
    private const int FuelConsumptionPart = 100;
    private const int FuelConsumption = 30;
    private const int IgniteFuelConsumption = 10;
    private const int SpeedConst = 100;
    private const int MinDistance = 1;

    public ImpulseEngineC()
        : base(FuelType.ActivePlasma)
    {
        FuelConsumptionCoefficient = FuelConsumption;
        StartFuelConsumption = IgniteFuelConsumption;
        Speed = SpeedConst;
    }

    protected override int FuelConsumptionCoefficient { get; }
    protected override int StartFuelConsumption { get; }
    protected override int Speed { get; }

    public override int FuelCount(int distance)
    {
        if (distance < MinDistance)
            throw Exceptions.EngineException.InvalidDistanceException(distance);

        return StartFuelConsumption + (distance / FuelConsumptionPart * FuelConsumptionCoefficient);
    }

    public override int TimeCount(int distance)
    {
        if (distance < MinDistance)
            throw Exceptions.EngineException.InvalidDistanceException(distance);

        return distance / Speed;
    }
}