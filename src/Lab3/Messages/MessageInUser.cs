using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class MessageInUser
{
    public MessageInUser(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (string.IsNullOrEmpty(message.Title))
            throw MessageException.InvalidTitleDataException();
        if (string.IsNullOrEmpty(message.Body))
            throw MessageException.InvalidBodyDataException();

        Message = message;
        IsMessageRead = false;
    }

    public Message Message { get; }
    public bool IsMessageRead { get; set; }
}