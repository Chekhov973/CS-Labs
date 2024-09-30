using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class Ship
{
    private const int MinHp = 1;
    private const int MinWayrange = 0;
    private List<Engine> _engines;

    protected Ship(int shipHp, bool antiNitrineEmitter, int wayRange, Engine impulseEngine, Deflector? deflector = null,  Engine? jumpEngine = null)
    {
        ArgumentNullException.ThrowIfNull(impulseEngine);

        if (shipHp < MinHp)
            throw ShipException.InvalidHpValue(shipHp);

        if (wayRange < MinWayrange)
            throw ShipException.InvalidWayRange(wayRange);

        _engines = new List<Engine>();
        _engines.Add(impulseEngine);
        if (jumpEngine is not null)
            _engines.Add(jumpEngine);

        ShipHp = shipHp;
        Deflector = deflector;
        AntiNitrineEmitter = antiNitrineEmitter;
        IsCrewAlive = true;
        WayRange = wayRange;
        IsDeflectored = deflector is not null;
    }

    public IReadOnlyCollection<Engine> Engines => _engines;
    public Deflector? Deflector { get; }
    public int ShipHp { get; protected set; }
    public bool AntiNitrineEmitter { get; }
    public bool IsCrewAlive { get; protected set; }
    public int WayRange { get; }
    protected bool IsDeflectored { get; set; }

    public void AddEngine(Engine engine)
    {
        ArgumentNullException.ThrowIfNull(engine);

        _engines.Add(engine);
    }

    public Engine GetImpulseEngine()
    {
        return _engines.First(x => x is ImpulseEngineE or ImpulseEngineC);
    }

    public Engine GetJumpEngine()
    {
        return _engines.First(x => x is JumpEngineAlpha or JumpEngineGamma or JumpEngineOmega);
    }

    public void Collision(Obstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);

        switch (obstacle)
        {
            case AntiMatterBlink:
                if (Deflector is not null && IsDeflectored && Deflector.IsPhotonDeflector)
                    Deflector.BlinkProtectionReduced();
                else
                    IsCrewAlive = false;
                break;

            case SpaceWhale:
                if (!AntiNitrineEmitter)
                {
                    if (Deflector is not null and DeflectorThirdClass && ((DeflectorThirdClass)Deflector).DeflectorHp > 0)
                        Deflector.ActiveStatus = false;
                    else
                        ShipHp = 0;
                }

                break;
            default:
                if (Deflector is not null && Deflector.ActiveStatus)
                    Deflector.DeflectorHpReduced(obstacle.DamagePower);
                else
                    ShipHp -= obstacle.DamagePower;

                break;
        }
    }
}