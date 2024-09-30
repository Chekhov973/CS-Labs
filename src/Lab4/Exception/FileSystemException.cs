namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Exception;

public class FileSystemException : System.Exception
{
    private FileSystemException(string message)
        : base(message)
    {
    }

    private FileSystemException()
    {
    }

    private FileSystemException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public static FileSystemException FiledMoved(string sourcePath, string destinationPath)
    {
        throw new FileSystemException($"Moved {sourcePath} to {destinationPath}");
    }

    public static FileSystemException UnsupportedSystemMode(string mode)
    {
        throw new FileSystemException($"Unsupported system mode {mode}");
    }

    public static FileSystemException SystemConnected(string path)
    {
        throw new FileSystemException($"Connected to local file system at: {path}");
    }

    public static FileSystemException Disconnected()
    {
        throw new FileSystemException($"Disconnected from file system");
    }

    public static FileSystemException Copied(string sourcePath, string destinationPath)
    {
        throw new FileSystemException($"Copied {sourcePath} to {destinationPath}");
    }

    public static FileSystemException FileDoesNotExist()
    {
        throw new FileSystemException($"File with this name does not exist");
    }

    public static FileSystemException Deleted(string path)
    {
        throw new FileSystemException($"Deleted {path}");
    }

    public static FileSystemException Renamed(string path, string newName)
    {
        throw new FileSystemException($"Renamed {path} to {newName}");
    }

    public static FileSystemException ContentShowed(string path, string content)
    {
        throw new FileSystemException($"Content of {path}: \n{content}");
    }

    public static FileSystemException DirectoryNotFount(string path)
    {
        throw new FileSystemException($"Directory {path} not found");
    }

    public static FileSystemException ContentsOfDirectory(string path)
    {
        throw new FileSystemException($"Contents of directory {path}:");
    }

    public static FileSystemException DirectoryName(string outputSymbol, string name)
    {
        throw new FileSystemException($"{outputSymbol} {name}");
    }

    public static FileSystemException AccessDenied(string directory)
    {
        throw new FileSystemException($"Access denied to : {directory}");
    }

    public static FileSystemException FileName(string outputSymbol, string name)
    {
        throw new FileSystemException($"{outputSymbol} {name}");
    }
}