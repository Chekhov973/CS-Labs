using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public class TreeListHandler : BaseHandler
{
    private const int NeededLength = 4;
    public override ICommand? Handle(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length != NeededLength)
        {
            return Next?.Handle(args);
        }

        bool isNumber = int.TryParse(args[3], out int numericValue);
        if (!(args[0] == "tree" && args[1] == "list" && args[2] == "-d" && isNumber))
        {
            return Next?.Handle(args);
        }
        else
        {
            return new TreeListCommand(numericValue);
        }
    }
}