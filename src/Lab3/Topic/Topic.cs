using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic
{
    public Topic(string name, IAddressee addressee)
    {
        if (string.IsNullOrEmpty(name))
            throw TopicException.InvalidTopicNameException();
        ArgumentNullException.ThrowIfNull(addressee);

        Name = name;
        Addressee = addressee;
    }

    public string Name { get; }
    public IAddressee Addressee { get; }

    public void Send(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (string.IsNullOrEmpty(message.Title))
            throw MessageException.InvalidTitleDataException();
        if (string.IsNullOrEmpty(message.Body))
            throw MessageException.InvalidBodyDataException();

        Addressee.ReceiveMessage(message);
    }
}