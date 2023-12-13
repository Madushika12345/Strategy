using System;
using System.Collections.Generic;

// Interface for flying behavior
public interface IFlyBehavior
{
    void Fly();
}

// Concrete flying behavior
public class FliesWithWings : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("*FLIES BY FLAPPING WINGS*");
    }
}

// Concrete non-flying behavior
public class CannotFly : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("*CANNOT FLY*");
    }
}

// Parent Bird class
public class Bird
{
    private string name;
    private IFlyBehavior flyBehavior;

    public Bird(string name)
    {
        this.name = name;
    }

    public void SetFlightBehavior(IFlyBehavior flyBehavior)
    {
        this.flyBehavior = flyBehavior;
    }

    public void PerformFly()
    {
        flyBehavior.Fly();
    }

    public void Display()
    {
        Console.WriteLine($"Here is the {name}'s movement behavior: ");
    }
}

// Subclasses for birds
public class MallardDuck : Bird
{
    public MallardDuck() : base("Mallard Duck") { }
}

public class EmperorPenguin : Bird
{
    public EmperorPenguin() : base("Emperor Penguin") { }
}

public class BaldEagle : Bird
{
    public BaldEagle() : base("Bald Eagle") { }
}

public class Ostrich : Bird
{
    public Ostrich() : base("Ostrich") { }
}

public class YellowRubberDuck : Bird
{
    public YellowRubberDuck() : base("Yellow Rubber Duck") { }
}

class Program
{
    static void Main(string[] args)
    {
        List<Bird> birds = new List<Bird>
        {
            new MallardDuck(),
            new EmperorPenguin(),
            new BaldEagle(),
            new Ostrich(),
            new YellowRubberDuck()
        };

        Console.WriteLine($"Number of birds in the simulation: {birds.Count}");

        foreach (var bird in birds)
        {
            bird.Display();
            bird.SetFlightBehavior(GetFlightBehavior(bird));
            bird.PerformFly();
        }
    }

    static IFlyBehavior GetFlightBehavior(Bird bird)
    {
        // Logic to determine the appropriate flying behavior for each bird
        if (bird is MallardDuck || bird is BaldEagle)
        {
            return new FliesWithWings();
        }
        else if (bird is EmperorPenguin)
        {
            return new CannotFly();
        }
        else if (bird is Ostrich || bird is YellowRubberDuck)
        {
            return new CannotFly(); // Non-flying birds
        }
        else
        {
            throw new ArgumentException("Unknown bird type");
        }
    }
}

