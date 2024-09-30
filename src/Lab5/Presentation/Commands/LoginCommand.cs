using Application.Application;

namespace Presentation.Commands;

public class LoginCommand : ICommand
{
    private int _id;
    private int _pin;
    public LoginCommand(int id, int pin)
    {
        _id = id;
        _pin = pin;
    }

    public string[] Execute(IAtmService atmService)
    {
        ArgumentNullException.ThrowIfNull(atmService);
        return atmService.Login(_id, _pin);
    }
}