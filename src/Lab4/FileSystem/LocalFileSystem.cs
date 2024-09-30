using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Exception;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystem;

public class LocalFileSystem : IFileSystem
{
    private const int MaxDepth = 3;
    private const int ConnectOutputLength = 1;
    private static OutputFormat? _outputFormat;
    private string _currentDirectory = string.Empty;

    public LocalFileSystem(string fileSymbol, string directorySymbol)
    {
        if (string.IsNullOrEmpty(fileSymbol))
            throw OutputFormatException.InvalidSymbol();
        if (string.IsNullOrEmpty(directorySymbol))
            throw OutputFormatException.InvalidSymbol();

        _outputFormat = new OutputFormat(fileSymbol, directorySymbol);
    }

    public string[] Connect(string address, string mode)
    {
        if (string.IsNullOrEmpty(address))
            throw ArgException.InvalidPathException();
        if (string.IsNullOrEmpty(mode))
            throw ArgException.InvalidPathException();

        if (mode != "local")
        {
            throw FileSystemException.UnsupportedSystemMode(mode);
        }

        _currentDirectory = address;

        string[] output = new string[ConnectOutputLength] { $"System connected to {address}" };
        return output;
    }

    public string[] Disconnect()
    {
        _currentDirectory = string.Empty;
        string[] output = new string[ConnectOutputLength] { "Disconnected" };
        return output;
    }

    public string[] Move(string sourcePath, string destinationPath)
    {
        if (string.IsNullOrEmpty(sourcePath))
            throw ArgException.InvalidPathException();
        if (string.IsNullOrEmpty(destinationPath))
            throw ArgException.InvalidPathException();

        string sourceFullPath;
        string destinationFullPath;

        if (!Path.IsPathRooted(sourcePath))
        {
            sourceFullPath = Path.Combine(_currentDirectory, sourcePath);
        }
        else
        {
            sourceFullPath = sourcePath;
        }

        if (!Path.IsPathRooted(destinationPath))
        {
            destinationFullPath = Path.Combine(_currentDirectory, sourcePath);
        }
        else
        {
            destinationFullPath = destinationPath;
        }

        File.Move(sourceFullPath, destinationFullPath);

        string[] output = new string[] { $"File moved from {sourceFullPath} to {destinationFullPath}" };
        return output;
    }

    public string[] Copy(string sourcePath, string destinationPath)
    {
        if (string.IsNullOrEmpty(sourcePath))
            throw ArgException.InvalidPathException();
        if (string.IsNullOrEmpty(destinationPath))
            throw ArgException.InvalidPathException();

        string sourceFullPath;
        string destinationFullPath;

        if (!Path.IsPathRooted(sourcePath))
        {
            sourceFullPath = Path.Combine(_currentDirectory, sourcePath);
        }
        else
        {
            sourceFullPath = sourcePath;
        }

        if (!Path.IsPathRooted(destinationPath))
        {
            destinationFullPath = Path.Combine(_currentDirectory, sourcePath);
        }
        else
        {
            destinationFullPath = destinationPath;
        }

        File.Copy(sourceFullPath, destinationFullPath);
        string[] output = new string[ConnectOutputLength] { $"Copied from {sourceFullPath} to {destinationFullPath}" };
        return output;
    }

    public string[] Delete(string path)
    {
        if (string.IsNullOrEmpty(path))
            throw ArgException.InvalidPathException();
        string fullPath;

        if (Path.IsPathRooted(path))
        {
            fullPath = path;
        }
        else
        {
            fullPath = Path.Combine(_currentDirectory, path);
        }

        if (!File.Exists(fullPath))
        {
            throw FileSystemException.FileDoesNotExist();
        }
        else
        {
            File.Delete(fullPath);
            string[] output = new string[ConnectOutputLength] { $"Deleted {fullPath}" };
            return output;
        }
    }

    public string[] Rename(string path, string newName)
    {
        if (string.IsNullOrEmpty(path))
            throw ArgException.InvalidPathException();
        if (string.IsNullOrEmpty(newName))
            throw ArgException.InvalidPathException();

        string fullPath;
        string newFileName = newName;

        if (Path.IsPathRooted(path))
        {
            fullPath = path;
        }
        else
        {
            fullPath = Path.Combine(_currentDirectory, path);
        }

        File.Move(fullPath, newFileName);
        string[] output = new string[ConnectOutputLength] { $"Renamed {fullPath} to {newFileName}" };
        return output;
    }

    public string[]? ShowFileContent(string path)
    {
        if (string.IsNullOrEmpty(path))
            throw ArgException.InvalidPathException();

        string fullPath;

        if (Path.IsPathRooted(path))
        {
            fullPath = path;
        }
        else
        {
            fullPath = Path.Combine(_currentDirectory, path);
        }

        string content = File.ReadAllText(fullPath);

        string[] output = new string[ConnectOutputLength] { $"Content of {path}: \n{content}" };
        return output;
    }

    public void SwitchDir(string path)
    {
        if (string.IsNullOrEmpty(path))
            throw ArgException.InvalidPathException();

        if (Path.IsPathRooted(path))
        {
            _currentDirectory = path;
        }
        else
        {
            _currentDirectory = Path.Combine(_currentDirectory, path);
        }
    }

    public string[] ListDirectory(int requestedDepth)
    {
        ArgumentNullException.ThrowIfNull(_outputFormat);

        int currentDepth = 1;
        var directoryInfo = new DirectoryInfo(_currentDirectory);
        DirectoryInfo[] subcats;

        try
        {
            subcats = directoryInfo.GetDirectories();
        }
        catch (UnauthorizedAccessException)
        {
            throw FileSystemException.AccessDenied(_currentDirectory);
        }

        var outputList = new List<string>();

        foreach (DirectoryInfo d in subcats)
        {
            string output = $"{_outputFormat.DirectorySymbol} {d.Name}";
            outputList.Add(output);

            outputList.AddRange(ListDirectoryRecursive(d.FullName, MaxDepth, currentDepth + 1, requestedDepth));
        }

        foreach (FileInfo file in directoryInfo.GetFiles())
        {
            string output = $"{_outputFormat.FileSymbol} {file.Name}";
            outputList.Add(output);
        }

        return outputList.ToArray();
    }

    private string[] ListDirectoryRecursive(string directory, int maxDepth, int currentDepth, int requestedDepth)
    {
        ArgumentNullException.ThrowIfNull(_outputFormat);

        if (currentDepth > requestedDepth)
            return new List<string>().ToArray();

        var directoryInfo = new DirectoryInfo(directory);
        DirectoryInfo[] subcats;

        try
        {
            subcats = directoryInfo.GetDirectories();
        }
        catch (UnauthorizedAccessException)
        {
            throw FileSystemException.AccessDenied(directory);
        }

        var outputList = new List<string>();

        foreach (DirectoryInfo d in subcats)
        {
            string output = $"{_outputFormat.DirectorySymbol} {d.Name}";
            outputList.Add(output);

            outputList.AddRange(ListDirectoryRecursive(d.FullName, maxDepth, currentDepth + 1, requestedDepth));
        }

        foreach (FileInfo file in directoryInfo.GetFiles())
        {
            string output = $"{_outputFormat.FileSymbol} {file.Name}";
            outputList.Add(output);
        }

        return outputList.ToArray();
    }
}
