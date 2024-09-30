using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class FilteringProxyUser : IAddressee
{
    private int _lowestPriority;
    private User _user = new User();
    private ILogger _logger = new Logger();

    public FilteringProxyUser(int lowerstPriority)
    {
        if (lowerstPriority < 1)
            throw MessageException.InvalidPriorityDataException();
        _lowestPriority = lowerstPriority;
    }

    public IUser User => _user;

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (string.IsNullOrEmpty(message.Body))
            throw MessageException.InvalidBodyDataException();
        if (string.IsNullOrEmpty(message.Title))
            throw MessageException.InvalidTitleDataException();

        if (message.Priority < _lowestPriority)
            return;

        Log(message);

        _user.ReceiveMessage(message);
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