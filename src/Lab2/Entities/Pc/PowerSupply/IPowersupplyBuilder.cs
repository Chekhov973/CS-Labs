using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupplies;

public interface IPowersupplyBuilder
{
    public IPowersupplyBuilder SetName(string name);
    public IPowersupplyBuilder SetMaxPower(Watt maxPower);
    public PowerSupply Build();
}