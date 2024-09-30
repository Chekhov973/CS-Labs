using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    public string[] Execute(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        return fileSystem.Disconnect();
    }
}