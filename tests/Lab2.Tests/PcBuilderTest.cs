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
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.PcBuilder;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;
public class PcBuilderTest
{
    public static IEnumerable<object[]> GetValidPcModels()
    {
        yield return new object[]
        {
            new Socket("AM4"), // cpu
            new List<Hz>()
            {
                new Hz(100),
            },
            new FormFactor("ATX"),
            new List<Socket>() // cpu cooler
            {
                new Socket("AM4"),
            },
            new List<FormFactor>() // frame
            {
                new FormFactor("ATX"),
            },
            new List<Xmp> // ram
            {
                new Xmp("19-19-19-19", new XmpRegexValidator(), new Hz(100)),
            },
        };
    }

    public static IEnumerable<object[]> GetInvalidPcModels()
    {
        yield return new object[]
        {
            new Socket("AM4"), // cpu
            new Socket("LGA-1150"),
            new List<Hz>()
            {
                new Hz(100),
            },
            new FormFactor("ATX"),
            new List<Socket>() // cpu cooler
            {
                new Socket("AM4"),
            },
            new List<FormFactor>() // frame
            {
                new FormFactor("ATX"),
            },
            new List<Xmp> // ram
            {
                new Xmp("19-19-19-19", new XmpRegexValidator(), new Hz(100)),
            },
        };
    }

    [Theory]
    [MemberData(nameof(GetValidPcModels))]
    public void CompatiblePcBuild(
        Socket socket, ICollection<Hz> supportedFrequencies, FormFactor formFactor, ICollection<Socket> supportedSockets, ICollection<FormFactor> formFactors, ICollection<Xmp> supportedXmps)
    {
        ICpuBuilder cpuBuilder = new CpuBuilder();
        IMotherboardBuilder motherboardBuilder = new MotherboardBuilder();
        ICpuCoolerBuilder cpuCoolerBuilder = new CpuCoolerBuilder();
        IFrameBuilder frameBuilder = new FrameBuilder();
        IGpuBuilder gpuBuilder = new GpuBuilder();
        IPowersupplyBuilder powerSupplyBuilder = new PowerSupplyBuilder();
        IRamBuilder ramBuilder = new RamBuilder();
        IStorageBuilder storageBuilder = new StorageBuilder();
        IPcBuilder pcBuilder = new PcBuilder();
        IWifiAdapterBuilder wifiAdapterBuilder = new WifiAdapterBuilder();

        Cpu cpu = cpuBuilder.SetName("i5-9400f").SetSocket(socket).SetCoreFrequency(new Hz(100)).SetCoreQuantity(6)
            .SetSupportedFrequencies(supportedFrequencies).SetTdp(new Watt(10)).SetIntegratedGraphics(false)
            .SetPowerConsumption(new Watt(10)).Build();

        var supportedCpus = new List<string>() { "i5-9400f" };
        var bios = new Bios(supportedCpus, "Bios", 4);
        Motherboard motherboard = motherboardBuilder.SetSocket(socket).SetName("Gigabyte Z390").SetBios(bios)
            .SetChipset(new Chipset(supportedFrequencies)).SetFormFactor(formFactor).SetDdrVersion(new Ddr(4)).SetPcieAmount(2).SetSataAmount(4)
            .SetMemPortAmount(4).Build();

        CpuCooler cpuCooler = cpuCoolerBuilder.SetName("Mega Cooler").SetHeight(new Cm(5))
            .SetSupportedSockets(supportedSockets).SetMaxDissipatedTdp(new Watt(200)).Build();
        Frame frame = frameBuilder.SetName("Giga frame").SetHeight(new Cm(1000)).SetWidth(new Cm(1000))
            .SetDepth(new Cm(1000)).SetFormFactor(formFactors).Build();

        Gpu gpu = gpuBuilder.SetName("Rtx-9999").SetHeight(new Cm(10)).SetLength(new Cm(10))
            .SetCoreFrequency(new Hz(1000)).SetPowerConsumption(new Watt(10)).SetPcie(new Pcie(4))
            .SetVideoMemory(new Gb(12)).Build();

        PowerSupply powerSupply = powerSupplyBuilder.SetName("Giga block").SetMaxPower(new Watt(1000)).Build();

        Ram ram = ramBuilder.SetName("Giga pamyat").SetPowerConsumption(new Watt(10)).SetDdr(new Ddr(4))
            .SetGbValue(new Gb(16)).SetXmpProfiles(supportedXmps).SetRamFormFactor(new RamFormFactor("DiMM")).Build();
        var rams = new List<Ram> { ram };

        Ssd ssd = storageBuilder.SetGbValue(new Gb(512)).SetPowerConsumption(new Watt(5)).SetConnectionType(new Pcie(4))
            .SetReadingSpeed(new Mbps(1000)).BuildSsd();

        WifiAdapter wifiAdapter = wifiAdapterBuilder.SetPcie(new Pcie(4)).SetPowerConsumption(new Watt(5))
            .SetBluetoothModule(false).SetWifiModule(new WifiModule("Mega Wifi")).Build();

        Pc pc = pcBuilder.SetFrame(frame).SetPowerSupply(powerSupply).SetMotherboard(motherboard).SetCpu(cpu).SetCpuCooler(cpuCooler).SetGpu(gpu)
            .SetRam(rams).SetSsd(ssd).SetWifiAdapter(wifiAdapter).Build();

        Assert.NotNull(pc);
    }

