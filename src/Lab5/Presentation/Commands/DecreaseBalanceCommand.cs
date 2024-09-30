using Application.Application;

namespace Presentation.Commands;

public class DecreaseBalanceCommand : ICommand
{
    private int _amount;

    public DecreaseBalanceCommand(int amount)
    {
        _amount = amount;
    }

    public string[] Execute(IAtmService atmService)
    {
        ArgumentNullException.ThrowIfNull(atmService);
        return atmService.DecreaseBalance(_amount);
    }
}