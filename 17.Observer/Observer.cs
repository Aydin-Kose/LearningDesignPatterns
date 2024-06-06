using System;
using System.Collections.Generic;

namespace ObserverPatternDemo
{
    // Interface-based Approach

    // Subject Interface
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    // Observer Interface
    public interface IObserver
    {
        void Update();
    }

    // Concrete Subject
    public class ConcreteSubject : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();

        private string _subjectState;
        public string SubjectState
        {
            get => _subjectState;
            set
            {
                _subjectState = value;
                Notify();
            }
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    // Concrete Observer
    public class ConcreteObserver : IObserver
    {
        private readonly ConcreteSubject _subject;

        public ConcreteObserver(ConcreteSubject subject)
        {
            _subject = subject;
            _subject.Attach(this);
        }

        public void Update()
        {
            Console.WriteLine("Observer notified. Subject state is now: " + _subject.SubjectState);
        }
    }

    // Event-based Approach

    // Subject Class with Event
    public class Subject
    {
        public event Action StateChanged;
        private string _state;

        public string State
        {
            get => _state;
            set
            {
                _state = value;
                OnStateChanged();
            }
        }

        protected virtual void OnStateChanged()
        {
            StateChanged?.Invoke();
        }
    }

    // Observer Class
    public class Observer
    {
        private readonly Subject _subject;

        public Observer(Subject subject)
        {
            _subject = subject;
            _subject.StateChanged += Update;
        }

        public void Update()
        {
            Console.WriteLine("Observer notified. Subject state is now: " + _subject.State);
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Interface-based Approach
            Console.WriteLine("Interface-based Approach:");
            ConcreteSubject concreteSubject = new ConcreteSubject();
            ConcreteObserver concreteObserver1 = new ConcreteObserver(concreteSubject);
            ConcreteObserver concreteObserver2 = new ConcreteObserver(concreteSubject);

            concreteSubject.SubjectState = "State 1";
            concreteSubject.SubjectState = "State 2";

            // Event-based Approach
            Console.WriteLine("\nEvent-based Approach:");
            Subject subject = new Subject();
            Observer observer1 = new Observer(subject);
            Observer observer2 = new Observer(subject);

            subject.State = "State 1";
            subject.State = "State 2";
        }
    }
}
