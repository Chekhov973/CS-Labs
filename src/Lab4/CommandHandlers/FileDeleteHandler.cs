using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public class FileDeleteHandler : BaseHandler
{
    private const int NeededLength = 3;
    public override ICommand? Handle(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length != NeededLength)
            return Next?.Handle(args);

        if (!(args[0] == "file" && args[1] == "delete" && !string.IsNullOrEmpty(args[2])))
        {
            return Next?.Handle(args);
        }
        else
        {
            return new FileDeleteCommand(args[2]);
        }
    }
}