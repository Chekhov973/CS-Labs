using Application.Application;

namespace Presentation.Commands;

public interface ICommand
{
    public string[] Execute(IAtmService atmService);
}