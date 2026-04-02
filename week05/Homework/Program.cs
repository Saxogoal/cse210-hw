using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //Creating a base assignment
        Assignment a1 = new Assignment("John Doe", "Math");
        Console.WriteLine(a1.GetSummary()); 

        //Creating the derived class assignments
        MathAssignment a2 = new MathAssignment("John Doe", "Math", "Section 5.2", "Problems 1-10");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("John Doe", "English", "The Great Gatsby");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}