using System;
using System.Collections.Generic;

// Aggregate Interface
public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

// Iterator Interface
public interface IIterator<T>
{
    T Current { get; }
    bool MoveNext();
    void Reset();
}

// Concrete Aggregate
public class ConcreteAggregate<T> : IAggregate<T>
{
    private readonly List<T> _items = new List<T>();

    public IIterator<T> CreateIterator()
    {
        return new ConcreteIterator<T>(this);
    }

    public int Count => _items.Count;

    public T this[int index]
    {
        get => _items[index];
        set
        {
            if (index < _items.Count)
            {
                _items[index] = value;
            }
            else
            {
                _items.Add(value);
            }
        }
    }
}

// Concrete Iterator
public class ConcreteIterator<T> : IIterator<T>
{
    private readonly ConcreteAggregate<T> _aggregate;
    private int _currentIndex;

    public ConcreteIterator(ConcreteAggregate<T> aggregate)
    {
        _aggregate = aggregate;
        _currentIndex = -1;
    }

    public T Current => _aggregate[_currentIndex];

    public bool MoveNext()
    {
        if (_currentIndex + 1 < _aggregate.Count)
        {
            _currentIndex++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        _currentIndex = -1;
    }
}

// Client Code
//class Program
//{
//    static void Main(string[] args)
//    {
//        var aggregate = new ConcreteAggregate<string>();
//        aggregate[0] = "Item 1";
//        aggregate[1] = "Item 2";
//        aggregate[2] = "Item 3";

//        IIterator<string> iterator = aggregate.CreateIterator();

//        Console.WriteLine("Iterating over collection:");

//        while (iterator.MoveNext())
//        {
//            Console.WriteLine(iterator.Current);
//        }

//        // Reset the iterator to iterate again
//        iterator.Reset();
//        Console.WriteLine("Iterating again after reset:");

//        while (iterator.MoveNext())
//        {
//            Console.WriteLine(iterator.Current);
//        }
//    }
//}
