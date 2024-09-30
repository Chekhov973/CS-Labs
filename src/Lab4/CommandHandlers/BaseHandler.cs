using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public abstract class BaseHandler : IChainLink
{
    private IChainLink? _next;
    public IChainLink? Next => _next;

    public IChainLink AddNext(IChainLink link)
    {
        ArgumentNullException.ThrowIfNull(link);

        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    public abstract ICommand? Handle(string[] args);
}