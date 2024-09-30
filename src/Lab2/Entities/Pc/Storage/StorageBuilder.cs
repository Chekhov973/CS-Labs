using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class StorageBuilder : IStorageBuilder
{
    private IStorageValidator _storageValidator = new StorageValidator();
    private IConnection _connection = new Pcie();
    private Gb _gbValue = new Gb();
    private Watt _powerConsumption = new Watt();
    private int _spindleSpeed;
    private Mbps _readingSpeed = new Mbps();

    public IStorageBuilder SetConnectionType(IConnection connection)
    {
        ArgumentNullException.ThrowIfNull(connection);

        _connection = connection;
        return this;
    }

    public IStorageBuilder SetGbValue(Gb gbValue)
    {
        ArgumentNullException.ThrowIfNull(gbValue);

        _gbValue = gbValue;
        return this;
    }

    public IStorageBuilder SetPowerConsumption(Watt powerConsumption)
    {
        ArgumentNullException.ThrowIfNull(powerConsumption);

        _powerConsumption = powerConsumption;
        return this;
    }

    public IStorageBuilder SetSpindleSpeed(int spindleSpeed)
    {
        if (spindleSpeed < 1)
            throw StorageException.InvalidSpidnleSpeed(spindleSpeed);

        _spindleSpeed = spindleSpeed;
        return this;
    }

    public IStorageBuilder SetReadingSpeed(Mbps readingSpeed)
    {
        ArgumentNullException.ThrowIfNull(readingSpeed);

        _readingSpeed = readingSpeed;
        return this;
    }

    public IStorageBuilder ImportSsd(Ssd ssd)
    {
        ArgumentNullException.ThrowIfNull(ssd);
        _storageValidator.CheckSsdImportValid(ssd);

        _gbValue = ssd.GbValue;
        _powerConsumption = ssd.PowerConsumption;
        _connection = ssd.Connection;
        _readingSpeed = ssd.ReadingSpeed;
        return this;
    }

    public IStorageBuilder ImportHdd(Hdd hdd)
    {
        ArgumentNullException.ThrowIfNull(hdd);
        _storageValidator.CheckHddImportValid(hdd);

        _gbValue = hdd.GbValue;
        _connection = hdd.Connection;
        _powerConsumption = hdd.PowerConsumption;
        _spindleSpeed = hdd.SpindleSpeed;
        return this;
    }

    public Ssd BuildSsd()
    {
        if (_connection.Version == 0 || _powerConsumption.WattValue == 0 || _gbValue.GbValue == 0 ||
            _readingSpeed.MbpsValue == 0)
            throw StorageException.NotAllAttributesAreSet();

        return new Ssd(_connection, _gbValue, _powerConsumption, _readingSpeed);
    }

    public Hdd BuildHdd()
    {
        if (_powerConsumption.WattValue == 0 || _gbValue.GbValue == 0 || _connection.Version == 0 || _spindleSpeed == 0)
            throw StorageException.NotAllAttributesAreSet();

        if (_connection is not Sata)
            throw StorageException.InvalidConnectionType();

        return new Hdd(_powerConsumption, _gbValue, _connection, _spindleSpeed);
    }
}