using System;

namespace RegistroEstudiante
{
    // Clase que representa a un estudiante
    class Estudiante
    {
        // Atributos públicos del estudiante
        public int Id;                       // Identificador único
        public string Nombres;              // Nombres del estudiante
        public string Apellidos;            // Apellidos del estudiante
        public string Direccion;            // Dirección del estudiante
        public string[] Telefonos = new string[3]; // Array para almacenar 3 números de teléfono

        // Método para mostrar los datos del estudiante
        public void MostrarDatos()
        {
            Console.WriteLine($"\nID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            // Iterar sobre el array de teléfonos e imprimirlos
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la clase Estudiante
            Estudiante estudiante = new Estudiante();

            // Solicitar e ingresar datos del estudiante desde consola
            Console.Write("Ingrese ID del estudiante: ");
            estudiante.Id = int.Parse(Console.ReadLine()); // Convertir texto a entero

            Console.Write("Ingrese nombres del estudiante: ");
            estudiante.Nombres = Console.ReadLine();

            Console.Write("Ingrese apellidos del estudiante: ");
            estudiante.Apellidos = Console.ReadLine();

            Console.Write("Ingrese dirección del estudiante: ");
            estudiante.Direccion = Console.ReadLine();

            // Ingresar los 3 teléfonos utilizando un ciclo for
            for (int i = 0; i < estudiante.Telefonos.Length; i++)
            {
                Console.Write($"Ingrese teléfono {i + 1}: ");
                estudiante.Telefonos[i] = Console.ReadLine();
            }

            // Mostrar todos los datos ingresados
            Console.WriteLine("\n--- DATOS REGISTRADOS DEL ESTUDIANTE ---");
            estudiante.MostrarDatos();
        }
    }
}
