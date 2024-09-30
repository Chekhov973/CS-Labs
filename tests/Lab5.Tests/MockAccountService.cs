using System;
using Application;
using Application.Application;
using Application.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class MockAccountService : IAccountService
{
    private readonly ICurrentAccountService _currentAccountManager;
    private IAtmService _atmService;

    public MockAccountService(IAtmService atmService, ICurrentAccountService currentAccountManager)
    {
        ArgumentNullException.ThrowIfNull(atmService);
        ArgumentNullException.ThrowIfNull(currentAccountManager);

        _atmService = atmService;
        _currentAccountManager = currentAccountManager;
    }

    public LoginResult Login(int id, int pin)
    {
        Account? account = _atmService.FindAccountById(id);

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