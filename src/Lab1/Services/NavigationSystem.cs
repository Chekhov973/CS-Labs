using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.PathSections;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class NavigationSystem : INavigationSystem
{
    private FullPath _fullPath;
    private List<Ship> _ships;
    private List<NavigationResult> _results;

    public NavigationSystem()
    {
        _fullPath = new FullPath();
        _ships = new List<Ship>();
        _results = new List<NavigationResult>();
    }

    public void AddShip(Ship ship)
    {
        ArgumentNullException.ThrowIfNull(ship);

        if (_ships.Contains(ship))
            throw ServiceException.ShipIsAlreadyInList(ship);

        _ships.Add(ship);
    }

    public void AddNavigationRecords()
    {
        foreach (Ship ship in _ships)
        {
            var navRes = new NavigationResult(ship);

            _results.Add(navRes);
        }
    }

    public void AddFullPath(PathSection pathSection)
    {
        ArgumentNullException.ThrowIfNull(pathSection);

        if (_fullPath.PathSections.Contains(pathSection))
            throw ServiceException.FullPathIsAlreadyInList(pathSection);

        _fullPath.AddPathSection(pathSection);
    }

    public void CountFuelCost(Ship ship)
    {
        ArgumentNullException.ThrowIfNull(ship);

        foreach (PathSection pathSection in _fullPath.PathSections)
        {
            switch (pathSection.Environment)
            {
                case FreeSpace:
                    if (ship.Engines.Any(x => x is ImpulseEngineC or ImpulseEngineE))
                    {
                        _results.First(x => x.Ship == ship).SetFuelcost(_results.First(x => x.Ship == ship).Ship.GetImpulseEngine().FuelCount(pathSection.Length), false);
                    }
                    else
                    {
                        _results.First(x => x.Ship == ship).IsSuccess = false;
                    }

                    break;
                case FogSpace:
                    if (ship.Engines.Any(x => x is JumpEngineAlpha or JumpEngineGamma or JumpEngineOmega))
                    {
                        if (ship.WayRange < pathSection.Length)
                        {
                            _results.First(x => x.Ship == ship).IsSuccess = false;
                        }
                        else
                        {
                            _results.First(x => x.Ship == ship).SetFuelcost(_results.First(x => x.Ship == ship).Ship.GetJumpEngine().FuelCount(pathSection.Length), true);
                        }
                    }
                    else
                    {
                        _results.First(x => x.Ship == ship).IsSuccess = false;
                    }

                    break;
                case NitrinFogSpace:
                    if (ship.Engines.Any(x => x is ImpulseEngineE))
                    {
                        _results.First(x => x.Ship == ship).SetFuelcost(_results.First(x => x.Ship == ship).Ship.GetImpulseEngine().FuelCount(pathSection.Length), false);
                    }
                    else
                    {
                        _results.First(x => x.Ship == ship).IsSuccess = false;
                    }

                    break;
            }
        }
    }

    public void CollisionsCalculation(Ship ship)
    {
        ArgumentNullException.ThrowIfNull(ship);

        foreach (PathSection pathSection in _fullPath.PathSections)
        {
            foreach (Obstacle obstacle in pathSection.Environment.Obstacles)
            {
                ship.Collision(obstacle);
            }
        }

        if (ship.ShipHp == 0 || ship.IsCrewAlive == false)
        {
            _results.First(x => x.Ship == ship).IsSuccess = false;
        }
    }

    public IReadOnlyCollection<NavigationResult> GetResults()
    {
        return _results.ToList();
    }

    public Ship ChooseOptimal()
    {
        int minFuelCost = _results.First().FuelCost;

        foreach (NavigationResult navRes in _results)
        {
            if (navRes.IsSuccess && navRes.FuelCost < minFuelCost)
                minFuelCost = navRes.FuelCost;
        }

        NavigationResult halfRes = _results.First(x => x.FuelCost == minFuelCost);

        return halfRes.Ship;
    }
}