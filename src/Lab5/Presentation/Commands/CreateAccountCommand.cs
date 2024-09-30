using Application.Application;

namespace Presentation.Commands;

public class CreateAccountCommand : ICommand
{
    private int _pin;
    private int _balance;

    public CreateAccountCommand(int pin, int balance)
    {
        _pin = pin;
        _balance = balance;
    }

    public string[] Execute(IAtmService atmService)
    {
        ArgumentNullException.ThrowIfNull(atmService);
        return atmService.CreateAccount(_pin, _balance);
    }
}