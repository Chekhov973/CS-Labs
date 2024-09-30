using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCoolingSystem;

public interface ICpuCoolerBuilder
{
    public ICpuCoolerBuilder SetHeight(Cm height);
    public ICpuCoolerBuilder SetSupportedSockets(ICollection<Socket> supportedSockets);
    public ICpuCoolerBuilder SetMaxDissipatedTdp(Watt maxDissipatedTdp);
    public ICpuCoolerBuilder SetName(string name);
    public ICpuCoolerBuilder ImportCpuCooler(CpuCooler cpuCooler);
    public CpuCooler Build();
}