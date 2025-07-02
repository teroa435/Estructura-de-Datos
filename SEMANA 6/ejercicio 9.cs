using System;

class Nodo
{
    public int Dato;
    public Nodo Siguiente;

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

class Lista
{
    public Nodo Cabeza;

    public Lista()
    {
        Cabeza = null;
    }

    // Inserta al inicio (por el inicio)
    public void InsertarInicio(int dato)
    {
        Nodo nuevo = new Nodo(dato);
        nuevo.Siguiente = Cabeza;
        Cabeza = nuevo;
    }

    // Retorna la longitud de la lista
    public int Longitud()
    {
        int count = 0;
        Nodo actual = Cabeza;
        while (actual != null)
        {
            count++;
            actual = actual.Siguiente;
        }
        return count;
    }

    // Muestra la lista (para verificación)
    public void Mostrar()
    {
        Nodo actual = Cabeza;
        while (actual != null)
        {
            Console.Write(actual.Dato + " -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("NULL");
    }

    // Compara contenido de dos listas (mismo orden)
    public bool EsIgualA(Lista otra)
    {
        Nodo actual1 = this.Cabeza;
        Nodo actual2 = otra.Cabeza;

        while (actual1 != null && actual2 != null)
        {
            if (actual1.Dato != actual2.Dato)
                return false;
            actual1 = actual1.Siguiente;
            actual2 = actual2.Siguiente;
        }

        return (actual1 == null && actual2 == null);
    }
}

class Program
{
    static void Main()
    {
        Lista lista1 = new Lista();
        Lista lista2 = new Lista();

        Console.Write("Ingrese la cantidad de elementos para la primera lista: ");
        int n1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese los elementos de la primera lista:");
        for (int i = 0; i < n1; i++)
        {
            Console.Write($"Elemento {i + 1}: ");
            int dato = int.Parse(Console.ReadLine());
            lista1.InsertarInicio(dato);
        }

        Console.Write("Ingrese la cantidad de elementos para la segunda lista: ");
        int n2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese los elementos de la segunda lista:");
        for (int i = 0; i < n2; i++)
        {
            Console.Write($"Elemento {i + 1}: ");
            int dato = int.Parse(Console.ReadLine());
            lista2.InsertarInicio(dato);
        }

        Console.WriteLine("\nLista 1:");
        lista1.Mostrar();

        Console.WriteLine("Lista 2:");
        lista2.Mostrar();

        // Comparación
        if (lista1.Longitud() == lista2.Longitud())
        {
            if (lista1.EsIgualA(lista2))
            {
                Console.WriteLine("Las listas son IGUALES en tamaño y contenido.");
            }
            else
            {
                Console.WriteLine("Las listas tienen el MISMO tamaño, pero DIFERENTE contenido.");
            }
        }
        else
        {
            Console.WriteLine("Las listas NO tienen el mismo tamaño NI contenido.");
        }
    }
}
