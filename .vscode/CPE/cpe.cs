using System;
using System.Collections.Generic;

namespace AgendaTelefonica
{
    // Clase que representa un contacto
    class Contacto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Id { get; set; }
        public string[] Telefonos { get; set; }

        public Contacto(string id, string nombre, string apellido, string direccion, string[] telefonos)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Telefonos = telefonos;
        }

        public void Mostrar()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($" - {Telefonos[i]}");
            }
        }
    }

    // Clase que representa la agenda
    class Agenda
    {
        private List<Contacto> contactos = new List<Contacto>();

        public void AgregarContacto(Contacto contacto)
        {
            contactos.Add(contacto);
            Console.WriteLine("✅ Contacto agregado exitosamente.");
        }

        public void ListarContactos()
        {
            Console.WriteLine("\n📒 Lista de Contactos:");
            foreach (var contacto in contactos)
            {
                contacto.Mostrar();
                Console.WriteLine("-------------------------------");
            }
        }

        public void BuscarPorNombre(string nombre)
        {
            var encontrados = contactos.FindAll(c => c.Nombre.ToLower().Contains(nombre.ToLower()));
            if (encontrados.Count == 0)
            {
                Console.WriteLine("⚠️ No se encontraron contactos con ese nombre.");
            }
            else
            {
                foreach (var contacto in encontrados)
                {
                    contacto.Mostrar();
                    Console.WriteLine("-------------------------------");
                }
            }
        }
    }

    // Clase principal
    class Program
    {
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda();

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n📞 AGENDA TELEFÓNICA");
                Console.WriteLine("1. Agregar contacto");
                Console.WriteLine("2. Listar contactos");
                Console.WriteLine("3. Buscar contacto por nombre");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("ID: ");
                        string id = Console.ReadLine();
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Apellido: ");
                        string apellido = Console.ReadLine();
                        Console.Write("Dirección: ");
                        string direccion = Console.ReadLine();

                        string[] telefonos = new string[3];
                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write($"Teléfono {i + 1}: ");
                            telefonos[i] = Console.ReadLine();
                        }

                        Contacto nuevo = new Contacto(id, nombre, apellido, direccion, telefonos);
                        agenda.AgregarContacto(nuevo);
                        break;

                    case "2":
                        agenda.ListarContactos();
                        break;

                    case "3":
                        Console.Write("Ingrese nombre a buscar: ");
                        string nombreBusqueda = Console.ReadLine();
                        agenda.BuscarPorNombre(nombreBusqueda);
                        break;

                    case "4":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("❌ Opción inválida.");
                        break;
                }
            }
        }
    }
}