using System;
using System.Collections.Generic;

#region Virus class with Prototype

public class Virus
{
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }

    public List<Virus> Children { get; set; } = new List<Virus>();

    public Virus(string name, string species, int age, double weight)
    {
        Name = name;
        Species = species;
        Age = age;
        Weight = weight;
    }

    public void AddChild(Virus child)
    {
        Children.Add(child);
    }

    public Virus Clone()
    {
        Virus clone = new Virus(Name, Species, Age, Weight);

        foreach (var child in Children)
        {
            clone.AddChild(child.Clone());
        }

        return clone;
    }

    public void Print(string indent = "")
    {
        Console.WriteLine($"{indent}- {Name} ({Species}), Age: {Age}, Weight: {Weight}");
        foreach (var child in Children)
        {
            child.Print(indent + "  ");
        }
    }
}

#endregion
