using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;
using Presentation.Commands;

namespace Presentation.CommandHandlers;

public class CheckBalanceHandler : BaseHandler
{
    private const int Length = 2;
    public override ICommand? Handle(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length != Length)
            return Next?.Handle(args);

        if (args[0] == "Check" && args[1] == "balance")
            return new CheckBalanceCommand();
        else
            return Next?.Handle(args);
    }
}