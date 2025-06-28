using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Crear lista con números del 1 al 10
        List<int> numbers = Enumerable.Range(1, 10).ToList();
        
        // Mostrar en orden inverso separados por comas
        for (int i = numbers.Count - 1; i >= 0; i--)
        {
            Console.Write(numbers[i]);
            if (i > 0) // No agregar coma después del último número
            {
                Console.Write(", ");
            }
        }
        
        Console.WriteLine(); // Salto de línea final
    }
}