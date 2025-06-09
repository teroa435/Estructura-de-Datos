using System;

class Program
{
    static void Main(string[] args)
    {
        // Declaración del array para almacenar teléfonos
        string[] telefonos = new string[5]; // Capacidad para 5 teléfonos

        Console.WriteLine("=== Gestión de Teléfonos ===");

        // Ingresar números de teléfono en el array
        for (int i = 0; i < telefonos.Length; i++)
        {
            Console.Write($"Ingrese el teléfono {i + 1}: ");
            telefonos[i] = Console.ReadLine();
        }

        // Mostrar los teléfonos almacenados
        Console.WriteLine("\n=== Teléfonos Registrados ===");
        for (int i = 0; i < telefonos.Length; i++)
        {
            Console.WriteLine($"Teléfono {i + 1}: {telefonos[i]}");
        }

        // Búsqueda de un teléfono específico
        Console.Write("\nIngrese un teléfono a buscar: ");
        string telefonoBuscado = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < telefonos.Length; i++)
        {
            if (telefonos[i] == telefonoBuscado)
            {
                Console.WriteLine($"Teléfono encontrado en la posición {i + 1}.");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Teléfono no encontrado.");
        }
    }
}