    [Theory]
    [MemberData(nameof(GetValidPcModels))]
    public void NotEnoughPower(Socket socket, ICollection<Hz> supportedFrequencies, FormFactor formFactor, ICollection<Socket> supportedSockets, ICollection<FormFactor> formFactors, ICollection<Xmp> supportedXmps)
    {
        ICpuBuilder cpuBuilder = new CpuBuilder();
        IMotherboardBuilder motherboardBuilder = new MotherboardBuilder();
        ICpuCoolerBuilder cpuCoolerBuilder = new CpuCoolerBuilder();
        IFrameBuilder frameBuilder = new FrameBuilder();
        IGpuBuilder gpuBuilder = new GpuBuilder();
        IPowersupplyBuilder powerSupplyBuilder = new PowerSupplyBuilder();
        IRamBuilder ramBuilder = new RamBuilder();
        IStorageBuilder storageBuilder = new StorageBuilder();
        IPcBuilder pcBuilder = new PcBuilder();
        IWifiAdapterBuilder wifiAdapterBuilder = new WifiAdapterBuilder();

        Cpu cpu = cpuBuilder.SetName("i5-9400f").SetSocket(socket).SetCoreFrequency(new Hz(100)).SetCoreQuantity(6)
            .SetSupportedFrequencies(supportedFrequencies).SetTdp(new Watt(10)).SetIntegratedGraphics(false)
            .SetPowerConsumption(new Watt(10)).Build();

        var supportedCpus = new List<string>() { "i5-9400f" };
        var bios = new Bios(supportedCpus, "Bios", 4);
        Motherboard motherboard = motherboardBuilder.SetSocket(socket).SetName("Gigabyte Z390").SetBios(bios)
            .SetChipset(new Chipset(supportedFrequencies)).SetFormFactor(formFactor).SetDdrVersion(new Ddr(4)).SetPcieAmount(2).SetSataAmount(4)
            .SetMemPortAmount(4).Build();

        CpuCooler cpuCooler = cpuCoolerBuilder.SetName("Mega Cooler").SetHeight(new Cm(5))
            .SetSupportedSockets(supportedSockets).SetMaxDissipatedTdp(new Watt(200)).Build();
        Frame frame = frameBuilder.SetName("Giga frame").SetHeight(new Cm(1000)).SetWidth(new Cm(1000))
            .SetDepth(new Cm(1000)).SetFormFactor(formFactors).Build();

        Gpu gpu = gpuBuilder.SetName("Rtx-9999").SetHeight(new Cm(10)).SetLength(new Cm(10))
            .SetCoreFrequency(new Hz(1000)).SetPowerConsumption(new Watt(10)).SetPcie(new Pcie(4))
            .SetVideoMemory(new Gb(12)).Build();

        PowerSupply powerSupply = powerSupplyBuilder.SetName("Giga block").SetMaxPower(new Watt(15)).Build(); // not enough power supply power for test

        Ram ram = ramBuilder.SetName("Giga pamyat").SetPowerConsumption(new Watt(10)).SetDdr(new Ddr(4))
            .SetGbValue(new Gb(16)).SetXmpProfiles(supportedXmps).SetRamFormFactor(new RamFormFactor("DiMM")).Build();
        var rams = new List<Ram> { ram };

        Ssd ssd = storageBuilder.SetGbValue(new Gb(512)).SetPowerConsumption(new Watt(5)).SetConnectionType(new Pcie(4))
            .SetReadingSpeed(new Mbps(1000)).BuildSsd();

        WifiAdapter wifiAdapter = wifiAdapterBuilder.SetPcie(new Pcie(4)).SetPowerConsumption(new Watt(5))
            .SetBluetoothModule(false).SetWifiModule(new WifiModule("Mega Wifi")).Build();

        PcBuilderException exception = Assert.Throws<PcBuilderException>(() =>
        {
            Pc pc = pcBuilder.SetFrame(frame).SetPowerSupply(powerSupply).SetMotherboard(motherboard).SetCpu(cpu)
                .SetCpuCooler(cpuCooler).SetGpu(gpu)
                .SetRam(rams).SetSsd(ssd).SetWifiAdapter(wifiAdapter).Build();
        });
        Assert.Equal($"Not enough max power of power supply: power supply max power 15, needed 35", exception.Message);
    }

