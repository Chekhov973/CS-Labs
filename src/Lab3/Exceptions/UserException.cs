using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class UserException : Exception
{
    private UserException(string message)
        : base(message)
    {
    }

    private UserException()
    {
    }

    private UserException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static UserException UnreadListOfMessagesIsEmpty()
    {
        throw new UserException($"Unread list of messages is empty");
    }

    public static UserException MessagesListDoesNotContainThisMessage()
    {
        throw new UserException($"Messages list does not contain this message");
    }

    public static UserException MessageUsAlreadyRead()
    {
        throw new UserException($"Message is already read");
    }
}