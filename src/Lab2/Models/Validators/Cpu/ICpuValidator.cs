using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface ICpuValidator
{
    public void CheckImportValid(Cpu cpu);
}