    [Theory]
    [MemberData(nameof(GetValidPcModels))]
    public void CompatibleCoolerAndCpuButNotEnoughDissipatedTdp(Socket socket, ICollection<Hz> supportedFrequencies, FormFactor formFactor, ICollection<Socket> supportedSockets, ICollection<FormFactor> formFactors, ICollection<Xmp> supportedXmps)
    {
        ICpuBuilder cpuBuilder = new CpuBuilder();
        IMotherboardBuilder motherboardBuilder = new MotherboardBuilder();
        ICpuCoolerBuilder cpuCoolerBuilder = new CpuCoolerBuilder();
        IFrameBuilder frameBuilder = new FrameBuilder();
        IGpuBuilder gpuBuilder = new GpuBuilder();
        IPowersupplyBuilder powerSupplyBuilder = new PowerSupplyBuilder();
        IRamBuilder ramBuilder = new RamBuilder();
        IStorageBuilder storageBuilder = new StorageBuilder();
        IPcBuilder pcBuilder = new PcBuilder();
        IWifiAdapterBuilder wifiAdapterBuilder = new WifiAdapterBuilder();

        Cpu cpu = cpuBuilder.SetName("i5-9400f").SetSocket(socket).SetCoreFrequency(new Hz(100)).SetCoreQuantity(6)
            .SetSupportedFrequencies(supportedFrequencies).SetTdp(new Watt(10)).SetIntegratedGraphics(false)
            .SetPowerConsumption(new Watt(10)).Build();

        var supportedCpus = new List<string>() { "i5-9400f" };
        var bios = new Bios(supportedCpus, "Bios", 4);
        Motherboard motherboard = motherboardBuilder.SetSocket(socket).SetName("Gigabyte Z390").SetBios(bios)
            .SetChipset(new Chipset(supportedFrequencies)).SetFormFactor(formFactor).SetDdrVersion(new Ddr(4)).SetPcieAmount(2).SetSataAmount(4)
            .SetMemPortAmount(4).Build();

        CpuCooler cpuCooler = cpuCoolerBuilder.SetName("Mega Cooler").SetHeight(new Cm(5))
            .SetSupportedSockets(supportedSockets).SetMaxDissipatedTdp(new Watt(1)).Build(); // Invalid max dissipated tdp value for test
        Frame frame = frameBuilder.SetName("Giga frame").SetHeight(new Cm(1000)).SetWidth(new Cm(1000))
            .SetDepth(new Cm(1000)).SetFormFactor(formFactors).Build();

        Gpu gpu = gpuBuilder.SetName("Rtx-9999").SetHeight(new Cm(10)).SetLength(new Cm(10))
            .SetCoreFrequency(new Hz(1000)).SetPowerConsumption(new Watt(10)).SetPcie(new Pcie(4))
            .SetVideoMemory(new Gb(12)).Build();

        PowerSupply powerSupply = powerSupplyBuilder.SetName("Giga block").SetMaxPower(new Watt(100)).Build();

        Ram ram = ramBuilder.SetName("Giga pamyat").SetPowerConsumption(new Watt(10)).SetDdr(new Ddr(4))
            .SetGbValue(new Gb(16)).SetXmpProfiles(supportedXmps).SetRamFormFactor(new RamFormFactor("DiMM")).Build();
        var rams = new List<Ram> { ram };

        Ssd ssd = storageBuilder.SetGbValue(new Gb(512)).SetPowerConsumption(new Watt(5)).SetConnectionType(new Pcie(4))
            .SetReadingSpeed(new Mbps(1000)).BuildSsd();

        WifiAdapter wifiAdapter = wifiAdapterBuilder.SetPcie(new Pcie(4)).SetPowerConsumption(new Watt(5))
            .SetBluetoothModule(false).SetWifiModule(new WifiModule("Mega Wifi")).Build();

        PcBuilderException exception = Assert.Throws<PcBuilderException>(() =>
        {
            Pc pc = pcBuilder.SetFrame(frame).SetPowerSupply(powerSupply).SetMotherboard(motherboard).SetCpu(cpu)
                .SetCpuCooler(cpuCooler).SetGpu(gpu)
                .SetRam(rams).SetSsd(ssd).SetWifiAdapter(wifiAdapter).Build();
        });
        Assert.Equal("Not enough cooler dissipated tdp", exception.Message);
    }

