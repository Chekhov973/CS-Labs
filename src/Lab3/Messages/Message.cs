using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public record class Message(string Title, string Body, int Priority, Guid Id)
{
    public string Title { get; } = Title;
    public string Body { get; } = Body;
    public int Priority { get; } = Priority;
    public Guid Id { get; } = Id;
}