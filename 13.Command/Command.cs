using System;

// Command Interface
public interface ICommand
{
    void Execute();
    void Undo();
}

// Receiver
public class Light
{
    public void On()
    {
        Console.WriteLine("The light is on");
    }

    public void Off()
    {
        Console.WriteLine("The light is off");
    }
}

// ConcreteCommand for turning on the light
public class LightOnCommand : ICommand
{
    private Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.On();
    }

    public void Undo()
    {
        _light.Off();
    }
}

// ConcreteCommand for turning off the light
public class LightOffCommand : ICommand
{
    private Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.Off();
    }

    public void Undo()
    {
        _light.On();
    }
}

// Invoker
public class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }

    public void PressUndo()
    {
        _command.Undo();
    }
}

// Client
public class Program
{
    public static void Main(string[] args)
    {
        // Create receiver
        Light livingRoomLight = new Light();

        // Create command and set its receiver
        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);

        // Create invoker and associate it with the command
        RemoteControl remote = new RemoteControl();

        // Turn the light on
        remote.SetCommand(lightOn);
        remote.PressButton();

        // Turn the light off
        remote.SetCommand(lightOff);
        remote.PressButton();

        // Undo the last command (turn the light back on)
        remote.PressUndo();
    }
}
