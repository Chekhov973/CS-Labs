using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;
using Presentation.Commands;

namespace Presentation.CommandHandlers;

public class GetTransactionsHandler : BaseHandler
{
    private const int Length = 2;
    public override ICommand? Handle(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length != Length)
            return Next?.Handle(args);

        if (args[0] == "Get" && args[1] == "transactions")
            return new GetTransactionsCommand();
        else
            return Next?.Handle(args);
    }
}