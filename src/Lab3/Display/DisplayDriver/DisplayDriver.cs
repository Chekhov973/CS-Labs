using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;
public class DisplayDriver
{
    private Message? _message;
    private Color _color = Color.FromName("Blue");

    public Message? Message => _message;

    public void SaveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (string.IsNullOrEmpty(message.Body))
            throw MessageException.InvalidBodyDataException();

        _message = message;
    }

    public void WriteMessage()
    {
        if (_message is null)
            return;

        Console.WriteLine(Rgb(_color.R, _color.G, _color.B).Text(_message.Title));
        Console.WriteLine(Rgb(_color.R, _color.G, _color.B).Text(_message.Body));
        _message = null;
    }

    public void ChangeColor(string color)
    {
        if (string.IsNullOrEmpty(color))
            throw DisplayDriverException.InvalidColorNameException();

        _color = Color.FromName(color);
    }
}