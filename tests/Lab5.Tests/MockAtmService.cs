using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Application.Application;
using Application.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class MockAtmService : IAtmService
{
    private const int OutputLength = 1;
    private const int Index = 0;
    private List<MockAccount> _accounts = new List<MockAccount>();
    private ICurrentAccountService _currentAccount = new CurrentAccountManager();
    private int _newId;

    public string[] Login(int id, int pin)
    {
        string[] output = new string[OutputLength];
        _currentAccount.Account = FindAccountById(id);
        output[Index] = "Login is success";
        return output;
    }

    public Account? FindAccountById(int id)
    {
        return _accounts.FirstOrDefault(x => x.Account.Id == id)?.Account;
    }

    public string[] CreateAccount(int pin, int balance)
    {
        string[] output = new string[OutputLength];
        var acc = new Account(_newId, pin, balance);
        var account = new MockAccount(acc);
        _newId++;
        if (!_accounts.Contains(account))
        {
            _accounts.Add(account);
            output[Index] = "Account created";
        }
        else
        {
            output[Index] = "Something went wrong";
        }

        return output;
    }

    public string[] DecreaseBalance(int amount)
    {
        string[] output = new string[OutputLength];
        if (_currentAccount.Account is null)
        {
            output[Index] = "You didn't log in yet";
        }

        ArgumentNullException.ThrowIfNull(_currentAccount.Account);

        if (_currentAccount.Account.Balance - amount < 0)
        {
            output[Index] = "Not enough money";
        }
        else
        {
             var acc = new MockAccount(_currentAccount.Account);
             acc.Balance -= amount;
             output[Index] = $"Balance decreased, balance is {acc.Balance}";
        }

        return output;
    }

    public string[] IncreaseBalance(int amount)
    {
        string[] output = new string[OutputLength];
        if (_currentAccount.Account is null)
        {
            output[Index] = "You didn't log in yet";
        }

        ArgumentNullException.ThrowIfNull(_currentAccount.Account);

        var acc = new MockAccount(_currentAccount.Account);
        acc.Balance += amount;
        output[Index] = $"Balance increased, balance is {acc.Balance}";

        return output;
    }

    public string[] CheckBalance()
    {
        throw new System.NotImplementedException();
    }

    public string[] GetTransactions()
    {
        throw new System.NotImplementedException();
    }
}