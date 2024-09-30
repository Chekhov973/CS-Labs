using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public class ConnectHandler : BaseHandler
{
    private const int NeededLength = 4;
    public override ICommand? Handle(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length != NeededLength)
            return Next?.Handle(args);

        if (args[0] == "connect")
        {
            return new ConnectCommand(args[1], args[3]);
        }

        return Next?.Handle(args);
    }
}