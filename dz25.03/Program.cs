using System;

public class Context
{
    private State state;

    public Context(State state) //Початковий контекст
    {
        this.state = state;
    }

    public void Request()
    {
        state.Handle(this);
    }

    public void SetState(State state) //Динамічний контекст
    {
        this.state = state;
    }
}

public abstract class State
{
    public abstract void Handle(Context context);
}

public class ConcreteState1 : State
{
    public override void Handle(Context context)
    {
        Console.WriteLine("Конкретний стан 1 обробляє запит.");
        context.SetState(new ConcreteState2());
    }
}

public class ConcreteState2 : State
{
    public override void Handle(Context context)
    {
        Console.WriteLine("Конкретний стан 2 обробляє запит.");
        context.SetState(new ConcreteState1());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Context context = new Context(new ConcreteState1());

        context.Request();

        context.Request();
    }
}
