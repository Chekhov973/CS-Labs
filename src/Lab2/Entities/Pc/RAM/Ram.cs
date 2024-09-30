using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public class Ram
{
    private string _name;
    private List<Xmp> _xmpProfiles;
    private RamFormFactor _ramFormFactor;
    private Ddr _ddr;
    private Gb _gb;
    private Watt _powerConsumption;

    public Ram(string name, ICollection<Xmp> xmps, RamFormFactor ramFormFactor, Ddr ddr, Gb gb, Watt powerConsumption)
    {
        ArgumentNullException.ThrowIfNull(xmps);
        ArgumentNullException.ThrowIfNull(ramFormFactor);
        ArgumentNullException.ThrowIfNull(ddr);
        ArgumentNullException.ThrowIfNull(gb);
        ArgumentNullException.ThrowIfNull(powerConsumption);

        if (string.IsNullOrEmpty(name))
            throw RamException.InvalidRamName();

        _name = name;
        _xmpProfiles = new List<Xmp>(xmps);
        _ramFormFactor = ramFormFactor;
        _ddr = ddr;
        _gb = gb;
        _powerConsumption = powerConsumption;
    }

    public Ram()
    {
        _name = string.Empty;
        _xmpProfiles = new List<Xmp>();
        _ramFormFactor = new RamFormFactor();
        _ddr = new Ddr();
        _gb = new Gb();
        _powerConsumption = new Watt();
    }

    public string Name => _name;
    public IReadOnlyCollection<Xmp> XmpProfiles => _xmpProfiles;
    public RamFormFactor RamFormFactor => _ramFormFactor;
    public Ddr Ddr => _ddr;
    public Gb GbValue => _gb;
    public Watt PowerConsumption => _powerConsumption;
}