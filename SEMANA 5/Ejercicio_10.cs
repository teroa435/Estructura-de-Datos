using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Lista de precios
        List<int> prices = new List<int> { 50, 75, 46, 22, 80, 65, 8 };

        // Versión 1: Usando LINQ (más concisa)
        int min = prices.Min();
        int max = prices.Max();

        Console.WriteLine($"El mínimo es {min}");
        Console.WriteLine($"El máximo es {max}");

        // Versión 2: Usando bucle (como en tu solución Python)
        /*
        int min = prices[0];
        int max = prices[0];
        
        foreach (int price in prices)
        {
            if (price < min)
                min = price;
            else if (price > max)
                max = price;
        }
        
        Console.WriteLine($"El mínimo es {min}");
        Console.WriteLine($"El máximo es {max}");
        */
    }
}
