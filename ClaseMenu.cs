using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("           SISTEMA DE GESTION DE ASISTENCIAS            ");
                Console.WriteLine("--------------------------------------------------------");

                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.ResetColor();

                    if (i == index)
                    {

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.Write(" > " + opciones[i] + "   ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("   " + opciones[i] + "   ");
                        Console.ResetColor();
                    }
                }


                tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.RightArrow) index = (index + 1) % opciones.Length;
                else if (tecla == ConsoleKey.LeftArrow) index = (index - 1 + opciones.Length) % opciones.Length;

            } while (tecla != ConsoleKey.Enter);

            switch (index)
            {
                //case 0: SubmenuRegistro(); break;
                //case 2: SubmenuReportes(); break;
                case 3: Environment.Exit(0); break;
            }

            return index;
        }
    }
}
