using Application.Application;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Lab5Tests
{
    [Fact]
    public void EnoughMoneyToDecreaseSuccess()
    {
        IAtmService atmService = new MockAtmService();

        atmService.CreateAccount(1234, 1000);
        atmService.Login(0, 1234);
        string[] result = atmService.DecreaseBalance(1);

        Assert.Equal($"Balance decreased, balance is 999", result[0]);
    }

    [Fact]
    public void NotEnoughMoneyToDecreaseError()
    {
        IAtmService atmService = new MockAtmService();

        atmService.CreateAccount(1234, 1000);
        atmService.Login(0, 1234);
        string[] result = atmService.DecreaseBalance(10000);

        Assert.Equal($"Not enough money", result[0]);
    }
}