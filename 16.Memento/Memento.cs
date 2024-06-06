using System;
using System.Collections.Generic;

// Memento Class
public class EditorMemento
{
    public string Content { get; }

    public EditorMemento(string content)
    {
        Content = content;
    }
}

// Originator Class
public class Editor
{
    private string content;

    public void SetContent(string content)
    {
        this.content = content;
    }

    public string GetContent()
    {
        return content;
    }

    public EditorMemento CreateMemento()
    {
        return new EditorMemento(content);
    }

    public void Restore(EditorMemento memento)
    {
        content = memento.Content;
    }
}

// Caretaker Class
public class EditorHistory
{
    private Stack<EditorMemento> history = new Stack<EditorMemento>();

    public void Save(Editor editor)
    {
        history.Push(editor.CreateMemento());
    }

    public void Undo(Editor editor)
    {
        if (history.Count > 0)
        {
            EditorMemento memento = history.Pop();
            editor.Restore(memento);
        }
    }
}

// Main Program
//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Editor editor = new Editor();
//        EditorHistory history = new EditorHistory();

//        editor.SetContent("Version 1");
//        history.Save(editor);

//        editor.SetContent("Version 2");
//        history.Save(editor);

//        editor.SetContent("Version 3");
//        Console.WriteLine("Current Content: " + editor.GetContent()); // Output: Version 3

//        history.Undo(editor);
//        Console.WriteLine("After Undo: " + editor.GetContent()); // Output: Version 2

//        history.Undo(editor);
//        Console.WriteLine("After Undo: " + editor.GetContent()); // Output: Version 1
//    }
//}
