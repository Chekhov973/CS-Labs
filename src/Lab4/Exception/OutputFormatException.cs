namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Exception;

public class OutputFormatException : System.Exception
{
    private OutputFormatException(string message)
        : base(message)
    {
    }

    private OutputFormatException()
    {
    }

    private OutputFormatException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public static OutputFormatException InvalidSymbol()
    {
        throw new OutputFormatException($"Invalid output symbol got");
    }
}