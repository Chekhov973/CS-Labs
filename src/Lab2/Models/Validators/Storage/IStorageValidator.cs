using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IStorageValidator
{
    public void CheckSsdImportValid(Ssd ssd);
    public void CheckHddImportValid(Hdd hdd);
}