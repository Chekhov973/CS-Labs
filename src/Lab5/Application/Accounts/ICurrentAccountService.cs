namespace Application.Contracts;

public interface ICurrentAccountService
{
    Account? Account { get; set; }
}