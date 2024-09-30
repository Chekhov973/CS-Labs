using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiAdapters;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class WifiAdapterValidator : IWifiAdapterValidator
{
    public void CheckImportValid(WifiAdapter wifiAdapter)
    {
        ArgumentNullException.ThrowIfNull(wifiAdapter);
        ArgumentNullException.ThrowIfNull(wifiAdapter.WifiModule);
        ArgumentNullException.ThrowIfNull(wifiAdapter.PowerConsumption);
        ArgumentNullException.ThrowIfNull(wifiAdapter.Pcie);
        ArgumentNullException.ThrowIfNull(wifiAdapter.IsBluetoothInstalled);
    }
}