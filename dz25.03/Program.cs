using System;

public class Memento
{
    public string State { get; private set; }

    public Memento(string state)
    {
        State = state;
    }
}
public class Caretaker
{
    public Memento Memento { get; set; }
}

public class Originator
{
    private string state;

    public string State
    {
        get { return state; }
        set
        {
            Console.WriteLine($"Змінено стан на: {value}");
            state = value;
        }
    }

    public Memento SaveStateToMemento()
    {
        Console.WriteLine("Збереження стану...");
        return new Memento(state);
    }

    public void GetStateFromMemento(Memento memento)
    {
        state = memento.State;
        Console.WriteLine($"Відновлення стану: {state}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker();

        // Змінюємо стан та зберігаємо знімок
        originator.State = "Стан 1";
        caretaker.Memento = originator.SaveStateToMemento();

        // Змінюємо стан ще раз
        originator.State = "Стан 2";

        // Відновлюємо попередній стан
        originator.GetStateFromMemento(caretaker.Memento);
    }
}
