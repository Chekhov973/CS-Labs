using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Frames;

public class FrameBuilder : IFrameBuilder
{
    private IFrameValidator _frameValidator = new FrameValidator();
    private string _name = string.Empty;
    private List<FormFactor> _formFactors = new List<FormFactor>();
    private Cm _height = new Cm();
    private Cm _width = new Cm();
    private Cm _depth = new Cm();

    public IFrameBuilder SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw FrameException.InvalidFrameName();

        _name = name;
        return this;
    }

    public IFrameBuilder SetFormFactor(ICollection<FormFactor> formFactors)
    {
        ArgumentNullException.ThrowIfNull(formFactors);

        _formFactors.AddRange(formFactors);
        return this;
    }

    public IFrameBuilder SetHeight(Cm height)
    {
        ArgumentNullException.ThrowIfNull(height);

        _height = height;
        return this;
    }

    public IFrameBuilder SetWidth(Cm width)
    {
        ArgumentNullException.ThrowIfNull(width);

        _width = width;
        return this;
    }

    public IFrameBuilder SetDepth(Cm depth)
    {
        ArgumentNullException.ThrowIfNull(depth);

        _depth = depth;
        return this;
    }

    public IFrameBuilder ImportFrame(Frame frame)
    {
        ArgumentNullException.ThrowIfNull(frame);
        _frameValidator.CheckImportValid(frame);

        _name = frame.Name;
        _height = frame.Height;
        _depth = frame.Depth;
        _width = frame.Depth;

        if (_formFactors.Count > 0)
            throw FrameException.InvalidFormatData();

        _formFactors.AddRange(frame.Formats);

        return this;
    }

    public Frame Build()
    {
        if (_formFactors.Count == 0 || _depth.Centimetre == 0 || _width.Centimetre == 0 || _height.Centimetre == 0 || string.IsNullOrEmpty(_name))
            throw FrameException.NotAllAttributesAreSetException();

        return new Frame(_formFactors, _height, _width, _depth, _name);
    }
}