using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Testes rápidos (opcional)
        Shape test = new Square("Blue", 2);
        Console.WriteLine($"Test -> Color: {test.GetColor()} | Area: {test.GetArea():0.###}");

        // Lista polimórfica
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 3),
            new Rectangle("Green", 4, 2.5),
            new Circle("Yellow", 1.75),
            new Square("Purple", 5)
        };

        Console.WriteLine("\nShapes report:");
        foreach (Shape s in shapes)
        {
            Console.WriteLine(s.GetSummary());
        }
    }
}
