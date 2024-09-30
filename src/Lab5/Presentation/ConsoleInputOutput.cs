using Application.Application;
using Presentation.Commands;

namespace Presentation;

public class ConsoleInputOutput : IConsoleInputOutput
{
    private IChainLink _login;
    private IAtmService _atmService;

    public ConsoleInputOutput(IChainLink login, IAtmService atmService)
    {
        _login = login;
        _atmService = atmService;
    }

    public void HandleInput()
    {
        string read = Console.ReadLine() ?? throw new InvalidOperationException();
        string[] arguments = read.Split(' ');

        ArgumentNullException.ThrowIfNull(arguments);
        ICommand? command = _login.Handle(arguments);
        if (command is null)
        {
            Console.WriteLine($"Unable to handle");
        }
        else
        {
            string[]? output = command.Execute(_atmService);

            ArgumentNullException.ThrowIfNull(output);

            foreach (string o in output)
            {
                Console.WriteLine(o);
            }
        }
    }
}