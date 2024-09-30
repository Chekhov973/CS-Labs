using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Group;

public class Group : IAddressee
{
    private ICollection<IAddressee> _addressees = new List<IAddressee>();
    private ILogger _logger = new Logger();
    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (string.IsNullOrEmpty(message.Body))
            throw MessageException.InvalidBodyDataException();
        if (string.IsNullOrEmpty(message.ToString()))
            throw MessageException.InvalidTitleDataException();
        if (message.Priority < 1)
            throw MessageException.InvalidPriorityDataException();

        foreach (IAddressee addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }

        Log(message);
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

    public void AddAdress(IAddressee addressee)
    {
        ArgumentNullException.ThrowIfNull(addressee);

        _addressees.Add(addressee);
    }

    public void RemoveAdress(IAddressee addressee)
    {
        ArgumentNullException.ThrowIfNull(_addressees);

        if (!_addressees.Contains(addressee))
            throw GroupException.NoAdressInList();

        _addressees.Remove(addressee);
    }
}