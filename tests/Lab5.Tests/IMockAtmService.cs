namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public interface IMockAtmService
{
    MockAccount? FindAccountVyId(int id);
    string CreateAccount(int id, int balance);
    string DecreaseBalance(int id, int amount);
    string IncreaseBalance(int id, int amount);
}