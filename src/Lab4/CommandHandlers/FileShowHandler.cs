using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public class FileShowHandler : BaseHandler
{
    private const int NeededLength = 4;
    public override ICommand? Handle(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length != NeededLength)
            return Next?.Handle(args);

        if (!(args[0] == "file" && args[1] == "show" && !string.IsNullOrEmpty(args[2]) && args[3].StartsWith('-') &&
            !string.IsNullOrEmpty(args[4])))
        {
            return Next?.Handle(args);
        }
        else
        {
            return new FileShowCommand(args[2]);
        }
    }
}