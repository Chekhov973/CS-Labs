using Itmo.ObjectOrientedProgramming.Lab4.Commands.Exception;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class OutputFormat
{
    public OutputFormat(string fileSymbol, string directorySymbol)
    {
        if (string.IsNullOrEmpty(fileSymbol))
            throw OutputFormatException.InvalidSymbol();
        if (string.IsNullOrEmpty(directorySymbol))
            throw OutputFormatException.InvalidSymbol();

        FileSymbol = fileSymbol;
        DirectorySymbol = directorySymbol;
    }

    public string FileSymbol { get; }

    public string DirectorySymbol { get; }
}