using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Frames;

public class Frame
{
    private string _name;
    private List<FormFactor> _formFactors;
    private Cm _height;
    private Cm _width;
    private Cm _depth;
    public Frame(ICollection<FormFactor> formFactors, Cm height, Cm width, Cm depth, string name)
    {
        ArgumentNullException.ThrowIfNull(formFactors);
        ArgumentNullException.ThrowIfNull(height);
        ArgumentNullException.ThrowIfNull(width);
        ArgumentNullException.ThrowIfNull(depth);

        if (string.IsNullOrEmpty(name))
            throw FrameException.InvalidFrameName();

        _name = name;
        _formFactors = new List<FormFactor>();
        _formFactors.AddRange(formFactors);
        _height = height;
        _width = width;
        _depth = depth;
    }

    public Frame()
    {
        _name = string.Empty;
        _formFactors = new List<FormFactor>();
        _height = new Cm();
        _width = new Cm();
        _depth = new Cm();
    }

    public string Name => _name;
    public IReadOnlyCollection<FormFactor> Formats => _formFactors;

    public Cm Height => _height;

    public Cm Width => _width;

    public Cm Depth => _depth;
}