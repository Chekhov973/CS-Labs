using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class TopicException : Exception
{
    private TopicException(string message)
        : base(message)
    {
    }

    private TopicException()
    {
    }

    private TopicException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static TopicException InvalidTopicNameException()
    {
        throw new TopicException($"Invalid topic name");
    }
}