using Application.Contracts;
using Application.Repos;

namespace Application.Application;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ICurrentAccountService _currentAccountManager;

    public AccountService(IAccountRepository accountRepository, ICurrentAccountService currentAccountManager)
    {
        ArgumentNullException.ThrowIfNull(accountRepository);
        ArgumentNullException.ThrowIfNull(currentAccountManager);

        _accountRepository = accountRepository;
        _currentAccountManager = currentAccountManager;
    }

    public LoginResult Login(int id, int pin)
    {
        Account? account = _accountRepository.FindAccountById(id);

        if (account is null)
        {
            return LoginResult.NotFound;
        }

        if (account.Pin != pin)
        {
            return LoginResult.WrongPin;
        }

        _currentAccountManager.Account = account;
        return LoginResult.Success;
    }
}