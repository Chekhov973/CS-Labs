using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class ProxyMessenger : IAddressee
{
    private const int LowestPriority = 2;
    private Messenger _messenger = new();

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (string.IsNullOrEmpty(message.Title))
            throw MessageException.InvalidTitleDataException();
        if (string.IsNullOrEmpty(message.Body))
            throw MessageException.InvalidBodyDataException();

        if (message.Priority < LowestPriority)
            return;

        Log(message);
        _messenger.ReceiveMessage(message);
    }

    public void Log(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (string.IsNullOrEmpty(message.Body))
            throw MessageException.InvalidBodyDataException();
        if (string.IsNullOrEmpty(message.Title))
            throw MessageException.InvalidTitleDataException();

        _messenger.Log(message);
    }
}