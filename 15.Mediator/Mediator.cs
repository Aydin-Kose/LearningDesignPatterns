using System;
using System.Collections.Generic;

// Mediator Interface
public interface IChatRoomMediator
{
    void SendMessage(string message, User user);
    void AddUser(User user);
}

// Concrete Mediator
public class ChatRoom : IChatRoomMediator
{
    private List<User> users;

    public ChatRoom()
    {
        users = new List<User>();
    }

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void SendMessage(string message, User user)
    {
        foreach (var u in users)
        {
            // Message should not be received by the user sending it
            if (u != user)
            {
                u.Receive(message);
            }
        }
    }
}

// Colleague Interface
public abstract class User
{
    protected IChatRoomMediator chatRoom;
    protected string name;

    public User(IChatRoomMediator chatRoom, string name)
    {
        this.chatRoom = chatRoom;
        this.name = name;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message);
}

// Concrete Colleague
public class ConcreteUser : User
{
    public ConcreteUser(IChatRoomMediator chatRoom, string name)
        : base(chatRoom, name)
    {
    }

    public override void Send(string message)
    {
        Console.WriteLine($"{name} sends: {message}");
        chatRoom.SendMessage(message, this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"{name} receives: {message}");
    }
}

// Main Program
public class Program
{
    public static void Main(string[] args)
    {
        IChatRoomMediator chatRoom = new ChatRoom();

        User user1 = new ConcreteUser(chatRoom, "Alice");
        User user2 = new ConcreteUser(chatRoom, "Bob");
        User user3 = new ConcreteUser(chatRoom, "Charlie");

        chatRoom.AddUser(user1);
        chatRoom.AddUser(user2);
        chatRoom.AddUser(user3);

        user1.Send("Hi Bob!");
        user2.Send("Hello Alice!");
    }
}
