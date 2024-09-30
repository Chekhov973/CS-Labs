using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

public class Cpu
{
   private string _name;
   private int _coreQuantity;
   private Hz _coreFrequency;
   private Socket _socket;
   private bool _isIntegratedGraphics;
   private List<Hz> _supportedFrequencies;
   private Watt _tdp;
   private Watt _powerConsumption;

   public Cpu(string name, int coreQuantity, Hz coreFrequency, bool isIntegratedGraphics, Socket socket, ICollection<Hz> supportedFrequencies, Watt tdp, Watt powerConsumption)
   {
      if (string.IsNullOrEmpty(name))
         throw CpuException.InvalidCpuNameException();

      ArgumentNullException.ThrowIfNull(coreFrequency);
      ArgumentNullException.ThrowIfNull(tdp);
      ArgumentNullException.ThrowIfNull(powerConsumption);
      ArgumentNullException.ThrowIfNull(socket);
      ArgumentNullException.ThrowIfNull(supportedFrequencies);

      _name = name;
      _coreQuantity = coreQuantity;
      _coreFrequency = coreFrequency;
      _socket = socket;
      _supportedFrequencies = new List<Hz>();
      _supportedFrequencies.AddRange(supportedFrequencies);
      _tdp = tdp;
      _powerConsumption = powerConsumption;
      _isIntegratedGraphics = isIntegratedGraphics;
   }

   public Cpu()
   {
      _name = string.Empty;
      _coreQuantity = 0;
      _coreFrequency = new Hz();
      _socket = new Socket();
      _supportedFrequencies = new List<Hz>();
      _tdp = new Watt();
      _powerConsumption = new Watt();
   }

   public string Name => _name;
   public int CoreQuantity => _coreQuantity;
   public Hz CoreFrequency => _coreFrequency;
   public Socket Socket => _socket;
   public bool IsIntegratedGraphics => _isIntegratedGraphics;
   public IReadOnlyCollection<Hz> SupportedFrequencies => _supportedFrequencies;
   public Watt Tdp => _tdp;
   public Watt PowerConsumption => _powerConsumption;
}