using System;
using System.Collections.Generic;

namespace CatalogoRevistas
{
    class Program
    {
        // Estructura de datos para almacenar el catálogo de revistas
        private static List<string> catalogoRevistas = new List<string>();
        
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE CATÁLOGO DE REVISTAS ===");
            
            // Inicializar el catálogo con al menos 10 revistas
            InicializarCatalogo();
            
            bool continuar = true;
            
            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();
                
                switch (opcion)
                {
                    case "1":
                        BuscarRevista();
                        break;
                    case "2":
                        MostrarCatalogo();
                        break;
                    case "3":
                        Console.WriteLine("¡Gracias por usar el sistema!");
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
                
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        /// <summary>
        /// Inicializa el catálogo con al menos 10 revistas
        /// </summary>
        private static void InicializarCatalogo()
        {
            catalogoRevistas.Add("National Geographic");
            catalogoRevistas.Add("Time Magazine");
            catalogoRevistas.Add("Scientific American");
            catalogoRevistas.Add("The Economist");
            catalogoRevistas.Add("Forbes");
            catalogoRevistas.Add("Vogue");
            catalogoRevistas.Add("Nature");
            catalogoRevistas.Add("Science");
            catalogoRevistas.Add("Newsweek");
            catalogoRevistas.Add("People");
            catalogoRevistas.Add("Wired");
            catalogoRevistas.Add("The New Yorker");
            
            // Ordenar el catálogo para facilitar la búsqueda binaria
            catalogoRevistas.Sort();
            
            Console.WriteLine("Catálogo inicializado con " + catalogoRevistas.Count + " revistas.");
        }
        
        /// <summary>
        /// Muestra el menú principal de opciones
        /// </summary>
        private static void MostrarMenu()
        {
            Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Buscar revista por título");
            Console.WriteLine("2. Mostrar catálogo completo");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
        }
        
        /// <summary>
        /// Realiza la búsqueda de una revista en el catálogo
        /// </summary>
        private static void BuscarRevista()
        {
            Console.Write("\nIngrese el título de la revista a buscar: ");
            string tituloBuscado = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(tituloBuscado))
            {
                Console.WriteLine("Debe ingresar un título válido.");
                return;
            }
            
            // Realizar búsqueda binaria iterativa (más eficiente para listas ordenadas)
            bool encontrado = BusquedaBinariaIterativa(tituloBuscado);
            
            // Alternativa: búsqueda secuencial recursiva (descomentar si se prefiere)
            // bool encontrado = BusquedaSecuencialRecursiva(tituloBuscado, 0);
            
            if (encontrado)
            {
                Console.WriteLine("✅ Encontrado: La revista '" + tituloBuscado + "' está en el catálogo.");
            }
            else
            {
                Console.WriteLine("❌ No encontrado: La revista '" + tituloBuscado + "' no está en el catálogo.");
            }
        }
        
        /// <summary>
        /// Implementación de búsqueda binaria iterativa
        /// Eficiente para listas ordenadas - Complejidad O(log n)
        /// </summary>
        /// <param name="titulo">Título a buscar</param>
        /// <returns>True si se encuentra, False en caso contrario</returns>
        private static bool BusquedaBinariaIterativa(string titulo)
        {
            int izquierda = 0;
            int derecha = catalogoRevistas.Count - 1;
            
            while (izquierda <= derecha)
            {
                int medio = izquierda + (derecha - izquierda) / 2;
                
                // Comparación case-insensitive para mayor flexibilidad en la búsqueda
                int comparacion = string.Compare(catalogoRevistas[medio], titulo, StringComparison.OrdinalIgnoreCase);
                
                if (comparacion == 0)
                {
                    return true; // Encontrado
                }
                else if (comparacion < 0)
                {
                    izquierda = medio + 1; // Buscar en la mitad derecha
                }
                else
                {
                    derecha = medio - 1; // Buscar en la mitad izquierda
                }
            }
            
            return false; // No encontrado
        }
        
        /// <summary>
        /// Implementación de búsqueda secuencial recursiva
        /// Alternativa a la búsqueda binaria (menos eficiente pero recursiva)
        /// </summary>
        /// <param name="titulo">Título a buscar</param>
        /// <param name="indice">Índice actual para la recursión</param>
        /// <returns>True si se encuentra, False en caso contrario</returns>
        private static bool BusquedaSecuencialRecursiva(string titulo, int indice)
        {
            // Caso base: llegamos al final de la lista sin encontrar el elemento
            if (indice >= catalogoRevistas.Count)
            {
                return false;
            }
            
            // Caso base: encontramos el elemento
            if (string.Equals(catalogoRevistas[indice], titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            
            // Llamada recursiva: buscar en el siguiente elemento
            return BusquedaSecuencialRecursiva(titulo, indice + 1);
        }
        
        /// <summary>
        /// Muestra todo el catálogo de revistas
        /// </summary>
        private static void MostrarCatalogo()
        {
            Console.WriteLine("\n=== CATÁLOGO COMPLETO DE REVISTAS ===");
            
            if (catalogoRevistas.Count == 0)
            {
                Console.WriteLine("El catálogo está vacío.");
                return;
            }
            
            for (int i = 0; i < catalogoRevistas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {catalogoRevistas[i]}");
            }
            
            Console.WriteLine($"\nTotal: {catalogoRevistas.Count} revistas en el catálogo.");
        }
    }
}