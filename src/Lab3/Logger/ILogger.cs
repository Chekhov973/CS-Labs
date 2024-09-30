using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public interface ILogger
{
    public void LogMessage(Message message);
}