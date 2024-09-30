using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Exception;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private string _path;

    public FileDeleteCommand(string path)
    {
        if (string.IsNullOrEmpty(path))
            throw ArgException.InvalidPathException();

        _path = path;
    }

    public string[] Execute(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        return fileSystem.Delete(_path);
    }
}