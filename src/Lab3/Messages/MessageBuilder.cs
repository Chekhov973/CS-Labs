using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class MessageBuilder : IMessageBuilder
{
    private string _body = string.Empty;
    private string _title = string.Empty;
    private int _priority;
    private Guid _id = new Guid(1, 2, 3, new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 });

    public IMessageBuilder SetBody(string body)
    {
        if (string.IsNullOrEmpty(body))
            throw MessageException.InvalidBodyDataException();

        _body = body;
        return this;
    }

    public IMessageBuilder SetTitle(string title)
    {
        if (string.IsNullOrEmpty(title))
            throw MessageException.InvalidTitleDataException();

        _title = title;
        return this;
    }

    public IMessageBuilder SetPriority(int priority)
    {
        if (priority < 1)
            throw MessageException.InvalidPriorityDataException();

        _priority = priority;
        return this;
    }

    public Message BuildMessage()
    {
        if (string.IsNullOrEmpty(_body) || string.IsNullOrEmpty(_title) || _priority < 1)
            throw MessageException.UnableToBuildMessage();

        return new Message(_title, _body, _priority, _id);
    }
}