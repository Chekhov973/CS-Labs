using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;

public interface IMotherboardBuilder
{
    public IMotherboardBuilder SetName(string name);
    public IMotherboardBuilder SetSocket(Socket socket);
    public IMotherboardBuilder SetPcieAmount(int pcieAmount);
    public IMotherboardBuilder SetSataAmount(int sataAmount);
    public IMotherboardBuilder SetChipset(Chipset chipset);
    public IMotherboardBuilder SetDdrVersion(Ddr ddrVersion);
    public IMotherboardBuilder SetMemPortAmount(int memPortAmount);
    public IMotherboardBuilder SetFormFactor(FormFactor formFactor);
    public IMotherboardBuilder SetBios(Bios bios);
    public IMotherboardBuilder ImportMotherboard(Motherboard motherboard);
    public Motherboard Build();
}