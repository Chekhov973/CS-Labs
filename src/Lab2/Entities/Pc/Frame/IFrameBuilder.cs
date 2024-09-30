using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Frames;

public interface IFrameBuilder
{
    public IFrameBuilder SetName(string name);
    public IFrameBuilder SetFormFactor(ICollection<FormFactor> formFactors);
    public IFrameBuilder SetHeight(Cm height);
    public IFrameBuilder SetWidth(Cm width);
    public IFrameBuilder SetDepth(Cm depth);
    public IFrameBuilder ImportFrame(Frame frame);
    public Frame Build();
}