namespace Application.Repos;

public interface IAccountRepository
{
    Account? FindAccountById(int id);
    bool CreateAccount(int pin, int balance);
    void DecreaseBalance(int id, int amount);
    void IncreaseBalance(int id, int amount);
    int? CheckBalance(int id);
    IEnumerable<Transaction>? GetTransactions(int id);
}