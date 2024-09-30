using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MockProxyMessenger : IAddressee
{
    private int _lowestPriority;

    public MockProxyMessenger(int lowestPriority)
    {
        _lowestPriority = lowestPriority;
    }

    public int Calls { get; private set; }
    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (message.Priority < _lowestPriority)
            return;
        Log(message);
    }

    public string Log(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        Calls++;

        string result = "messenger: " + message.Body;
        return result;
    }
}