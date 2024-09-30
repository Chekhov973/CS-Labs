namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IMessageBuilder
{
    public IMessageBuilder SetBody(string body);
    public IMessageBuilder SetTitle(string title);
    public IMessageBuilder SetPriority(int priority);
    public Message BuildMessage();
}