using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.PathSections;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public interface INavigationSystem
{
    public void AddShip(Ship ship);
    public void AddNavigationRecords();
    public void AddFullPath(PathSection pathSection);
    public void CountFuelCost(Ship ship);
    public void CollisionsCalculation(Ship ship);
    public IReadOnlyCollection<NavigationResult> GetResults();
    public Ship ChooseOptimal();
}