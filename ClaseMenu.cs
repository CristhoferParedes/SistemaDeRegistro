using System;

namespace SistemaRegistro
{
    public class ClaseMenu
    {
        public static int OpcionMenu()
        {
            string[] opciones = { "REGISTRAR", "ASISTENCIA", "REPORTES", "SALIR" };
            int index= 0;
            ConsoleKey tecla;

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(" ------------------------------------------------------ ");
                Console.WriteLine("           SISTEMA DE GESTION DE ASISTENCIAS            ");
                Console.WriteLine(" ------------------------------------------------------ ");

                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.ResetColor();

                    if (i == index)
                    {

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("   " + opciones[i] + "   ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("   " + opciones[i] + "   ");
                        Console.ResetColor();
                    }
                }

                tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.RightArrow)
                {
                    index++;

                    if (index > opciones.Length - 1)
                    {
                        index = 0;
                    }
                }
                else if (tecla == ConsoleKey.LeftArrow)
                {
                    index--;
                    if (index < 0)
                    {
                        index = opciones.Length - 1;
                    }
                }

            } while (tecla != ConsoleKey.Enter);

            switch (index)
            {
                case 0: SubmenuRegistro(); break;
            }

            return index;
        }

        public static void SubmenuRegistro()
        {
            string[] opciones = { " DOCENTE", " ESTUDIANTE", " CURSO", " VOLVER" };
            int seleccion = 0;
            ConsoleKey tecla;

            do
            {
                Console.SetCursorPosition(0, 4);
                
                for (int i = 0; i < opciones.Length; i++)
                {
                    if (i == seleccion)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(opciones[i] + "   ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(opciones[i] + "   ");
                        Console.ResetColor();
                    }
                }
                    
                tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.DownArrow)
                {
                    seleccion++;

                    if (seleccion > opciones.Length - 1)
                    {
                        seleccion = 0;
                    }
                }
                else if (tecla == ConsoleKey.UpArrow)
                {
                    seleccion--;
                    if (seleccion < 0)
                    {
                        seleccion = opciones.Length - 1;
                    }
                }

            } while (tecla != ConsoleKey.Enter);

            switch (seleccion)
            {
                case 0: Docente.Registrar(); break;
                case 1: Estudiante.Registrar(); break;
                case 2: Curso.Registrar(); break;
                case 3: OpcionMenu(); return;
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
            //SubmenuRegistro();
        }
    }

}
