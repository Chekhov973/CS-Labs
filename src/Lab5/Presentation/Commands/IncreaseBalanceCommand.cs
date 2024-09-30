using Application.Application;

namespace Presentation.Commands;

public class IncreaseBalanceCommand : ICommand
{
    private int _amount;

    public IncreaseBalanceCommand(int amount)
    {
        _amount = amount;
    }

    public string[] Execute(IAtmService atmService)
    {
        ArgumentNullException.ThrowIfNull(atmService);
        return atmService.IncreaseBalance(_amount);
    }
}