using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public interface IRamBuilder
{
    IRamBuilder SetName(string name);
    IRamBuilder SetXmpProfiles(ICollection<Xmp> xmps);
    IRamBuilder SetRamFormFactor(RamFormFactor ramFormFactor);
    IRamBuilder SetDdr(Ddr ddr);
    IRamBuilder SetGbValue(Gb gb);
    IRamBuilder SetPowerConsumption(Watt watt);
    IRamBuilder ImportRam(Ram ram);
    Ram Build();
}