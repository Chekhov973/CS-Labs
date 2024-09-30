using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class WifiModule
{
    public WifiModule(string wifiVersion)
    {
        ArgumentNullException.ThrowIfNull(wifiVersion);

        WifiVersion = wifiVersion;
    }

    public WifiModule()
    {
        WifiVersion = string.Empty;
    }

    public string WifiVersion { get; }
}