using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Exception;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private string _path;
    private string _newName;

    public FileRenameCommand(string path, string newName)
    {
        if (string.IsNullOrEmpty(path))
            throw ArgException.InvalidPathException();
        if (string.IsNullOrEmpty(newName))
            throw ArgException.InvalidPathException();

        _path = path;
        _newName = newName;
    }

    public string[]? Execute(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        return fileSystem.Rename(_path, _newName);
    }
}