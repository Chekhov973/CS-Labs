using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class NavigationResult
{
    private const int ActivePlasmaCost = 10;
    private const int GravityMatterCost = 20;
    public NavigationResult(Ship ship)
    {
        Ship = ship;
        IsSuccess = true;
    }

    public Ship Ship { get; private set; }
    public int FuelCost { get; private set; }
    public bool IsSuccess { get; set; }

    public void SetFuelcost(int fuelConsumption, bool isGravityMatter)
    {
        if (isGravityMatter == false)
        {
            FuelCost = fuelConsumption * ActivePlasmaCost;
        }
        else
        {
            FuelCost = fuelConsumption * GravityMatterCost;
        }
    }
}