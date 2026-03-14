using System;
using System.IO;

class Program
{
    static string[] libros = new string[100]; // Array para almacenar libros (id;titulo;autor;categoria;anio;disponible)
    static int contadorLibros = 0;
    static string[] usuarios = new string[100]; // Array para almacenar usuarios (id;nombre;contacto;activo)
    static int contadorUsuarios = 0;
    static string[] prestamos = new string[100]; // Array para almacenar préstamos (idPrestamo;idUsuario;idLibro;fechaPrestamo;fechaLimite;fechaDevolucion;estado)
    static int contadorPrestamos = 0;

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
                    GestionarPrestamos();
                    break;
                case "4":
                    GestionarBusquedas();
                    break;
                case "5":
                    GestionarPersistencia();
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

    static void GestionarPrestamos()
    {
        bool volver = false;

        while (!volver)
        {
            Console.Clear();
            MostrarMenuPrestamos();

            Console.Write("Seleccione una opción (1-6): ");
            string? opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    CrearPrestamo();
                    break;
                case "2":
                    ListarPrestamos();
                    break;
                case "3":
                    VerDetallePrestamo();
                    break;
                case "4":
                    RegistrarDevolucion();
                    break;
                case "5":
                    EliminarPrestamo();
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
                Console.WriteLine("Presiona Enter para volver al menú de préstamos...");
                Console.ReadLine();
            }
        }
    }

    static void MostrarMenuPrestamos()
    {
        Console.WriteLine("Menú de Préstamos");
        Console.WriteLine("1. Crear préstamo");
        Console.WriteLine("2. Listar préstamos");
        Console.WriteLine("3. Ver detalle de préstamo (por ID)");
        Console.WriteLine("4. Registrar devolución");
        Console.WriteLine("5. Eliminar préstamo");
        Console.WriteLine("6. Volver al menú principal");
        Console.WriteLine();
    }

    static void CrearPrestamo()
    {
        if (contadorPrestamos >= prestamos.Length)
        {
            Console.WriteLine("No se pueden crear más préstamos.");
            return;
        }

        Console.Write("ID del usuario: ");
        string idUsuario = Console.ReadLine() ?? "";
        Console.Write("ID del libro: ");
        string idLibro = Console.ReadLine() ?? "";
        Console.Write("Fecha de préstamo (dd/mm/yyyy): ");
        string fechaPrestamo = Console.ReadLine() ?? "";
        Console.Write("Fecha límite (dd/mm/yyyy): ");
        string fechaLimite = Console.ReadLine() ?? "";

        // Validar usuario existe y activo
        bool usuarioValido = false;
        for (int i = 0; i < contadorUsuarios; i++)
        {
            string[] partesUsuario = usuarios[i].Split(';');
            if (partesUsuario[0] == idUsuario && partesUsuario[3] == "true")
            {
                usuarioValido = true;
                break;
            }
        }
        if (!usuarioValido)
        {
            Console.WriteLine("Usuario no encontrado o inactivo.");
            return;
        }

        // Validar libro existe y disponible
        bool libroValido = false;
        int indiceLibro = -1;
        for (int i = 0; i < contadorLibros; i++)
        {
            string[] partesLibro = libros[i].Split(';');
            if (partesLibro[0] == idLibro && partesLibro[5] == "true")
            {
                libroValido = true;
                indiceLibro = i;
                break;
            }
        }
        if (!libroValido)
        {
            Console.WriteLine("Libro no encontrado o no disponible.");
            return;
        }

        // Crear préstamo
        string idPrestamo = (contadorPrestamos + 1).ToString();
        prestamos[contadorPrestamos] =
            $"{idPrestamo};{idUsuario};{idLibro};{fechaPrestamo};{fechaLimite};;activo";
        contadorPrestamos++;

        // Marcar libro como no disponible
        string[] partesLibroActual = libros[indiceLibro].Split(';');
        partesLibroActual[5] = "false";
        libros[indiceLibro] = string.Join(";", partesLibroActual);

        Console.WriteLine("Préstamo creado exitosamente.");
    }

    static void ListarPrestamos()
    {
        Console.WriteLine("Submenú de Listar Préstamos");
        Console.WriteLine("1. Todos");
        Console.WriteLine("2. Activos");
        Console.WriteLine("3. Cerrados");
        Console.Write("Seleccione: ");
        string? subopcion = Console.ReadLine();

        switch (subopcion)
        {
            case "1":
                for (int i = 0; i < contadorPrestamos; i++)
                {
                    string[] partes = prestamos[i].Split(';');
                    Console.WriteLine(
                        $"{partes[0]} - Usuario: {partes[1]} - Libro: {partes[2]} - Estado: {partes[6]}"
                    );
                }
                break;
            case "2":
                for (int i = 0; i < contadorPrestamos; i++)
                {
                    string[] partes = prestamos[i].Split(';');
                    if (partes[6] == "activo")
                        Console.WriteLine(
                            $"{partes[0]} - Usuario: {partes[1]} - Libro: {partes[2]}"
                        );
                }
                break;
            case "3":
                for (int i = 0; i < contadorPrestamos; i++)
                {
                    string[] partes = prestamos[i].Split(';');
                    if (partes[6] == "cerrado")
                        Console.WriteLine(
                            $"{partes[0]} - Usuario: {partes[1]} - Libro: {partes[2]}"
                        );
                }
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }

    static void VerDetallePrestamo()
    {
        Console.Write("Ingrese ID del préstamo: ");
        string id = Console.ReadLine() ?? "";

        for (int i = 0; i < contadorPrestamos; i++)
        {
            string[] partes = prestamos[i].Split(';');
            if (partes[0] == id)
            {
                Console.WriteLine($"ID Préstamo: {partes[0]}");
                Console.WriteLine($"ID Usuario: {partes[1]}");
                Console.WriteLine($"ID Libro: {partes[2]}");
                Console.WriteLine($"Fecha Préstamo: {partes[3]}");
                Console.WriteLine($"Fecha Límite: {partes[4]}");
                Console.WriteLine($"Fecha Devolución: {partes[5]}");
                Console.WriteLine($"Estado: {partes[6]}");
                return;
            }
        }
        Console.WriteLine("Préstamo no encontrado.");
    }

    static void RegistrarDevolucion()
    {
        Console.Write("Ingrese ID del préstamo: ");
        string id = Console.ReadLine() ?? "";
        Console.Write("Fecha de devolución (dd/mm/yyyy): ");
        string fechaDevolucion = Console.ReadLine() ?? "";

        for (int i = 0; i < contadorPrestamos; i++)
        {
            string[] partes = prestamos[i].Split(';');
            if (partes[0] == id && partes[6] == "activo")
            {
                partes[5] = fechaDevolucion;
                partes[6] = "cerrado";
                prestamos[i] = string.Join(";", partes);

                // Marcar libro como disponible
                string idLibro = partes[2];
                for (int j = 0; j < contadorLibros; j++)
                {
                    string[] partesLibro = libros[j].Split(';');
                    if (partesLibro[0] == idLibro)
                    {
                        partesLibro[5] = "true";
                        libros[j] = string.Join(";", partesLibro);
                        break;
                    }
                }

                Console.WriteLine("Devolución registrada.");
                return;
            }
        }
        Console.WriteLine("Préstamo no encontrado o ya cerrado.");
    }

    static void EliminarPrestamo()
    {
        Console.Write("Ingrese ID del préstamo a eliminar: ");
        string id = Console.ReadLine() ?? "";

        for (int i = 0; i < contadorPrestamos; i++)
        {
            string[] partes = prestamos[i].Split(';');
            if (partes[0] == id)
            {
                if (partes[6] == "activo")
                {
                    // Devolver libro automáticamente
                    string idLibro = partes[2];
                    for (int j = 0; j < contadorLibros; j++)
                    {
                        string[] partesLibro = libros[j].Split(';');
                        if (partesLibro[0] == idLibro)
                        {
                            partesLibro[5] = "true";
                            libros[j] = string.Join(";", partesLibro);
                            break;
                        }
                    }
                }

                // Mover los préstamos siguientes
                for (int j = i; j < contadorPrestamos - 1; j++)
                {
                    prestamos[j] = prestamos[j + 1];
                }
                contadorPrestamos--;
                Console.WriteLine("Préstamo eliminado.");
                return;
            }
        }
        Console.WriteLine("Préstamo no encontrado.");
    }

    static void GestionarBusquedas()
    {
        bool volver = false;

        while (!volver)
        {
            Console.Clear();
            MostrarMenuBusquedas();

            Console.Write("Seleccione una opción (1-4): ");
            string? opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    BuscarLibro();
                    break;
                case "2":
                    BuscarUsuario();
                    break;
                case "3":
                    Reportes();
                    break;
                case "4":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }

            if (!volver)
            {
                Console.WriteLine();
                Console.WriteLine("Presiona Enter para volver al menú de búsquedas...");
                Console.ReadLine();
            }
        }
    }

    static void MostrarMenuBusquedas()
    {
        Console.WriteLine("Menú de Búsquedas y Reportes");
        Console.WriteLine("1. Buscar libro");
        Console.WriteLine("2. Buscar usuario");
        Console.WriteLine("3. Reportes");
        Console.WriteLine("4. Volver al menú principal");
        Console.WriteLine();
    }

    static void BuscarLibro()
    {
        Console.WriteLine("Buscar libro por:");
        Console.WriteLine("1. Título");
        Console.WriteLine("2. Autor");
        Console.WriteLine("3. ID/ISBN");
        Console.WriteLine("4. Categoría");
        Console.Write("Seleccione: ");
        string? opcion = Console.ReadLine();

        Console.Write("Ingrese término de búsqueda: ");
        string termino = (Console.ReadLine() ?? "").ToLower();

        for (int i = 0; i < contadorLibros; i++)
        {
            string[] partes = libros[i].Split(';');
            bool match = false;

            switch (opcion)
            {
                case "1":
                    match = partes[1].ToLower().Contains(termino);
                    break;
                case "2":
                    match = partes[2].ToLower().Contains(termino);
                    break;
                case "3":
                    match = partes[0].ToLower().Contains(termino);
                    break;
                case "4":
                    match = partes[3].ToLower().Contains(termino);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    return;
            }

            if (match)
            {
                Console.WriteLine(
                    $"{partes[0]} - {partes[1]} - {partes[2]} - {partes[3]} - Disponible: {partes[5]}"
                );
            }
        }
    }

    static void BuscarUsuario()
    {
        Console.WriteLine("Buscar usuario por:");
        Console.WriteLine("1. Nombre");
        Console.WriteLine("2. ID/Documento");
        Console.Write("Seleccione: ");
        string? opcion = Console.ReadLine();

        Console.Write("Ingrese término de búsqueda: ");
        string termino = (Console.ReadLine() ?? "").ToLower();

        for (int i = 0; i < contadorUsuarios; i++)
        {
            string[] partes = usuarios[i].Split(';');
            bool match = false;

            switch (opcion)
            {
                case "1":
                    match = partes[1].ToLower().Contains(termino);
                    break;
                case "2":
                    match = partes[0].ToLower().Contains(termino);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    return;
            }

            if (match)
            {
                Console.WriteLine($"{partes[0]} - {partes[1]} - {partes[2]} - Activo: {partes[3]}");
            }
        }
    }

    static void Reportes()
    {
        Console.WriteLine("Reportes");
        Console.WriteLine("1. Préstamos por usuario");
        Console.WriteLine("2. Préstamos por libro");
        Console.WriteLine("3. Préstamos vencidos");
        Console.WriteLine("4. Resumen general");
        Console.Write("Seleccione: ");
        string? opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                Console.Write("ID/Documento de usuario: ");
                string idUsuario = Console.ReadLine() ?? "";
                for (int i = 0; i < contadorPrestamos; i++)
                {
                    string[] partes = prestamos[i].Split(';');
                    if (partes[1] == idUsuario)
                        Console.WriteLine(
                            $"{partes[0]} - Libro: {partes[2]} - Estado: {partes[6]}"
                        );
                }
                break;
            case "2":
                Console.Write("ID/ISBN del libro: ");
                string idLibro = Console.ReadLine() ?? "";
                for (int i = 0; i < contadorPrestamos; i++)
                {
                    string[] partes = prestamos[i].Split(';');
                    if (partes[2] == idLibro)
                        Console.WriteLine(
                            $"{partes[0]} - Usuario: {partes[1]} - Estado: {partes[6]}"
                        );
                }
                break;
            case "3":
                DateTime hoy = DateTime.Now.Date;
                for (int i = 0; i < contadorPrestamos; i++)
                {
                    string[] partes = prestamos[i].Split(';');
                    if (partes[6] == "activo")
                    {
                        if (
                            DateTime.TryParseExact(
                                partes[4],
                                "dd/MM/yyyy",
                                null,
                                System.Globalization.DateTimeStyles.None,
                                out DateTime limite
                            )
                        )
                        {
                            if (limite < hoy)
                                Console.WriteLine(
                                    $"{partes[0]} - Usuario: {partes[1]} - Libro: {partes[2]} - Vencido: {partes[4]}"
                                );
                        }
                    }
                }
                break;
            case "4":
                int total = contadorLibros;
                int disponibles = 0;
                for (int i = 0; i < contadorLibros; i++)
                {
                    string[] partes = libros[i].Split(';');
                    if (partes[5] == "true")
                        disponibles++;
                }
                int prestados = total - disponibles;
                Console.WriteLine($"Total libros: {total}");
                Console.WriteLine($"Disponibles: {disponibles}");
                Console.WriteLine($"Prestados: {prestados}");
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }

    static void GestionarPersistencia()
    {
        bool volver = false;

        while (!volver)
        {
            Console.Clear();
            MostrarMenuPersistencia();

            Console.Write("Seleccione una opción (1-4): ");
            string? opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    GuardarDatos();
                    break;
                case "2":
                    CargarDatos();
                    break;
                case "3":
                    ReiniciarDatos();
                    break;
                case "4":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }

            if (!volver)
            {
                Console.WriteLine();
                Console.WriteLine("Presiona Enter para volver al menú de persistencia...");
                Console.ReadLine();
            }
        }
    }

    static void MostrarMenuPersistencia()
    {
        Console.WriteLine("Menú de Guardar / Cargar datos");
        Console.WriteLine("1. Guardar datos");
        Console.WriteLine("2. Cargar datos");
        Console.WriteLine("3. Reiniciar datos (vaciar todo)");
        Console.WriteLine("4. Volver al menú principal");
        Console.WriteLine();
    }

    static void GuardarDatos()
    {
        using (var writer = new StreamWriter("libros.txt"))
        {
            for (int i = 0; i < contadorLibros; i++)
                writer.WriteLine(libros[i]);
        }

        using (var writer = new StreamWriter("usuarios.txt"))
        {
            for (int i = 0; i < contadorUsuarios; i++)
                writer.WriteLine(usuarios[i]);
        }

        using (var writer = new StreamWriter("prestamos.txt"))
        {
            for (int i = 0; i < contadorPrestamos; i++)
                writer.WriteLine(prestamos[i]);
        }

        Console.WriteLine("Datos guardados en libros.txt / usuarios.txt / prestamos.txt");
    }

    static void CargarDatos()
    {
        if (File.Exists("libros.txt"))
        {
            string[] lineas = File.ReadAllLines("libros.txt");
            contadorLibros = Math.Min(lineas.Length, libros.Length);
            for (int i = 0; i < contadorLibros; i++)
                libros[i] = lineas[i];
        }

        if (File.Exists("usuarios.txt"))
        {
            string[] lineas = File.ReadAllLines("usuarios.txt");
            contadorUsuarios = Math.Min(lineas.Length, usuarios.Length);
            for (int i = 0; i < contadorUsuarios; i++)
                usuarios[i] = lineas[i];
        }

        if (File.Exists("prestamos.txt"))
        {
            string[] lineas = File.ReadAllLines("prestamos.txt");
            contadorPrestamos = Math.Min(lineas.Length, prestamos.Length);
            for (int i = 0; i < contadorPrestamos; i++)
                prestamos[i] = lineas[i];
        }

        Console.WriteLine("Datos cargados (si los archivos existían).\n");
    }

    static void ReiniciarDatos()
    {
        Console.Write("¿Está seguro que desea eliminar todos los datos? (s/n): ");
        string? confirm = Console.ReadLine();
        if (confirm?.ToLower() == "s")
        {
            contadorLibros = 0;
            contadorUsuarios = 0;
            contadorPrestamos = 0;
            Console.WriteLine("Datos reiniciados.");
        }
        else
        {
            Console.WriteLine("Operación cancelada.");
        }
    }
}
