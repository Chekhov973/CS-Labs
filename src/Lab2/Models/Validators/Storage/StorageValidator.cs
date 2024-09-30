using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class StorageValidator : IStorageValidator
{
    public void CheckSsdImportValid(Ssd ssd)
    {
        ArgumentNullException.ThrowIfNull(ssd);
        ArgumentNullException.ThrowIfNull(ssd.GbValue);
        ArgumentNullException.ThrowIfNull(ssd.PowerConsumption);
        ArgumentNullException.ThrowIfNull(ssd.Connection);
        ArgumentNullException.ThrowIfNull(ssd.ReadingSpeed);
    }

    public void CheckHddImportValid(Hdd hdd)
    {
        ArgumentNullException.ThrowIfNull(hdd);
        ArgumentNullException.ThrowIfNull(hdd.GbValue);
        ArgumentNullException.ThrowIfNull(hdd.Connection);
        ArgumentNullException.ThrowIfNull(hdd.PowerConsumption);
        ArgumentNullException.ThrowIfNull(hdd.SpindleSpeed);
    }
}