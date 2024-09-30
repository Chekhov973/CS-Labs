using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public class TreeGoToHandler : BaseHandler
{
    private const int NeededLength = 3;
    public override ICommand? Handle(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length != NeededLength)
            return Next?.Handle(args);

        if (!(args[0] == "tree" && args[1] == "goto" && !string.IsNullOrEmpty(args[2])))
        {
           return Next?.Handle(args);
        }

        return new TreeGoToCommand(args[2]);
    }
}