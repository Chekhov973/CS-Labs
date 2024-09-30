namespace Application.Contracts;

public interface IAccountService
{
    LoginResult Login(int id, int pin);
}