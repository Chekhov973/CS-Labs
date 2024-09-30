using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IStorageBuilder
{
    public IStorageBuilder SetConnectionType(IConnection connection);
    public IStorageBuilder SetGbValue(Gb gbValue);
    public IStorageBuilder SetPowerConsumption(Watt powerConsumption);
    public IStorageBuilder SetSpindleSpeed(int spindleSpeed);
    public IStorageBuilder SetReadingSpeed(Mbps readingSpeed);
    public IStorageBuilder ImportSsd(Ssd ssd);
    public IStorageBuilder ImportHdd(Hdd hdd);
    public Ssd BuildSsd();
    public Hdd BuildHdd();
}