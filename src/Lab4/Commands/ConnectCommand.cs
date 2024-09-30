using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Exception;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private string _path;
    private string _mode;

    public ConnectCommand(string path, string mode)
    {
        if (string.IsNullOrEmpty(path))
            throw ArgException.InvalidPathException();
        if (string.IsNullOrEmpty(mode))
            throw ArgException.InvalidPathException();

        _path = path;
        _mode = mode;
    }

    public string[] Execute(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);
        return fileSystem.Connect(_path, _mode);
    }
}