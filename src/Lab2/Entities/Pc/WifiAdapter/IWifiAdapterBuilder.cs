using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiAdapters;

public interface IWifiAdapterBuilder
{
    public IWifiAdapterBuilder SetWifiModule(WifiModule wifiModule);
    public IWifiAdapterBuilder SetBluetoothModule(bool isInstalled);
    public IWifiAdapterBuilder SetPcie(Pcie pcie);
    public IWifiAdapterBuilder SetPowerConsumption(Watt powerConsumption);
    public IWifiAdapterBuilder ImportWifiAdapter(WifiAdapter importedWifiAdapter);
    public WifiAdapter Build();
}