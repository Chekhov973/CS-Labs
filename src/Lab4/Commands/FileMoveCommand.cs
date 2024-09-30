using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Exception;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileMoveCommand : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public FileMoveCommand(string sourcePath, string destinationPath)
    {
        if (string.IsNullOrEmpty(sourcePath))
            throw ArgException.InvalidPathException();
        if (string.IsNullOrEmpty(destinationPath))
            throw ArgException.InvalidPathException();

        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public string[] Execute(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        return fileSystem.Move(_sourcePath, _destinationPath);
    }
}