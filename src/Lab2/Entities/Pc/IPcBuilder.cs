using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupplies;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiAdapters;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcBuilder;

public interface IPcBuilder
{
    public IPcBuilder SetCpu(Cpu cpu);
    public IPcBuilder SetCpuCooler(CpuCooler cpuCooler);
    public IPcBuilder SetFrame(Frame frame);
    public IPcBuilder SetGpu(Gpu gpu);
    public IPcBuilder SetMotherboard(Motherboard motherboard);
    public IPcBuilder SetPowerSupply(PowerSupply powerSupply);
    public IPcBuilder SetRam(ICollection<Ram> rams);
    public IPcBuilder SetSsd(Ssd ssd);
    public IPcBuilder SetHdd(Hdd hdd);
    public IPcBuilder SetWifiAdapter(WifiAdapter wifiAdapter);
    public int GetNeededEnergy();
    public Pc Build();
}