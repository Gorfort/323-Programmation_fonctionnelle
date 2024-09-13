using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words = { "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };

        double averageLength = words.Average(w => w.Length);
        // Prends tous les mots qui ne contiennent pas x, qui sont égaux ou plus grand que 4 et qui ont autant de caractères que la moyenne du nombre de caractères de la liste
        var noX = words.Where(x => !(x.ToLower().Contains('x'))).Where(w => w.Length >= 4).Where(w => w.Length >= averageLength).ToArray();
        foreach (var word in noX)
        {
            Console.WriteLine(word);
        }
        Console.Read();
    }
}

