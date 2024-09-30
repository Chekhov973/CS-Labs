using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public class DisconnectHandler : BaseHandler
{
    private const int NeededLength = 1;
    public override ICommand? Handle(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length != NeededLength)
            return Next?.Handle(args);

        if (args[0] != "disconnect")
        {
            return Next?.Handle(args);
        }
        else
        {
            return new DisconnectCommand();
        }
    }
}