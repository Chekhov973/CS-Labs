using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public interface IUser
{
    public IReadOnlyCollection<MessageInUser> Messages { get; }
    public void ReadMessage(Message message);
}