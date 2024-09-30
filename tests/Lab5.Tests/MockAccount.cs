using System;
using Application;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class MockAccount
{
    public MockAccount(Account account)
    {
        ArgumentNullException.ThrowIfNull(account);
        Account = account;
        Balance = account.Balance;
    }

    public Account Account { get; }
    public int Balance { get; set; }
}