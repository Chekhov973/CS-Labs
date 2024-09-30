using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiAdapters;

public class WifiAdapter
{
    public WifiAdapter(WifiModule wifiModule, bool isBluetoothInstalled, Pcie pcie, Watt powerConsumption)
    {
        ArgumentNullException.ThrowIfNull(wifiModule);
        ArgumentNullException.ThrowIfNull(isBluetoothInstalled);
        ArgumentNullException.ThrowIfNull(pcie);
        ArgumentNullException.ThrowIfNull(powerConsumption);

        WifiModule = wifiModule;
        IsBluetoothInstalled = isBluetoothInstalled;
        Pcie = pcie;
        PowerConsumption = powerConsumption;
    }

    public WifiAdapter()
    {
        WifiModule = new WifiModule();
        Pcie = new Pcie();
        PowerConsumption = new Watt();
    }

    public WifiModule WifiModule { get; }

    public bool IsBluetoothInstalled { get; }

    public Pcie Pcie { get; }

    public Watt PowerConsumption { get; }
}