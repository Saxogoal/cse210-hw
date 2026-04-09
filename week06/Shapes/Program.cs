using System;

public class Program
{
    static void Main(string[] args)
    {
        List<Shapes> shapes = new List<Shapes>();
        
        Circle circle = new Circle("Red", 5);
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Square square = new Square("Green", 3);
        
        shapes.Add(circle);
        shapes.Add(rectangle);
        shapes.Add(square);

        foreach (Shapes shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"Shape: {shape.GetType().Name}, Color: {color}, Area: {area}");
        }
    }
}