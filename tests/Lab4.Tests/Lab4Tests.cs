using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Lab4Tests
{
    [Fact]
    public void ConnectEnteredConnectCommandReturned()
    {
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

        string[] arguments = { "connect", "/somewhere", "-m", "local" };

        ICommand? command = connect.Handle(arguments);

        Assert.IsType<ConnectCommand>(command);
    }

    [Fact]
    public void TreeListEnteredTreeListCommandReturned()
    {
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

        string[] arguments = { "tree", "list", "-d", "1" };

        ICommand? command = connect.Handle(arguments);

        Assert.IsType<TreeListCommand>(command);
    }
}