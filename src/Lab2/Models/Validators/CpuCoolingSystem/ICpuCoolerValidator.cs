using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCoolingSystem;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface ICpuCoolerValidator
{
    public void CheckImportValid(CpuCooler cpuCooler);
}