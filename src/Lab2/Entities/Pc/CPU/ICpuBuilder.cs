using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

public interface ICpuBuilder
{
    public ICpuBuilder SetName(string name);
    public ICpuBuilder SetCoreQuantity(int coreQuantity);
    public ICpuBuilder SetCoreFrequency(Hz coreFrequency);
    public ICpuBuilder SetSocket(Socket socket);
    public ICpuBuilder SetIntegratedGraphics(bool isIntegratedGraphics);
    public ICpuBuilder SetSupportedFrequencies(ICollection<Hz> supportedFrequencies);
    public ICpuBuilder SetTdp(Watt tdp);
    public ICpuBuilder SetPowerConsumption(Watt powerConsumption);
    public ICpuBuilder ImportCpu(Cpu cpu);

    public Cpu Build();
}