using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;
using Presentation.Commands;

namespace Presentation.CommandHandlers;

public class CreateAccountHandler : BaseHandler
{
    private const int Length = 4;
    public override ICommand? Handle(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length != Length)
            return Next?.Handle(args);

        bool isNumber1 = int.TryParse(args[2], out int pin);
        bool isNumber2 = int.TryParse(args[3], out int balance);

        if (args[0] == "Create" && args[1] == "account" && isNumber1 && isNumber2)
            return new CreateAccountCommand(pin, balance);
        else
            return Next?.Handle(args);
    }
}