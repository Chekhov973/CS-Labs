using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public class FileCopyHandler : BaseHandler
{
    private const int NeededLength = 4;
    public override ICommand? Handle(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length != NeededLength)
            return Next?.Handle(args);

        if (!(args[0] == "file" && args[1] == "move" && !string.IsNullOrEmpty(args[2]) && !string.IsNullOrEmpty(args[3])))
        {
            return Next?.Handle(args);
        }
        else
        {
            return new FileCopyCommand(args[2], args[3]);
        }
    }
}