using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public class RamBuilder : IRamBuilder
{
    private IRamValidator _ramValidator = new RamValidator();
    private string _name = string.Empty;
    private List<Xmp> _xmpProfiles = new List<Xmp>();
    private RamFormFactor _ramFormFactor = new RamFormFactor();
    private Ddr _ddr = new Ddr();
    private Gb _gb = new Gb();
    private Watt _powerConsumption = new Watt();

    public IRamBuilder SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw RamException.InvalidRamName();

        _name = name;
        return this;
    }

    public IRamBuilder SetXmpProfiles(ICollection<Xmp> xmps)
    {
        ArgumentNullException.ThrowIfNull(xmps);

        _xmpProfiles.AddRange(xmps);
        return this;
    }

    public IRamBuilder SetRamFormFactor(RamFormFactor ramFormFactor)
    {
        ArgumentNullException.ThrowIfNull(ramFormFactor);

        _ramFormFactor = ramFormFactor;
        return this;
    }

    public IRamBuilder SetDdr(Ddr ddr)
    {
        ArgumentNullException.ThrowIfNull(ddr);

        _ddr = ddr;
        return this;
    }

    public IRamBuilder SetGbValue(Gb gb)
    {
        ArgumentNullException.ThrowIfNull(gb);

        _gb = gb;
        return this;
    }

    public IRamBuilder SetPowerConsumption(Watt watt)
    {
        ArgumentNullException.ThrowIfNull(watt);

        _powerConsumption = watt;
        return this;
    }

    public IRamBuilder ImportRam(Ram ram)
    {
        ArgumentNullException.ThrowIfNull(ram);
        _ramValidator.CheckImportValid(ram);

        _ramFormFactor = ram.RamFormFactor;
        _gb = ram.GbValue;
        _ddr = ram.Ddr;
        _powerConsumption = ram.PowerConsumption;

        if (_xmpProfiles.Count > 0)
            throw RamException.InvalidXmpData();

        _xmpProfiles.AddRange(ram.XmpProfiles);

        return this;
    }

    public Ram Build()
    {
        if (string.IsNullOrEmpty(_name) || _xmpProfiles.Count == 0 || _powerConsumption.WattValue == 0 || _ddr.DdrVersion == 0 || _gb.GbValue == 0 || string.IsNullOrEmpty(_ramFormFactor.FormFactor))
            throw RamException.NotAllAttributesAreSetException();

        return new Ram(_name, _xmpProfiles, _ramFormFactor, _ddr, _gb, _powerConsumption);
    }
}