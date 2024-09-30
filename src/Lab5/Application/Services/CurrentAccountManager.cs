using Application.Contracts;

namespace Application.Application;

public class CurrentAccountManager : ICurrentAccountService
{
    public Account? Account { get; set; }
}