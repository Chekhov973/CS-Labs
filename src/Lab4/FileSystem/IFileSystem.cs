namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystem;

public interface IFileSystem
{
    string[] Connect(string address, string mode);
    string[] Disconnect();
    string[] Move(string sourcePath, string destinationPath);
    string[] Copy(string sourcePath, string destinationPath);
    string[] Delete(string path);
    string[] Rename(string path, string newName);
    string[]? ShowFileContent(string path);
    string[] ListDirectory(int requestedDepth);
    void SwitchDir(string path);
}