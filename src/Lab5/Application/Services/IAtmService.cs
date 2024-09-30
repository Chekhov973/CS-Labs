namespace Application.Application;

public interface IAtmService
{
    public string[] Login(int id, int pin);
    public Account? FindAccountById(int id);
    string[] CreateAccount(int pin, int balance);
    string[] DecreaseBalance(int amount);
    string[] IncreaseBalance(int amount);
    string[] CheckBalance();
    string[] GetTransactions();
}