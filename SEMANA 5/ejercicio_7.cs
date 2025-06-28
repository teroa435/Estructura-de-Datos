using System;
using System.Collections.Generic;

class ProgramaAbecedario
{
    static void Main()
    {
        // Lista del abecedario incluyendo la ñ (usando caracteres)
        List<char> abecedario = new List<char>() 
        {
            'a','b','c','d','e','f','g','h','i','j',
            'k','l','m','n','ñ','o','p','q','r','s',
            't','u','v','w','x','y','z'
        };

        // Eliminar elementos en posiciones múltiplos de 3 (empezando desde 1)
        for (int i = abecedario.Count; i >= 1; i--)
        {
            if (i % 3 == 0)
            {
                abecedario.RemoveAt(i - 1);
            }
        }

        // Mostrar resultado
        Console.WriteLine("Abecedario modificado (sin letras en posiciones múltiplos de 3):");
        foreach (char letra in abecedario)
        {
            Console.Write(letra + " ");
        }

        Console.WriteLine();
        Console.ReadKey(); // Para pausar antes de salir
    }
}
