using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Exception;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ICommand
{
    private string _path;

    public FileShowCommand(string path)
    {
        if (string.IsNullOrEmpty(path))
            throw ArgException.InvalidPathException();

        _path = path;
    }

    public string[]? Execute(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        return fileSystem.ShowFileContent(_path);
    }
}