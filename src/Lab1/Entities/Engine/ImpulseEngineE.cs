using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineE : Engine
{
    private const int FuelConsumptionPart = 100;
    private const int FuelConsumption = 50;
    private const int IgniteFuelConsumption = 5;
    private const int SpeedConst = 400;
    private const int MinDistance = 1;

    public ImpulseEngineE()
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

        return StartFuelConsumption + (FuelConsumptionPart * 2 * FuelConsumptionCoefficient) + ((distance - FuelConsumptionPart) * FuelConsumptionCoefficient);
    }

    public override int TimeCount(int distance)
    {
        if (distance < MinDistance)
            throw Exceptions.EngineException.InvalidDistanceException(distance);

        return (FuelConsumptionPart / Speed / 4) + ((distance - FuelConsumptionPart) / Speed);
    }
}