using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;
using Presentation.Commands;

namespace Presentation.CommandHandlers;

public class IncreaseBalanceHandler : BaseHandler
{
    private const int Length = 3;
    public override ICommand? Handle(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length != Length)
            return Next?.Handle(args);

        bool isNumber1 = int.TryParse(args[2], out int amount);
        if (args[0] == "Increase" && args[1] == "balance" && isNumber1)
            return new IncreaseBalanceCommand(amount);
        else
            return Next?.Handle(args);
    }
}