    [Theory]
    [MemberData(nameof(GetInvalidPcModels))]
    public void IncompatibleComponentsExceptionCaught(Socket socket, Socket invalidSocket, ICollection<Hz> supportedFrequencies, FormFactor formFactor, ICollection<Socket> supportedSockets, ICollection<FormFactor> formFactors, ICollection<Xmp> supportedXmps)
    {
        ICpuBuilder cpuBuilder = new CpuBuilder();
        IMotherboardBuilder motherboardBuilder = new MotherboardBuilder();
        ICpuCoolerBuilder cpuCoolerBuilder = new CpuCoolerBuilder();
        IFrameBuilder frameBuilder = new FrameBuilder();
        IGpuBuilder gpuBuilder = new GpuBuilder();
        IPowersupplyBuilder powerSupplyBuilder = new PowerSupplyBuilder();
        IRamBuilder ramBuilder = new RamBuilder();
        IStorageBuilder storageBuilder = new StorageBuilder();
        IPcBuilder pcBuilder = new PcBuilder();
        IWifiAdapterBuilder wifiAdapterBuilder = new WifiAdapterBuilder();

        Cpu cpu = cpuBuilder.SetName("i5-9400f").SetSocket(socket).SetCoreFrequency(new Hz(100)).SetCoreQuantity(6)
            .SetSupportedFrequencies(supportedFrequencies).SetTdp(new Watt(10)).SetIntegratedGraphics(false)
            .SetPowerConsumption(new Watt(10)).Build();

        var supportedCpus = new List<string>() { "i5-9400f" };
        var bios = new Bios(supportedCpus, "Bios", 4);
        Motherboard motherboard = motherboardBuilder.SetSocket(invalidSocket).SetName("Gigabyte Z390").SetBios(bios)
            .SetChipset(new Chipset(supportedFrequencies)).SetFormFactor(formFactor).SetDdrVersion(new Ddr(4)).SetPcieAmount(2).SetSataAmount(4)
            .SetMemPortAmount(4).Build();

        CpuCooler cpuCooler = cpuCoolerBuilder.SetName("Mega Cooler").SetHeight(new Cm(5))
            .SetSupportedSockets(supportedSockets).SetMaxDissipatedTdp(new Watt(1)).Build(); // Invalid max dissipated tdp value for test
        Frame frame = frameBuilder.SetName("Giga frame").SetHeight(new Cm(1000)).SetWidth(new Cm(1000))
            .SetDepth(new Cm(1000)).SetFormFactor(formFactors).Build();

        Gpu gpu = gpuBuilder.SetName("Rtx-9999").SetHeight(new Cm(10)).SetLength(new Cm(10))
            .SetCoreFrequency(new Hz(1000)).SetPowerConsumption(new Watt(10)).SetPcie(new Pcie(4))
            .SetVideoMemory(new Gb(12)).Build();

        PowerSupply powerSupply = powerSupplyBuilder.SetName("Giga block").SetMaxPower(new Watt(100)).Build();

        Ram ram = ramBuilder.SetName("Giga pamyat").SetPowerConsumption(new Watt(10)).SetDdr(new Ddr(4))
            .SetGbValue(new Gb(16)).SetXmpProfiles(supportedXmps).SetRamFormFactor(new RamFormFactor("DiMM")).Build();
        var rams = new List<Ram> { ram };

        Ssd ssd = storageBuilder.SetGbValue(new Gb(512)).SetPowerConsumption(new Watt(5)).SetConnectionType(new Pcie(4))
            .SetReadingSpeed(new Mbps(1000)).BuildSsd();

        WifiAdapter wifiAdapter = wifiAdapterBuilder.SetPcie(new Pcie(4)).SetPowerConsumption(new Watt(5))
            .SetBluetoothModule(false).SetWifiModule(new WifiModule("Mega Wifi")).Build();

        PcBuilderException exception = Assert.Throws<PcBuilderException>(() =>
        {
            Pc pc = pcBuilder.SetFrame(frame).SetPowerSupply(powerSupply).SetMotherboard(motherboard).SetCpu(cpu)
                .SetCpuCooler(cpuCooler).SetGpu(gpu)
                .SetRam(rams).SetSsd(ssd).SetWifiAdapter(wifiAdapter).Build();
        });
        Assert.Equal("Cpu and motherboard sockets are incompatible: CPU socket : AM4, Motherboard socket : LGA-1150", exception.Message);
    }
}