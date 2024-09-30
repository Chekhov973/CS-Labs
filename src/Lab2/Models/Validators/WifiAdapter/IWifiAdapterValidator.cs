using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiAdapters;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IWifiAdapterValidator
{
    public void CheckImportValid(WifiAdapter wifiAdapter);
}