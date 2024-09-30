using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Exception;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private int _depth;

    public TreeListCommand(int depth)
    {
        if (depth < 0)
            throw ArgException.InvalidDepth();

        _depth = depth;
    }

    public string[] Execute(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        return fileSystem.ListDirectory(_depth);
    }
}