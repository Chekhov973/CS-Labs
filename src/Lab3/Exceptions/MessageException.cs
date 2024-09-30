using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class MessageException : Exception
{
    private MessageException(string message)
        : base(message)
    {
    }

    private MessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private MessageException()
    {
    }

    public static MessageException InvalidTitleDataException()
    {
        throw new MessageException($"Invalid title data");
    }

    public static MessageException InvalidBodyDataException()
    {
        throw new MessageException($"Invalid body data");
    }

    public static MessageException InvalidPriorityDataException()
    {
        throw new MessageException($"Invalid priority data");
    }

    public static MessageException UnableToBuildMessage()
    {
        throw new MessageException($"Unable to build message");
    }
}