namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public interface IChainLink
{
    IChainLink AddNext(IChainLink link);
    ICommand? Handle(string[] args);
}