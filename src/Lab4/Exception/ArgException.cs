namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Exception;

public class ArgException : System.Exception
{
    private ArgException(string message)
        : base(message)
    {
    }

    private ArgException()
    {
    }

    private ArgException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public static ArgException InvalidPathException()
    {
        throw new ArgException($"Invalid path given");
    }

    public static ArgException InvalidDepth()
    {
        throw new ArgException($"Invalid depth data");
    }
}