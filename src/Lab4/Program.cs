using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Exception;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        IFileSystem fileSystem = new LocalFileSystem("--|", "-|");
        IChainLink connect = new ConnectHandler();
        IChainLink disconnect = new DisconnectHandler();
        IChainLink copy = new FileCopyHandler();
        IChainLink delete = new FileDeleteHandler();
        IChainLink move = new FileMoveHandler();
        IChainLink rename = new FileRenameHandler();
        IChainLink show = new FileShowHandler();
        IChainLink treeGoTo = new TreeGoToHandler();
        IChainLink treeList = new TreeListHandler();

        connect.AddNext(disconnect).AddNext(copy).AddNext(delete).AddNext(move).AddNext(rename).AddNext(show)
            .AddNext(treeGoTo).AddNext(treeList);

        while (true)
        {
            try
            {
                string read = Console.ReadLine() ?? throw new InvalidOperationException();
                string[] arguments = read.Split(' ');

                ArgumentNullException.ThrowIfNull(arguments);
                ICommand? command = connect.Handle(arguments);

                string[]? output = command?.Execute(fileSystem);

                ArgumentNullException.ThrowIfNull(output);
                foreach (string o in output)
                {
                    Console.WriteLine(o);
                }
            }
            catch (FileSystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}