using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int number = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);    
            }
        }

        int total = numbers.Sum();
        double avg = numbers.Average();
        int largeNumber = numbers.Max();
        int smallestNumber = numbers.Where(n => n > 0).Min();
        
        Console.WriteLine($"The sum is : {total}");
        Console.WriteLine($"The average is : {avg}");
        Console.WriteLine($"The largest number is : {largeNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestNumber}");

        numbers.Sort();

        Console.WriteLine("The sorted list is: ");

        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }


    }
}