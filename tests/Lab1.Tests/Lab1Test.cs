using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.PathSections;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Lab1Test
{
    private readonly INavigationSystem _navigationSystem = new NavigationSystem();
    public static IEnumerable<object[]> Data1 =>
        new List<object[]>
        {
            new object[] { false, false },
        };

    public static IEnumerable<object[]> Data2 =>
            new List<object[]>
            {
                new object[] { false, true },
            };
    public static IEnumerable<object[]> Data3 =>
        new List<object[]>
        {
            new object[] { 0, false, true, 26 },
        };

    [Theory]
    [MemberData(nameof(Data1))]
    public void PleasureShuttleAndAvgurBothFailed(bool shuttleIsSuccess, bool avgurIsSuccess)
    {
        var pleasureShuttle = new PleasureShuttle();
        var avgur = new Avgur(false);

        _navigationSystem.AddShip(pleasureShuttle);
        _navigationSystem.AddShip(avgur);

        _navigationSystem.AddNavigationRecords();

        var fogSpacee = new FogSpace();
        var pathSection = new PathSection(1500, fogSpacee);

        _navigationSystem.AddFullPath(pathSection);

        _navigationSystem.CountFuelCost(avgur);
        _navigationSystem.CountFuelCost(pleasureShuttle);

        _navigationSystem.CollisionsCalculation(avgur);
        _navigationSystem.CountFuelCost(pleasureShuttle);

        Assert.Equal(shuttleIsSuccess, _navigationSystem.GetResults().First(x => x.Ship is PleasureShuttle).IsSuccess);
        Assert.Equal(avgurIsSuccess, _navigationSystem.GetResults().First(x => x.Ship is Avgur).IsSuccess);
    }

    [Theory]
    [MemberData(nameof(Data2))]
    public void AntimatterBlinkVaklasIsDeadVaklasPhotonDeflectorIsAlive(bool isCreweAlive, bool isSuccess)
    {
        var vaklasNoBlinkProtection = new Vaklas(false);
        var vaklasBlinkProtection = new Vaklas(true);

        _navigationSystem.AddShip(vaklasNoBlinkProtection);
        _navigationSystem.AddShip(vaklasBlinkProtection);

        _navigationSystem.AddNavigationRecords();

        var fogSpace = new FogSpace();
        var blink = new AntiMatterBlink();
        fogSpace.AddObstacle(blink);
        var pathSection = new PathSection(100, fogSpace);
        _navigationSystem.AddFullPath(pathSection);

        _navigationSystem.CollisionsCalculation(vaklasNoBlinkProtection);
        _navigationSystem.CollisionsCalculation(vaklasBlinkProtection);

        Assert.Equal(isCreweAlive, _navigationSystem.GetResults().First(x => x.Ship == vaklasNoBlinkProtection).Ship.IsCrewAlive);
        Assert.Equal(isSuccess, _navigationSystem.GetResults().First(x => x.Ship == vaklasBlinkProtection).IsSuccess);
    }

    [Theory]
    [MemberData(nameof(Data3))]
    public void SpaceWhaleVaklasIsDeadAvgurLostDeflectorMeridianFull(int vaklasHp, bool avgurDeflectorStatus, bool meridianDeflectorStatus, int meridianHp)
    {
        var vaklas = new Vaklas(false);
        var avgur = new Avgur(false);
        var meridian = new Meridian(false);

        _navigationSystem.AddShip(vaklas);
        _navigationSystem.AddShip(avgur);
        _navigationSystem.AddShip(meridian);

        _navigationSystem.AddNavigationRecords();

        var nitrineFogSpace = new NitrinFogSpace();
        var spaceWhale = new SpaceWhale();
        nitrineFogSpace.AddObstacle(spaceWhale);
        var pathSection = new PathSection(100, nitrineFogSpace);
        _navigationSystem.AddFullPath(pathSection);

        _navigationSystem.CollisionsCalculation(vaklas);
        _navigationSystem.CollisionsCalculation(avgur);
        _navigationSystem.CollisionsCalculation(meridian);

        Assert.Equal(vaklasHp, _navigationSystem.GetResults().First(x => x.Ship is Vaklas).Ship.ShipHp);
        Assert.Equal(avgurDeflectorStatus, _navigationSystem.GetResults().First(x => x.Ship is Avgur).Ship.Deflector?.ActiveStatus);
        Assert.Equal(meridianDeflectorStatus, _navigationSystem.GetResults().First(x => x.Ship is Meridian).Ship.Deflector?.ActiveStatus);
        Assert.Equal(meridianHp, _navigationSystem.GetResults().First(x => x.Ship is Meridian).Ship.ShipHp);
    }

    [Fact]
    public void ShuttleAndVaklasShuttle()
    {
        var shuttle = new PleasureShuttle();
        var vaklas = new Vaklas(false);

        _navigationSystem.AddShip(shuttle);
        _navigationSystem.AddShip(vaklas);

        _navigationSystem.AddNavigationRecords();

        var freeSpace = new FreeSpace();
        var pathSection = new PathSection(500, freeSpace);
        _navigationSystem.AddFullPath(pathSection);

        _navigationSystem.CountFuelCost(shuttle);
        _navigationSystem.CountFuelCost(vaklas);

        Ship result = _navigationSystem.ChooseOptimal();

        Assert.Equal(result, shuttle);
    }

    [Fact]
    public void AvgurAndStellaSteella()
    {
        var avgur = new Avgur(false);
        var stella = new Stella(false);

        _navigationSystem.AddShip(avgur);
        _navigationSystem.AddShip(stella);

        _navigationSystem.AddNavigationRecords();

        var fogSpace = new FogSpace();
        var pathSection = new PathSection(1500, fogSpace);

        _navigationSystem.AddFullPath(pathSection);

        _navigationSystem.CountFuelCost(avgur);
        _navigationSystem.CountFuelCost(stella);

        Assert.False(_navigationSystem.GetResults().First(x => x.Ship is Avgur).IsSuccess);
        Assert.True(_navigationSystem.GetResults().First(x => x.Ship is Stella).IsSuccess);
    }

    [Fact]
    public void ShuttleAndVaklasVaklas()
    {
        var shuttle = new PleasureShuttle();
        var vaklas = new Vaklas(false);

        _navigationSystem.AddShip(shuttle);
        _navigationSystem.AddShip(vaklas);

        _navigationSystem.AddNavigationRecords();

        var nitrinFogSpace = new NitrinFogSpace();
        var pathSection = new PathSection(500, nitrinFogSpace);
        _navigationSystem.AddFullPath(pathSection);

        _navigationSystem.CountFuelCost(shuttle);
        _navigationSystem.CountFuelCost(vaklas);

        Assert.False(_navigationSystem.GetResults().First(x => x.Ship is PleasureShuttle).IsSuccess);
        Assert.True(_navigationSystem.GetResults().First(x => x.Ship is Vaklas).IsSuccess);
    }
}