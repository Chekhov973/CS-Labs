using Presentation.Commands;

namespace Presentation;

public interface IChainLink
{
    IChainLink AddNext(IChainLink link);
    ICommand? Handle(string[] args);
}