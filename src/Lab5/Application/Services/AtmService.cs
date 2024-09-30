using Application.Contracts;
using Application.Repos;

namespace Application.Application;

public class AtmService : IAtmService
{
    private const int OutputLength = 1;
    private const int Index = 0;
    private readonly AdminConfig _adminConfig = new AdminConfig();
    private readonly IAccountRepository _accountRepository;
    private IAccountService _accountService;
    private ICurrentAccountService _currentAccount = new CurrentAccountManager();

    public AtmService(IAccountRepository accountRepository, IAccountService accountService)
    {
        ArgumentNullException.ThrowIfNull(accountRepository);

        _accountRepository = accountRepository;
        _accountService = accountService;
    }

    public string[] Login(int id, int pin)
    {
        Account? account = FindAccountById(id);
        string[] output = new string[OutputLength];
        if (account is not null)
        {
            LoginResult loginResult = _accountService.Login(id, pin);

            if (loginResult == LoginResult.Success)
            {
                _currentAccount.Account = account;
                output[Index] = "Login is success";
            }
            else if (loginResult == LoginResult.NotFound)
            {
                output[Index] = "Account not found";
            }
            else if (loginResult == LoginResult.WrongPin)
            {
                output[Index] = "Wrong pin";
            }
        }

        return output;
    }

    public Account? FindAccountById(int id)
    {
        Account? account = _accountRepository.FindAccountById(id);

        return account;
    }

    public string[] CreateAccount(int pin, int balance)
    {
        ArgumentNullException.ThrowIfNull(_currentAccount.Account);

        string[] output = new string[OutputLength];
        if (_currentAccount.Account.Id == _adminConfig.Id)
        {
            if (_accountRepository.CreateAccount(pin, balance))
                output[Index] = "Account creates";
            else
                output[Index] = "Something went wrong";
        }
        else
        {
            output[Index] = "You have no access to operation";
        }

        return output;
    }

    public string[] DecreaseBalance(int amount)
    {
        string[] output = new string[OutputLength];
        if (_currentAccount.Account is null)
        {
            output[Index] = "You didn't log in yet";
            return output;
        }

        ArgumentNullException.ThrowIfNull(_currentAccount.Account);

        if (_currentAccount.Account.Balance - amount < 0)
        {
            output[Index] = "Not enough money";
            return output;
        }

        _accountRepository.DecreaseBalance(_currentAccount.Account.Id, amount);
        output[Index] = $"Balance for account {_currentAccount.Account.Id} decreased for {amount}";

        return output;
    }

    public string[] IncreaseBalance(int amount)
    {
        string[] output = new string[OutputLength];
        if (_currentAccount.Account is null)
        {
            output[Index] = "You didn't log in yet";
            return output;
        }

        ArgumentNullException.ThrowIfNull(_currentAccount.Account);
        _accountRepository.IncreaseBalance(_currentAccount.Account.Id, amount);
        output[Index] = $"Balance for account {_currentAccount.Account.Id} increased for {amount}";

        return output;
    }

    public string[] CheckBalance()
    {
        string[] output = new string[OutputLength];
        if (_currentAccount.Account is null)
        {
            output[Index] = "You didn't log in yet";
            return output;
        }

        ArgumentNullException.ThrowIfNull(_currentAccount.Account);
        int? balance = _accountRepository.CheckBalance(_currentAccount.Account.Id);
        output[Index] = $"Balance of user {_currentAccount.Account.Id} is {balance}";

        return output;
    }

    public string[] GetTransactions()
    {
        string[] output = new string[OutputLength];
        if (_currentAccount.Account is null)
        {
            output[Index] = "You didn't log in yet";
            return output;
        }

        IEnumerable<Transaction>? transactions = _accountRepository.GetTransactions(_currentAccount.Account.Id);

        if (transactions is null)
        {
            output[Index] = "No transactions for user {_currentAccount.Account.Id}";
            return output;
        }
        else
        {
            var outputTransactions = new List<string>();
            outputTransactions.Add($"Transactions for account {_currentAccount.Account.Id}");
            foreach (Transaction transaction in transactions)
            {
                outputTransactions.Add($"Transaction id:{transaction.TransactionId}, accountId:{transaction.AccountId}, amount:{transaction.Amount}, operation type:{transaction.TransactionType}, time: {transaction.TransactionTime}");
            }

            return outputTransactions.ToArray();
        }
    }
}