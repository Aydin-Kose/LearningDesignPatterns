using System;

public interface IHandler
{
    IHandler SetNext(IHandler handler);
    void Handle(Request request);
}

public abstract class Handler : IHandler
{
    private IHandler _nextHandler;

    public IHandler SetNext(IHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual void Handle(Request request)
    {
        if (_nextHandler != null)
        {
            _nextHandler.Handle(request);
        }
    }
}

public class ConcreteHandlerA : Handler
{
    public override void Handle(Request request)
    {
        if (request.RequestType == "TypeA")
        {
            Console.WriteLine("Handled by ConcreteHandlerA");
        }
        else
        {
            base.Handle(request);
        }
    }
}

public class ConcreteHandlerB : Handler
{
    public override void Handle(Request request)
    {
        if (request.RequestType == "TypeB")
        {
            Console.WriteLine("Handled by ConcreteHandlerB");
        }
        else
        {
            base.Handle(request);
        }
    }
}

public class Request
{
    public string RequestType { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Create handlers
        var handlerA = new ConcreteHandlerA();
        var handlerB = new ConcreteHandlerB();

        // Set up the chain
        handlerA.SetNext(handlerB);

        // Create requests
        var requestA = new Request { RequestType = "TypeA" };
        var requestB = new Request { RequestType = "TypeB" };
        var requestC = new Request { RequestType = "TypeC" };

        // Pass requests through the chain
        handlerA.Handle(requestA); // Output: Handled by ConcreteHandlerA
        handlerA.Handle(requestB); // Output: Handled by ConcreteHandlerB
        handlerA.Handle(requestC); // No output (no handler for TypeC)
    }
}
