using Application.Application;

namespace Presentation.Commands;

public class GetTransactionsCommand : ICommand
{
    public string[] Execute(IAtmService atmService)
    {
        ArgumentNullException.ThrowIfNull(atmService);
        return atmService.GetTransactions();
    }
}