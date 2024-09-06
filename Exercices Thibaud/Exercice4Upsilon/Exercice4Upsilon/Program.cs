using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<char, double> percentage= new Dictionary<char, double>
        {
            {'e', 12.10},
            {'a', 7.11},
            {'i', 6.59},
            {'s', 6.51},
            {'n', 6.39},
            {'r', 6.07},
            {'t', 5.92},
            {'o', 5.02},
            {'l', 4.96},
            {'u', 4.49},
            {'d', 3.67},
            {'c', 3.18},
            {'m', 2.62},
            {'p', 2.49},
            {'é', 1.94},
            {'g', 1.23},
            {'b', 1.14},
            {'v', 1.11},
            {'h', 1.11},
            {'f', 1.11},
            {'q', 0.65},
            {'y', 0.46},
            {'x', 0.38},
            {'j', 0.34},
            {'è', 0.31}
        };

        Console.Write("Type something: ");
        string word = Console.ReadLine();

        Func<char, string, int> u = (letter, words) =>
        {
            var count = 0;
            foreach (char c in words)
            {
                if (c == letter)
                    count++;
            }
            return count;
        }; 
        List<double> result = new List<double>();

        foreach (char w in word)
        {
            result.Add(percentage[w] / 100 / u (w, word));  
        }

        Console.WriteLine(result.Sum());
        Console.Read();
    }
}
