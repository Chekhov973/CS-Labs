using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Lab3Test
{
    [Fact]
    public void MessageReceiverMessageUnread()
    {
        var adress = new FilteringProxyUser(2);
        var topic = new Topic("Topic", adress);

        IMessageBuilder messageBuilder = new MessageBuilder();
        Message message = messageBuilder.SetTitle("Some title").SetBody("Some body").SetPriority(5).BuildMessage();

        topic.Send(message);

        Assert.False(adress.User.Messages.First(x => x.Message.Equals(message)).IsMessageRead);
    }

    [Fact]
    public void MessageCheckedMessageRead()
    {
        var adress = new FilteringProxyUser(2);
        var topic = new Topic("Topic", adress);

        IMessageBuilder messageBuilder = new MessageBuilder();
        Message message = messageBuilder.SetTitle("Some title").SetBody("Some body").SetPriority(5).BuildMessage();

        topic.Send(message);
        adress.User.ReadMessage(message);

        Assert.True(adress.User.Messages.First(x => x.Message.Equals(message)).IsMessageRead);
    }

    [Fact]
    public void ReadMessageCheckedExceptionGot()
    {
        var adress = new FilteringProxyUser(2);
        var topic = new Topic("Topic", adress);

        IMessageBuilder messageBuilder = new MessageBuilder();
        Message message = messageBuilder.SetTitle("Some title").SetBody("Some body").SetPriority(5).BuildMessage();

        topic.Send(message);
        adress.User.ReadMessage(message);

        UserException exception = Assert.Throws<UserException>(() =>
        {
            adress.User.ReadMessage(message);
        });
        Assert.Equal("Message is already read", exception.Message);
    }

    [Fact]
    public void LowPriorityMessageDidntReceived()
    {
        var adress = new MockProxyMessenger(5);

        IMessageBuilder messageBuilder = new MessageBuilder();
        Message message = messageBuilder.SetTitle("Some title").SetBody("Some body").SetPriority(2).BuildMessage();

        adress.ReceiveMessage(message);
        Assert.Equal(0, adress.Calls);
    }

    [Fact]
    public void HighPriorityMessageLogged()
    {
        var adress = new MockProxyMessenger(2);

        IMessageBuilder messageBuilder = new MessageBuilder();
        Message message = messageBuilder.SetTitle("Some title").SetBody("Some body").SetPriority(5).BuildMessage();

        adress.ReceiveMessage(message);
        Assert.Equal(1, adress.Calls);
    }

    [Fact]
    public void MessengerWritesCorrectString()
    {
        var adress = new MockProxyMessenger(2);

        IMessageBuilder messageBuilder = new MessageBuilder();
        Message message = messageBuilder.SetTitle("Some title").SetBody("Some body").SetPriority(5).BuildMessage();

        adress.ReceiveMessage(message);

        Assert.Equal("messenger: Some body", adress.Log(message));
    }
}