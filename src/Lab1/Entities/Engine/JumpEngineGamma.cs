using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpEngineGamma : Engine
{
    private const int FuelCOnsumptionPart = 100;
    private const int FuelConsumption = 200;
    private const int IgniteFuelConsumption = 10;
    private const int SpeedConst = 1000;
    private const int MinDistance = 1;

    public JumpEngineGamma()
        : base(FuelType.GravityMatter)
    {
        FuelConsumptionCoefficient = FuelConsumption;
        StartFuelConsumption = IgniteFuelConsumption;
        Speed = SpeedConst;
    }

    public int WayRange { get; } = 3000;
    protected override int FuelConsumptionCoefficient { get; }
    protected override int StartFuelConsumption { get; }
    protected override int Speed { get; }
    public override int FuelCount(int distance)
    {
        if (distance < MinDistance)
            throw Exceptions.EngineException.InvalidDistanceException(distance);

        return StartFuelConsumption + (distance / FuelCOnsumptionPart / FuelConsumptionCoefficient) ^ 2;
    }

    public override int TimeCount(int distance)
    {
        if (distance < MinDistance)
            throw Exceptions.EngineException.InvalidDistanceException(distance);

        return distance / Speed;
    }
}