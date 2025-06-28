using System;
using System.Collections.Generic;

namespace LoteriaPOO
{
    // Clase que gestiona la lógica de la lotería primitiva
    class LoteriaPrimitiva
    {
        private List<int> numerosGanadores;
        private int cantidadNumeros;

        // Constructor
        public LoteriaPrimitiva(int cantidad)
        {
            cantidadNumeros = cantidad;
            numerosGanadores = new List<int>();
        }

        // Método para pedir los números al usuario
        public void PedirNumeros()
        {
            Console.WriteLine($"Ingrese {cantidadNumeros} números ganadores de la lotería:");

            for (int i = 1; i <= cantidadNumeros; i++)
            {
                Console.Write($"Número {i}: ");
                int numero;

                while (!int.TryParse(Console.ReadLine(), out numero))
                {
                    Console.Write("Entrada inválida. Ingrese un número entero: ");
                }

                numerosGanadores.Add(numero);
            }
        }

        // Método para ordenar los números
        public void OrdenarNumeros()
        {
            numerosGanadores.Sort();
        }

        // Método para mostrar los números
        public void MostrarNumeros()
        {
            Console.WriteLine("\nNúmeros ganadores ordenados de menor a mayor:");
            foreach (int numero in numerosGanadores)
            {
                Console.Write($"{numero} ");
            }
            Console.WriteLine();
        }
    }

    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la clase con 6 números (puede ajustarse)
            LoteriaPrimitiva loteria = new LoteriaPrimitiva(6);

            loteria.PedirNumeros();
            loteria.OrdenarNumeros();
            loteria.MostrarNumeros();

            Console.ReadKey(); // Esperar tecla antes de cerrar
        }
    }
}
