using System;

class Vehiculo
{
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Año { get; set; }
    public double Precio { get; set; }
    public Vehiculo Siguiente { get; set; }

    public Vehiculo(string placa, string marca, string modelo, int año, double precio)
    {
        Placa = placa;
        Marca = marca;
        Modelo = modelo;
        Año = año;
        Precio = precio;
        Siguiente = null;
    }

    public void Mostrar()
    {
        Console.WriteLine($"Placa: {Placa}, Marca: {Marca}, Modelo: {Modelo}, Año: {Año}, Precio: ${Precio}");
    }
}

class ListaVehiculos
{
    private Vehiculo cabeza;

    public void AgregarVehiculo(Vehiculo nuevo)
    {
        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            Vehiculo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }
        Console.WriteLine("Vehículo agregado correctamente.");
    }

    public void BuscarPorPlaca(string placa)
    {
        Vehiculo actual = cabeza;
        while (actual != null)
        {
            if (actual.Placa == placa)
            {
                Console.WriteLine("Vehículo encontrado:");
                actual.Mostrar();
                return;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine("Vehículo no encontrado.");
    }

    public void VerPorAño(int año)
    {
        Vehiculo actual = cabeza;
        bool encontrado = false;
        while (actual != null)
        {
            if (actual.Año == año)
            {
                actual.Mostrar();
                encontrado = true;
            }
            actual = actual.Siguiente;
        }
        if (!encontrado)
            Console.WriteLine("No hay vehículos registrados para ese año.");
    }

    public void VerTodos()
    {
        Vehiculo actual = cabeza;
        if (actual == null)
        {
            Console.WriteLine("No hay vehículos registrados.");
            return;
        }

        while (actual != null)
        {
            actual.Mostrar();
            actual = actual.Siguiente;
        }
    }

    public void EliminarPorPlaca(string placa)
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        if (cabeza.Placa == placa)
        {
            cabeza = cabeza.Siguiente;
            Console.WriteLine("Vehículo eliminado.");
            return;
        }

        Vehiculo actual = cabeza;
        while (actual.Siguiente != null && actual.Siguiente.Placa != placa)
        {
            actual = actual.Siguiente;
        }

        if (actual.Siguiente != null)
        {
            actual.Siguiente = actual.Siguiente.Siguiente;
            Console.WriteLine("Vehículo eliminado.");
        }
        else
        {
            Console.WriteLine("Vehículo no encontrado.");
        }
    }
}

class Program
{
    static void Main()
    {
        ListaVehiculos lista = new ListaVehiculos();
        int opcion;

        do
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Agregar vehículo");
            Console.WriteLine("2. Buscar vehículo por placa");
            Console.WriteLine("3. Ver vehículos por año");
            Console.WriteLine("4. Ver todos los vehículos");
            Console.WriteLine("5. Eliminar vehículo por placa");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Placa: ");
                    string placa = Console.ReadLine();
                    Console.Write("Marca: ");
                    string marca = Console.ReadLine();
                    Console.Write("Modelo: ");
                    string modelo = Console.ReadLine();
                    Console.Write("Año: ");
                    int año = int.Parse(Console.ReadLine());
                    Console.Write("Precio: ");
                    double precio = double.Parse(Console.ReadLine());
                    lista.AgregarVehiculo(new Vehiculo(placa, marca, modelo, año, precio));
                    break;
                case 2:
                    Console.Write("Ingrese la placa a buscar: ");
                    lista.BuscarPorPlaca(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Ingrese el año: ");
                    lista.VerPorAño(int.Parse(Console.ReadLine()));
                    break;
                case 4:
                    lista.VerTodos();
                    break;
                case 5:
                    Console.Write("Ingrese la placa a eliminar: ");
                    lista.EliminarPorPlaca(Console.ReadLine());
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }
}
