using Application;
using Application.Repos;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Infrastructure;

public class AccountRepository : IAccountRepository
{
    private string _connectionString;

    public AccountRepository(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentException("Connection string is invalid");

        _connectionString = connectionString;
    }

    public Account? FindAccountById(int id)
    {
        const string sql = """
                           SELECT accountid, pin, balance
                           FROM "accounts"
                           WHERE accountid = @id;
                           """;

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("id", id);
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                    return null;
                return new Account(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
            }
        }
    }

    public bool CreateAccount(int pin, int balance)
    {
        const string sql = """
                           INSERT INTO "accounts" (pin, balance) 
                           VALUES (@pin, @balance);
                           """;

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("@pin", pin);
            command.AddParameter("@balance", balance);

            return command.ExecuteNonQuery() != 0;
        }
    }

    public void DecreaseBalance(int id, int amount)
    {
        const string getAccountBalanceSql = """
                                  SELECT balance 
                                  FROM "accounts" 
                                  WHERE accountid = @id
                                  """;

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        int balance;

        using (var command1 = new NpgsqlCommand(getAccountBalanceSql, connection))
        {
            command1.AddParameter("id", @id);
            using (NpgsqlDataReader reader = command1.ExecuteReader())
            {
                if (!reader.Read())
                    return;
                balance = reader.GetInt32(0);
            }
        }

        balance -= amount;

        const string accounUpdateSql = """"
                                       UPDATE "accounts"
                                       SET balance = @balance
                                       WHERE accountid = @id;
                                       """";

        using (var command2 = new NpgsqlCommand(accounUpdateSql, connection))
        {
            command2.Parameters.AddWithValue("balance", balance);
            command2.Parameters.AddWithValue("id", id);
            command2.ExecuteNonQuery();
        }

        DateTime transactionDate = DateTime.Now;
        const string transactionSql = """
                                      INSERT INTO "transactionshistory" (accountid, amount, transactiontype, transactiondate)
                                      VALUES (@id, @amount, 'decrease', @transactionDate);
                                      """;

        using (var command2 = new NpgsqlCommand(transactionSql, connection))
        {
            command2.AddParameter("id", id);
            command2.AddParameter("amount", amount);
            command2.AddParameter("transactiontype", "decrease");
            command2.AddParameter("transactiondate", transactionDate);
            command2.ExecuteNonQuery();
        }
    }

    public void IncreaseBalance(int id, int amount)
    {
        const string getAccountBalanceSql = """
                                            SELECT balance
                                            FROM "accounts"
                                            WHERE accountid = @id
                                            """;

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        int balance;

        using (var command1 = new NpgsqlCommand(getAccountBalanceSql, connection))
        {
            command1.AddParameter("id", @id);
            using (NpgsqlDataReader reader = command1.ExecuteReader())
            {
                if (!reader.Read())
                    return;
                balance = reader.GetInt32(0);
            }
        }

        balance += amount;

        const string accountSql = """
                                          UPDATE "accounts"
                                          SET balance  = @balance 
                                          WHERE accountid = @id;
                                          """;

        using (var command = new NpgsqlCommand(accountSql, connection))
        {
            command.Parameters.AddWithValue("balance", balance);
            command.Parameters.AddWithValue("id", id);
            command.ExecuteNonQuery();
        }

        DateTime transactionDate = DateTime.Now;
        const string transactionSql = """
                                      INSERT INTO "transactionshistory" (accountid, amount, transactiontype, transactiondate)
                                      VALUES (@id, @amount, 'increase', @transactionDate);
                                      """;

        using (var command2 = new NpgsqlCommand(transactionSql, connection))
        {
            command2.AddParameter("id", id);
            command2.AddParameter("amount", amount);
            command2.AddParameter("transactiontype", "decrease");
            command2.AddParameter("transactiondate", transactionDate);
            command2.ExecuteNonQuery();
        }
    }

    public int? CheckBalance(int id)
    {
        const string sql = """
                           SELECT balance
                           FROM "accounts"
                           WHERE accountid = @id;
                           """;

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("id", id);
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    return null;
                }

                return reader.GetInt32(0);
            }
        }
    }

    public IEnumerable<Transaction> GetTransactions(int id)
    {
        const string sql = """
                           SELECT transactionid, accountid, amount, transactiontype, transactiondate 
                           FROM "transactionshistory" 
                           WHERE accountid = @id
                           """;

        var transactions = new List<Transaction>();

        using var connection = new NpgsqlConnection(_connectionString);
        connection.OpenAsync();
        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("id", id);
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    transactions.Add(new Transaction(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetDateTime(4)));
                }
            }
        }

        return transactions;
    }
}