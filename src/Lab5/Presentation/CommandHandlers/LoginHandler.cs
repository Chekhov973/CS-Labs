using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;
using Presentation.Commands;

namespace Presentation.CommandHandlers;

public class LoginHandler : BaseHandler
{
    private const int Length = 3;
    public override ICommand? Handle(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);
        if (args.Length != Length)
        {
            return Next?.Handle(args);
        }

        bool isNumber1 = int.TryParse(args[1], out int id);
        bool isNumber2 = int.TryParse(args[2], out int pin);
        if (args[0] == "Login" && isNumber1 && isNumber2)
            return new LoginCommand(id, pin);
        else
            return Next?.Handle(args);
    }
}