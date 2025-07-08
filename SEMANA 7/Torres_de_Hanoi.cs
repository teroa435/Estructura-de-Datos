using System;
using System.Collections.Generic;

class Torre
{
    public Stack<int> Discos { get; private set; }
    public string Nombre { get; private set; }

    public Torre(string nombre)
    {
        Nombre = nombre;
        Discos = new Stack<int>();
    }

    public void MoverDiscoHacia(Torre destino)
    {
        int disco = Discos.Pop();
        destino.Discos.Push(disco);
        Console.WriteLine($"Mover disco {disco} desde {Nombre} hacia {destino.Nombre}");
    }
}

class TorresDeHanoi
{
    static void Resolver(int n, Torre origen, Torre auxiliar, Torre destino)
    {
        if (n == 1)
        {
            origen.MoverDiscoHacia(destino);
            return;
        }

        Resolver(n - 1, origen, destino, auxiliar);
        origen.MoverDiscoHacia(destino);
        Resolver(n - 1, auxiliar, origen, destino);
    }

    static void Main()
    {
        int numDiscos = 3;

        Torre origen = new Torre("Origen");
        Torre auxiliar = new Torre("Auxiliar");
        Torre destino = new Torre("Destino");

        for (int i = numDiscos; i >= 1; i--)
        {
            origen.Discos.Push(i);
        }

        Console.WriteLine($"Resolviendo Torres de Hanoi con {numDiscos} discos:\n");
        Resolver(numDiscos, origen, auxiliar, destino);
    }
}
