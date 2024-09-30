using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;

public class Socket
{
    private string _socketName;

    public Socket(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw SocketException.InvalidSocketNameException(name);

        _socketName = name;
    }

    public Socket()
    {
        _socketName = string.Empty;
    }

    public string SocketName => _socketName;
}