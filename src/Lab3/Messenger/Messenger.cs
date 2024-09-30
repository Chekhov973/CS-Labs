using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class Messenger : IAddressee
{
    private ILogger _logger = new Logger();
    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (string.IsNullOrEmpty(message.Title))
            throw MessageException.InvalidTitleDataException();
        if (string.IsNullOrEmpty(message.Body))
            throw MessageException.InvalidBodyDataException();

        Log(message);
        Console.WriteLine($"messenger: " + message.Body);
    }

    public void Log(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (string.IsNullOrEmpty(message.Body))
            throw MessageException.InvalidBodyDataException();
        if (string.IsNullOrEmpty(message.Title))
            throw MessageException.InvalidTitleDataException();

        _logger.LogMessage(message);
    }
}