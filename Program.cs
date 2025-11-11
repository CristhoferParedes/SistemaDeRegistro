using System;
using System.Collections.Generic;

namespace SistemaRegistro
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaseMenu.OpcionMenu();
        }  

        // SUBMENÚ REPORTES
        static void SubmenuReportes()
        {
            string[] opciones = { "DOCENTE", "ESTUDIANTE", "CURSO", "VOLVER" };
            int seleccion = 0;
            ConsoleKey tecla;

            do
            {
                Console.Clear();
                Console.WriteLine("SUBMENÚ DE REPORTES\n");

                for (int i = 0; i < opciones.Length; i++)
                    Console.WriteLine(i == seleccion ? $"> {opciones[i]}" : $"  {opciones[i]}");

                tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.RightArrow) seleccion = (seleccion + 1) % opciones.Length;
                else if (tecla == ConsoleKey.LeftArrow) seleccion = (seleccion - 1 + opciones.Length) % opciones.Length;

            } while (tecla != ConsoleKey.Enter);

            switch (seleccion)
            {
                case 0: MostrarReporteDocente(); break;
                case 1: MostrarReporteEstudiante(); break;
                case 2: MostrarReporteCurso(); break;
                //case 3: MostrarMenuPrincipal(); return;
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
            SubmenuReportes();
        }

        // REPORTES
        static void MostrarReporteDocente()
        {
            Console.Clear();
            Console.WriteLine("LISTADO DE DOCENTES:");
            Console.WriteLine("DNI\t\tNOMBRE");
            foreach (var d in Docente.ObtenerTodos())
                Console.WriteLine($"{d.GetDni()}\t{d.GetNombre()}");
        }

        static void MostrarReporteEstudiante()
        {
            Console.Clear();
            Console.WriteLine("LISTADO DE ESTUDIANTES:");
            Console.WriteLine("DNI\t\tNOMBRE");
            foreach (var e in Estudiante.ObtenerTodos())
                Console.WriteLine($"{e.GetDni()}\t{e.GetNombre()}");
        }

        static void MostrarReporteCurso()
        {
            Console.Clear();
            Console.WriteLine("LISTADO DE CURSOS:");
            Console.WriteLine("CÓDIGO\tNOMBRE\t\tPRECIO");
            foreach (var c in Curso.ObtenerTodos())
                Console.WriteLine($"{c.GetCodigo()}\t{c.GetNombre()}\t{c.GetPrecio()}");
        }
    }

    // CLASE DOCENTE
    public class Docente
    {
        private string dni;
        private string nombre;
        private static List<Docente> docentes = new List<Docente>();

        public string GetDni() => dni;
        public string GetNombre() => nombre;
        public void SetDni(string valor) => dni = valor;
        public void SetNombre(string valor) => nombre = valor;

        public static void Registrar()
        {
            string dni;
            do
            {
                Console.Write("DNI DOCENTE (8 dígitos): ");
                dni = Console.ReadLine();
            } while (dni.Length != 8 || !long.TryParse(dni, out _));

            if (docentes.Exists(d => d.GetDni() == dni))
            {
                Console.WriteLine("El DNI ya está registrado.");
                return;
            }

            Console.Write("NOMBRE DOCENTE: ");
            string nombre = Console.ReadLine();

            Docente nuevo = new Docente();
            nuevo.SetDni(dni);
            nuevo.SetNombre(nombre);
            docentes.Add(nuevo);

            Console.WriteLine("Se guardó correctamente al nuevo docente.");
        }

        public static List<Docente> ObtenerTodos() => docentes;
    }

    // CLASE ESTUDIANTE
    public class Estudiante
    {
        private string dni;
        private string nombre;
        private static List<Estudiante> estudiantes = new List<Estudiante>();

        public string GetDni() => dni;
        public string GetNombre() => nombre;
        public void SetDni(string valor) => dni = valor;
        public void SetNombre(string valor) => nombre = valor;

        public static void Registrar()
        {
            string dni;
            do
            {
                Console.Write("DNI ESTUDIANTE (8 dígitos): ");
                dni = Console.ReadLine();
            } while (dni.Length != 8 || !long.TryParse(dni, out _));

            if (estudiantes.Exists(e => e.GetDni() == dni))
            {
                Console.WriteLine(" El DNI ya está registrado.");
                return;
            }

            Console.Write("NOMBRE ESTUDIANTE: ");
            string nombre = Console.ReadLine();

            Estudiante nuevo = new Estudiante();
            nuevo.SetDni(dni);
            nuevo.SetNombre(nombre);
            estudiantes.Add(nuevo);

            Console.WriteLine("Se guardó correctamente al nuevo estudiante.");
        }

        public static List<Estudiante> ObtenerTodos() => estudiantes;
    }

    // CLASE CURSO
    public class Curso
    {
        private string codigo;
        private string nombre;
        private double precio;
        private static List<Curso> cursos = new List<Curso>();

        public string GetCodigo() => codigo;
        public string GetNombre() => nombre;
        public double GetPrecio() => precio;
        public void SetCodigo(string valor) => codigo = valor;
        public void SetNombre(string valor) => nombre = valor;
        public void SetPrecio(double valor) => precio = valor;

        public static void Registrar()
        {
            string codigo;
            do
            {
                Console.Write("CÓDIGO DEL CURSO (6 caracteres): ");
                codigo = Console.ReadLine();
            } while (codigo.Length != 6 || cursos.Exists(c => c.GetCodigo() == codigo));

            Console.Write("NOMBRE DEL CURSO: ");
            string nombre = Console.ReadLine();
            if (cursos.Exists(c => c.GetNombre() == nombre))
            {
                Console.WriteLine("El nombre del curso ya existe.");
                return;
            }

            Console.Write("PRECIO DEL CURSO: ");
            if (!double.TryParse(Console.ReadLine(), out double precio) || precio < 0)
            {
                Console.WriteLine("Precio inválido.");
                return;
            }

            Curso nuevo = new Curso();
            nuevo.SetCodigo(codigo);
            nuevo.SetNombre(nombre);
            nuevo.SetPrecio(precio);
            cursos.Add(nuevo);

            Console.WriteLine("Se guardó correctamente el nuevo curso.");
        }

        public static List<Curso> ObtenerTodos() => cursos;
    }
}