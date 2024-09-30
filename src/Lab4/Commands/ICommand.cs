using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    public string[]? Execute(IFileSystem fileSystem);
}