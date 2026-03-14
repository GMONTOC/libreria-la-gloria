using System;

class Program
{
    static string[] libros = new string[100]; // Array para almacenar libros (id;titulo;autor;categoria;anio;disponible)
    static int contadorLibros = 0;
    static string[] usuarios = new string[100]; // Array para almacenar usuarios (id;nombre;contacto;activo)
    static int contadorUsuarios = 0;

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
                    GestionarLibros();
                    break;
                case "2":
                    GestionarUsuarios();
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

    static void GestionarLibros()
    {
        bool volver = false;

        while (!volver)
        {
            Console.Clear();
            MostrarMenuLibros();

            Console.Write("Seleccione una opción (1-6): ");
            string? opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    RegistrarLibro();
                    break;
                case "2":
                    ListarLibros();
                    break;
                case "3":
                    VerDetalleLibro();
                    break;
                case "4":
                    ActualizarLibro();
                    break;
                case "5":
                    EliminarLibro();
                    break;
                case "6":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }

            if (!volver)
            {
                Console.WriteLine();
                Console.WriteLine("Presiona Enter para volver al menú de libros...");
                Console.ReadLine();
            }
        }
    }

    static void MostrarMenuLibros()
    {
        Console.WriteLine("Menú de Libros");
        Console.WriteLine("1. Registrar libro");
        Console.WriteLine("2. Listar libros");
        Console.WriteLine("3. Ver detalle de libro (por ID/ISBN)");
        Console.WriteLine("4. Actualizar libro");
        Console.WriteLine("5. Eliminar libro");
        Console.WriteLine("6. Volver al menú principal");
        Console.WriteLine();
    }

    static void RegistrarLibro()
    {
        if (contadorLibros >= libros.Length)
        {
            Console.WriteLine("No se pueden registrar más libros.");
            return;
        }

        Console.Write("ID/ISBN: ");
        string id = Console.ReadLine() ?? "";
        Console.Write("Título: ");
        string titulo = Console.ReadLine() ?? "";
        Console.Write("Autor: ");
        string autor = Console.ReadLine() ?? "";
        Console.Write("Categoría: ");
        string categoria = Console.ReadLine() ?? "";
        Console.Write("Año: ");
        string anio = Console.ReadLine() ?? "";
        string disponible = "true";

        libros[contadorLibros] = $"{id};{titulo};{autor};{categoria};{anio};{disponible}";
        contadorLibros++;
        Console.WriteLine("Libro registrado exitosamente.");
    }

    static void ListarLibros()
    {
        Console.WriteLine("Submenú de Listar Libros");
        Console.WriteLine("1. Listar todos");
        Console.WriteLine("2. Listar disponibles");
        Console.WriteLine("3. Listar prestados");
        Console.Write("Seleccione: ");
        string? subopcion = Console.ReadLine();

        switch (subopcion)
        {
            case "1":
                for (int i = 0; i < contadorLibros; i++)
                {
                    string[] partes = libros[i].Split(';');
                    Console.WriteLine($"{partes[0]} - {partes[1]} - {partes[2]} - {partes[5]}");
                }
                break;
            case "2":
                for (int i = 0; i < contadorLibros; i++)
                {
                    string[] partes = libros[i].Split(';');
                    if (partes[5] == "true")
                        Console.WriteLine($"{partes[0]} - {partes[1]} - {partes[2]}");
                }
                break;
            case "3":
                for (int i = 0; i < contadorLibros; i++)
                {
                    string[] partes = libros[i].Split(';');
                    if (partes[5] == "false")
                        Console.WriteLine($"{partes[0]} - {partes[1]} - {partes[2]}");
                }
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }

    static void VerDetalleLibro()
    {
        Console.Write("Ingrese ID/ISBN del libro: ");
        string id = Console.ReadLine() ?? "";

        for (int i = 0; i < contadorLibros; i++)
        {
            string[] partes = libros[i].Split(';');
            if (partes[0] == id)
            {
                Console.WriteLine($"ID: {partes[0]}");
                Console.WriteLine($"Título: {partes[1]}");
                Console.WriteLine($"Autor: {partes[2]}");
                Console.WriteLine($"Categoría: {partes[3]}");
                Console.WriteLine($"Año: {partes[4]}");
                Console.WriteLine($"Disponible: {partes[5]}");
                return;
            }
        }
        Console.WriteLine("Libro no encontrado.");
    }

    static void ActualizarLibro()
    {
        Console.Write("Ingrese ID/ISBN del libro a actualizar: ");
        string id = Console.ReadLine() ?? "";

        for (int i = 0; i < contadorLibros; i++)
        {
            string[] partes = libros[i].Split(';');
            if (partes[0] == id)
            {
                Console.WriteLine("Submenú de Actualizar");
                Console.WriteLine("1. Editar título");
                Console.WriteLine("2. Editar autor");
                Console.WriteLine("3. Editar año / categoría");
                Console.Write("Seleccione: ");
                string? subopcion = Console.ReadLine();

                switch (subopcion)
                {
                    case "1":
                        Console.Write("Nuevo título: ");
                        partes[1] = Console.ReadLine() ?? "";
                        break;
                    case "2":
                        Console.Write("Nuevo autor: ");
                        partes[2] = Console.ReadLine() ?? "";
                        break;
                    case "3":
                        Console.Write("Nuevo año: ");
                        partes[4] = Console.ReadLine() ?? "";
                        Console.Write("Nueva categoría: ");
                        partes[3] = Console.ReadLine() ?? "";
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        return;
                }

                libros[i] = string.Join(";", partes);
                Console.WriteLine("Libro actualizado.");
                return;
            }
        }
        Console.WriteLine("Libro no encontrado.");
    }

    static void EliminarLibro()
    {
        Console.Write("Ingrese ID/ISBN del libro a eliminar: ");
        string id = Console.ReadLine() ?? "";

        for (int i = 0; i < contadorLibros; i++)
        {
            string[] partes = libros[i].Split(';');
            if (partes[0] == id)
            {
                if (partes[5] == "false")
                {
                    Console.WriteLine("No se puede eliminar un libro prestado.");
                    return;
                }

                // Mover los libros siguientes
                for (int j = i; j < contadorLibros - 1; j++)
                {
                    libros[j] = libros[j + 1];
                }
                contadorLibros--;
                Console.WriteLine("Libro eliminado.");
                return;
            }
        }
        Console.WriteLine("Libro no encontrado.");
    }

    static void GestionarUsuarios()
    {
        bool volver = false;

        while (!volver)
        {
            Console.Clear();
            MostrarMenuUsuarios();

            Console.Write("Seleccione una opción (1-6): ");
            string? opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    RegistrarUsuario();
                    break;
                case "2":
                    ListarUsuarios();
                    break;
                case "3":
                    VerDetalleUsuario();
                    break;
                case "4":
                    ActualizarUsuario();
                    break;
                case "5":
                    EliminarUsuario();
                    break;
                case "6":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }

            if (!volver)
            {
                Console.WriteLine();
                Console.WriteLine("Presiona Enter para volver al menú de usuarios...");
                Console.ReadLine();
            }
        }
    }

    static void MostrarMenuUsuarios()
    {
        Console.WriteLine("Menú de Usuarios");
        Console.WriteLine("1. Registrar usuario");
        Console.WriteLine("2. Listar usuarios");
        Console.WriteLine("3. Ver detalle de usuario (por ID/documento)");
        Console.WriteLine("4. Actualizar usuario");
        Console.WriteLine("5. Eliminar usuario");
        Console.WriteLine("6. Volver al menú principal");
        Console.WriteLine();
    }

    static void RegistrarUsuario()
    {
        if (contadorUsuarios >= usuarios.Length)
        {
            Console.WriteLine("No se pueden registrar más usuarios.");
            return;
        }

        Console.Write("ID/Documento: ");
        string id = Console.ReadLine() ?? "";
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Teléfono/Email: ");
        string contacto = Console.ReadLine() ?? "";
        string activo = "true"; // Por defecto activo

        usuarios[contadorUsuarios] = $"{id};{nombre};{contacto};{activo}";
        contadorUsuarios++;
        Console.WriteLine("Usuario registrado exitosamente.");
    }

    static void ListarUsuarios()
    {
        for (int i = 0; i < contadorUsuarios; i++)
        {
            string[] partes = usuarios[i].Split(';');
            Console.WriteLine($"{partes[0]} - {partes[1]} - {partes[2]} - {partes[3]}");
        }
    }

    static void VerDetalleUsuario()
    {
        Console.Write("Ingrese ID/Documento del usuario: ");
        string id = Console.ReadLine() ?? "";

        for (int i = 0; i < contadorUsuarios; i++)
        {
            string[] partes = usuarios[i].Split(';');
            if (partes[0] == id)
            {
                Console.WriteLine($"ID: {partes[0]}");
                Console.WriteLine($"Nombre: {partes[1]}");
                Console.WriteLine($"Contacto: {partes[2]}");
                Console.WriteLine($"Activo: {partes[3]}");
                return;
            }
        }
        Console.WriteLine("Usuario no encontrado.");
    }

    static void ActualizarUsuario()
    {
        Console.Write("Ingrese ID/Documento del usuario a actualizar: ");
        string id = Console.ReadLine() ?? "";

        for (int i = 0; i < contadorUsuarios; i++)
        {
            string[] partes = usuarios[i].Split(';');
            if (partes[0] == id)
            {
                Console.WriteLine("Submenú de Actualizar");
                Console.WriteLine("1. Editar nombre");
                Console.WriteLine("2. Editar contacto");
                Console.WriteLine("3. Activar / desactivar");
                Console.Write("Seleccione: ");
                string? subopcion = Console.ReadLine();

                switch (subopcion)
                {
                    case "1":
                        Console.Write("Nuevo nombre: ");
                        partes[1] = Console.ReadLine() ?? "";
                        break;
                    case "2":
                        Console.Write("Nuevo contacto: ");
                        partes[2] = Console.ReadLine() ?? "";
                        break;
                    case "3":
                        Console.Write("Activo (true/false): ");
                        partes[3] = Console.ReadLine() ?? "true";
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        return;
                }

                usuarios[i] = string.Join(";", partes);
                Console.WriteLine("Usuario actualizado.");
                return;
            }
        }
        Console.WriteLine("Usuario no encontrado.");
    }

    static void EliminarUsuario()
    {
        Console.Write("Ingrese ID/Documento del usuario a eliminar: ");
        string id = Console.ReadLine() ?? "";

        for (int i = 0; i < contadorUsuarios; i++)
        {
            string[] partes = usuarios[i].Split(';');
            if (partes[0] == id)
            {
                // Validar si tiene préstamos activos

                // Mover los usuarios siguientes
                for (int j = i; j < contadorUsuarios - 1; j++)
                {
                    usuarios[j] = usuarios[j + 1];
                }
                contadorUsuarios--;
                Console.WriteLine("Usuario eliminado.");
                return;
            }
        }
        Console.WriteLine("Usuario no encontrado.");
    }
}
