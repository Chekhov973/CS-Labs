using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class FrameException : Exception
{
    private FrameException(string message)
        : base(message)
    {
    }

    private FrameException()
    {
    }

    private FrameException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static FrameException NotAllAttributesAreSetException()
    {
        throw new FrameException($"Building is impossible: not all attributes are set");
    }

    public static FrameException InvalidFormatData()
    {
        throw new FrameException($"Invalid format data");
    }

    public static FrameException InvalidFrameName()
    {
        throw new FrameException($"invalid frame name");
    }
}