using Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IGpuValidator
{
    public void CheckImportValid(Gpu gpu);
}