using Application.Application;
using Application.Contracts;
using Application.Repos;
using Infrastructure;
using Presentation;
using Presentation.CommandHandlers;

namespace Program;

public static class Program
{
    public static void Main()
    {
        IAccountRepository accountRepository = new AccountRepository("User ID=postgres;Password=postgres; Host=localhost; Port=6432; Database=postgres");
        ICurrentAccountService currentAccountService = new CurrentAccountManager();
        IAccountService accountService = new AccountService(accountRepository, currentAccountService);
        IAtmService atmService = new AtmService(accountRepository, accountService);

        IChainLink login = new LoginHandler();
        IChainLink checkBalance = new CheckBalanceHandler();
        IChainLink createAccount = new CreateAccountHandler();
        IChainLink decreaseBalance = new DecreaseBalanceHandler();
        IChainLink increaseBalance = new IncreaseBalanceHandler();
        IChainLink getTransactions = new GetTransactionsHandler();

        login.AddNext(checkBalance).AddNext(createAccount).AddNext(decreaseBalance).AddNext(increaseBalance)
            .AddNext(getTransactions);

        IConsoleInputOutput consoleInputOutput = new ConsoleInputOutput(login, atmService);

        while (true)
        {
            consoleInputOutput.HandleInput();
        }
    }
}