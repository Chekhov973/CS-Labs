using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public interface IAddressee
{
    public void ReceiveMessage(Message message);
}