using Application.Application;

namespace Presentation.Commands;

public class CheckBalanceCommand : ICommand
{
    public string[] Execute(IAtmService atmService)
    {
        ArgumentNullException.ThrowIfNull(atmService);
        return atmService.CheckBalance();
    }
}