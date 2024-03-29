using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(string message);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

public class ConcreteObserver : IObserver
{
    private string name;

    public ConcreteObserver(string name)
    {
        this.name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{name} отримав повідомлення: {message}");
    }
}

public class ConcreteSubject : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private string state;

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update(state);
        }
    }

    public void SetState(string state)
    {
        this.state = state;
        Notify();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConcreteSubject subject = new ConcreteSubject();
        ConcreteObserver observer1 = new ConcreteObserver("Спостерігач 1");
        ConcreteObserver observer2 = new ConcreteObserver("Спостерігач 2");

        subject.Attach(observer1);
        subject.Attach(observer2);

        subject.SetState("Новий стан");
    }
}
