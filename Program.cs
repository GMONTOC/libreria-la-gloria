using System;

class Program
{
    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            MostrarMenuPrincipal();

            Console.Write("Seleccione una opción (1-6): ");
            string? opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Opción 1: Libros (a implementar)");
                    break;
                case "2":
                    Console.WriteLine("Opción 2: Usuarios (a implementar)");
                    break;
                case "3":
                    Console.WriteLine("Opción 3: Préstamos (a implementar)");
                    break;
                case "4":
                    Console.WriteLine("Opción 4: Búsquedas y reportes (a implementar)");
                    break;
                case "5":
                    Console.WriteLine("Opción 5: Guardar / Cargar datos (a implementar)");
                    break;
                case "6":
                    salir = true;
                    Console.WriteLine("Saliendo... ¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine();
                Console.WriteLine("Presiona Enter para volver al menú...");
                Console.ReadLine();
            }
        }
    }

    static void MostrarMenuPrincipal()
    {
        Console.WriteLine("**************************************************");
        Console.WriteLine("* Bienvenido al Sistema de Gestión de Biblioteca *");
        Console.WriteLine("**************************************************");
        Console.WriteLine();
        Console.WriteLine("Menú principal");
        Console.WriteLine("1. Libros");
        Console.WriteLine("2. Usuarios");
        Console.WriteLine("3. Préstamos");
        Console.WriteLine("4. Búsquedas y reportes");
        Console.WriteLine("5. Guardar / Cargar datos");
        Console.WriteLine("6. Salir");
        Console.WriteLine();
    }
}
