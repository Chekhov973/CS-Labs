using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IMotherboardValidator
{
    public void CheckImportValid(Motherboard motherboard);
}