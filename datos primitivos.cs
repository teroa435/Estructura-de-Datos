using System;

// Clase para representar un Círculo
public class Circulo
{
    // Propiedad privada para encapsular el radio del círculo
    private double _radio;

    // Constructor de la clase Circulo que recibe el radio como parámetro
    public Circulo(double radio)
    {
        _radio = radio;
    }

    // Método para calcular el área del círculo
    // Devuelve el área calculada usando la fórmula π * radio²
    public double CalcularArea()
    {
        return Math.PI * _radio * _radio;
    }

    // Método para calcular el perímetro del círculo (circunferencia)
    // Devuelve el perímetro calculado usando la fórmula 2 * π * radio
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * _radio;
    }
}

// Clase para representar un Rectángulo
public class Rectangulo
{
    // Propiedades privadas para encapsular el ancho y alto del rectángulo
    private double _ancho;
    private double _alto;

    // Constructor de la clase Rectangulo que recibe el ancho y alto como parámetros
    public Rectangulo(double ancho, double alto)
    {
        _ancho = ancho;
        _alto = alto;
    }

    // Método para calcular el área del rectángulo
    // Devuelve el área calculada usando la fórmula ancho * alto
    public double CalcularArea()
    {
        return _ancho * _alto;
    }

    // Método para calcular el perímetro del rectángulo
    // Devuelve el perímetro calculado usando la fórmula 2 * (ancho + alto)
    public double CalcularPerimetro()
    {
        return 2 * (_ancho + _alto);
    }
}

// Ejemplo de uso de las clases
class Program
{
    static void Main(string[] args)
    {
        // Crear un círculo con radio 5
        Circulo miCirculo = new Circulo(5);
        Console.WriteLine("Área del círculo: " + miCirculo.CalcularArea());
        Console.WriteLine("Perímetro del círculo: " + miCirculo.CalcularPerimetro());

        // Crear un rectángulo con ancho 4 y alto 6
        Rectangulo miRectangulo = new Rectangulo(4, 6);
        Console.WriteLine("Área del rectángulo: " + miRectangulo.CalcularArea());
        Console.WriteLine("Perímetro del rectángulo: " + miRectangulo.CalcularPerimetro());
    }
}
