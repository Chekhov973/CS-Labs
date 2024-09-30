using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;

public class MotherboardBuilder : IMotherboardBuilder
{
    private IMotherboardValidator _motherboardValidator = new MotherboardValidator();
    private string _name = string.Empty;
    private Socket _socket = new Socket();
    private int _pCieAmount;
    private int _sAtaAmount;
    private Chipset _chipset = new Chipset();
    private Ddr _ddrVersion = new Ddr();
    private int _mEmPortAmount;
    private FormFactor _formFactor = new FormFactor();
    private Bios _bios = new Bios();

    public IMotherboardBuilder SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw MotherboardException.InvalidMotherboardName();

        _name = name;
        return this;
    }

    public IMotherboardBuilder SetSocket(Socket socket)
    {
        ArgumentNullException.ThrowIfNull(socket);
        _socket = socket;
        return this;
    }

    public IMotherboardBuilder SetPcieAmount(int pcieAmount)
    {
        if (pcieAmount < 1)
            throw MotherboardException.InvalidPcieAmount(pcieAmount);

        _pCieAmount = pcieAmount;
        return this;
    }

    public IMotherboardBuilder SetSataAmount(int sataAmount)
    {
        if (sataAmount < 1)
            throw MotherboardException.InvalidSataAmount(sataAmount);

        _sAtaAmount = sataAmount;

        return this;
    }

    public IMotherboardBuilder SetChipset(Chipset chipset)
    {
        ArgumentNullException.ThrowIfNull(chipset);

        _chipset = chipset;
        return this;
    }

    public IMotherboardBuilder SetDdrVersion(Ddr ddrVersion)
    {
        ArgumentNullException.ThrowIfNull(ddrVersion);

        _ddrVersion = ddrVersion;
        return this;
    }

    public IMotherboardBuilder SetMemPortAmount(int memPortAmount)
    {
        if (memPortAmount < 1)
            throw MotherboardException.InvalidMemPortAmount(memPortAmount);

        _mEmPortAmount = memPortAmount;
        return this;
    }

    public IMotherboardBuilder SetFormFactor(FormFactor formFactor)
    {
        ArgumentNullException.ThrowIfNull(formFactor);

        _formFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder SetBios(Bios bios)
    {
        ArgumentNullException.ThrowIfNull(bios);

        _bios = bios;
        return this;
    }

    public IMotherboardBuilder ImportMotherboard(Motherboard motherboard)
    {
        ArgumentNullException.ThrowIfNull(motherboard);
        _motherboardValidator.CheckImportValid(motherboard);

        _name = motherboard.Name;
        _ddrVersion = motherboard.DdrVersion;
        _formFactor = motherboard.FormFactor;
        _bios = motherboard.Bios;
        _socket = motherboard.Socket;
        _chipset = motherboard.Chipset;
        _pCieAmount = motherboard.PcieAmount;
        _sAtaAmount = motherboard.SataAmount;
        _mEmPortAmount = motherboard.MemPortAmount;

        return this;
    }

    public Motherboard Build()
    {
        if (string.IsNullOrEmpty(_name) || string.IsNullOrEmpty(_socket.SocketName) || _ddrVersion.DdrVersion == 0 ||
            _chipset.XmpFrequencies.Count == 0 || string.IsNullOrEmpty(_formFactor.Name) || _bios.BiosVersion == 0 ||
            _pCieAmount == 0 || _sAtaAmount == 0 || _mEmPortAmount == 0)
            throw MotherboardException.NotAllAttributesAreSetException();

        return new Motherboard(_name, _socket, _pCieAmount, _sAtaAmount, _chipset, _ddrVersion, _mEmPortAmount, _formFactor, _bios);
    }
}