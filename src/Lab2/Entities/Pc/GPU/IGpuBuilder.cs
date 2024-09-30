using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

public interface IGpuBuilder
{
    public IGpuBuilder SetName(string name);
    public IGpuBuilder SetHeight(Cm height);
    public IGpuBuilder SetLength(Cm length);
    public IGpuBuilder SetVideoMemory(Gb memoryValue);
    public IGpuBuilder SetPcie(Pcie pcieVersion);
    public IGpuBuilder SetCoreFrequency(Hz frequency);
    public IGpuBuilder SetPowerConsumption(Watt powerConsumption);
    public IGpuBuilder ImportGpu(Gpu gpu);
    public Gpu Build();
}