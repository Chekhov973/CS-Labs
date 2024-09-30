using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiAdapters;

public class WifiAdapterBuilder : IWifiAdapterBuilder
{
    private IWifiAdapterValidator _wifiAdapterValidator = new WifiAdapterValidator();
    private WifiModule _wifiModule = new WifiModule();
    private bool _isBluetoothInstalled;
    private Pcie _pcie = new Pcie();
    private Watt _powerConsumption = new Watt();

    public IWifiAdapterBuilder SetWifiModule(WifiModule wifiModule)
    {
        ArgumentNullException.ThrowIfNull(wifiModule);

        _wifiModule = wifiModule;
        return this;
    }

    public IWifiAdapterBuilder SetBluetoothModule(bool isInstalled)
    {
        _isBluetoothInstalled = isInstalled;
        return this;
    }

    public IWifiAdapterBuilder SetPcie(Pcie pcie)
    {
        ArgumentNullException.ThrowIfNull(pcie);

        _pcie = pcie;
        return this;
    }

    public IWifiAdapterBuilder SetPowerConsumption(Watt powerConsumption)
    {
        ArgumentNullException.ThrowIfNull(powerConsumption);

        _powerConsumption = powerConsumption;
        return this;
    }

    public IWifiAdapterBuilder ImportWifiAdapter(WifiAdapter importedWifiAdapter)
    {
        ArgumentNullException.ThrowIfNull(importedWifiAdapter);
        _wifiAdapterValidator.CheckImportValid(importedWifiAdapter);

        _wifiModule = importedWifiAdapter.WifiModule;
        _powerConsumption = importedWifiAdapter.PowerConsumption;
        _pcie = importedWifiAdapter.Pcie;
        _isBluetoothInstalled = importedWifiAdapter.IsBluetoothInstalled;

        return this;
    }

    public WifiAdapter Build()
    {
        if (string.IsNullOrEmpty(_wifiModule.WifiVersion) || _powerConsumption.WattValue == 0 || _pcie.Version == 0)
            throw WifiAdapterException.NotAllAttributesAreSetException();

        return new WifiAdapter(_wifiModule, _isBluetoothInstalled, _pcie, _powerConsumption);
    }
}