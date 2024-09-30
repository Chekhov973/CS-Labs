using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;

public class Motherboard
{
    private string _name;
    private Socket _socket;
    private int _pcieAmount;
    private int _sataAmount;
    private Chipset _chipset;
    private Ddr _ddrVersion;
    private int _memPortAmount;
    private FormFactor _formFactor;
    private Bios _bios;

    public Motherboard(string name, Socket socket, int pcieAmount, int sataAmount, Chipset chipset, Ddr ddrVersion, int memPortAmount, FormFactor formFactor, Bios bios)
    {
        ArgumentNullException.ThrowIfNull(socket);
        ArgumentNullException.ThrowIfNull(chipset);
        ArgumentNullException.ThrowIfNull(ddrVersion);
        ArgumentNullException.ThrowIfNull(formFactor);
        ArgumentNullException.ThrowIfNull(bios);

        if (string.IsNullOrEmpty(name))
            throw MotherboardException.InvalidMotherboardName();

        if (pcieAmount < 1)
            throw MotherboardException.InvalidPcieAmount(pcieAmount);

        if (sataAmount < 1)
            throw MotherboardException.InvalidSataAmount(sataAmount);

        if (memPortAmount < 1)
            throw MotherboardException.InvalidMemPortAmount(memPortAmount);

        _name = name;
        _socket = socket;
        _pcieAmount = pcieAmount;
        _sataAmount = sataAmount;
        _chipset = chipset;
        _ddrVersion = ddrVersion;
        _memPortAmount = memPortAmount;
        _formFactor = formFactor;
        _bios = bios;
    }

    public Motherboard()
    {
        _name = string.Empty;
        _socket = new Socket();
        _pcieAmount = 0;
        _sataAmount = 0;
        _chipset = new Chipset();
        _ddrVersion = new Ddr();
        _memPortAmount = 0;
        _formFactor = new FormFactor();
        _bios = new Bios();
    }

    public string Name => _name;
    public Socket Socket => _socket;
    public int PcieAmount => _pcieAmount;
    public int SataAmount => _sataAmount;
    public Chipset Chipset => _chipset;
    public Ddr DdrVersion => _ddrVersion;
    public int MemPortAmount => _memPortAmount;
    public FormFactor FormFactor => _formFactor;
    public Bios Bios => _bios;
}