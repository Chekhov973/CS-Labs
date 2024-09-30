using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Frames;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class FrameValidator : IFrameValidator
{
    public void CheckImportValid(Frame frame)
    {
        ArgumentNullException.ThrowIfNull(frame);
        ArgumentNullException.ThrowIfNull(frame.Depth);
        ArgumentNullException.ThrowIfNull(frame.Height);
        ArgumentNullException.ThrowIfNull(frame.Formats);
        ArgumentNullException.ThrowIfNull(frame.Width);

        if (frame.Formats.Count == 0)
            throw FrameException.InvalidFormatData();

        if (string.IsNullOrEmpty(frame.Name))
            throw FrameException.InvalidFrameName();
    }
}