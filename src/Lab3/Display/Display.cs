using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class Display : IAddressee
{
    private DisplayDriver _displayDriver = new DisplayDriver();
    private ILogger _logger = new Logger();

    public void Show()
    {
        if (_displayDriver.Message is null)
            return;

        _displayDriver.WriteMessage();
    }

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (string.IsNullOrEmpty(message.Body))
            throw MessageException.InvalidBodyDataException();
        if (string.IsNullOrEmpty(message.Title))
            throw MessageException.InvalidTitleDataException();

        Log(message);
        _displayDriver.SaveMessage(message);
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

    public void ChangeColor(string color)
    {
        if (string.IsNullOrEmpty(color))
            throw DisplayException.InvalidColorException();

        _displayDriver.ChangeColor(color);
    }
}