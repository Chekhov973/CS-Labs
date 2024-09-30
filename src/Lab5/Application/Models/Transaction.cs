namespace Application;

public record Transaction(int TransactionId, int AccountId, int Amount, string TransactionType, DateTime TransactionTime);