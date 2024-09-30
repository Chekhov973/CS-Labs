using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IAddressee, IUser
{
    private List<MessageInUser> _messages;

    public User()
    {
        _messages = new List<MessageInUser>();
    }

    public IReadOnlyCollection<MessageInUser> Messages => _messages;
    public void ReadMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        MessageInUser? founded = _messages.FirstOrDefault(x => x.Message.Equals(message));

        if (founded is null)
            throw UserException.MessagesListDoesNotContainThisMessage();

        if (founded.IsMessageRead)
            throw UserException.MessageUsAlreadyRead();

        _messages.First(x => x.Message.Id.Equals(message.Id)).IsMessageRead = true;
    }

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (string.IsNullOrEmpty(message.Body))
            throw MessageException.InvalidBodyDataException();
        if (string.IsNullOrEmpty(message.Title))
            throw MessageException.InvalidTitleDataException();

        var messageInUser = new MessageInUser(message);

        _messages.Add(messageInUser);
    }
}