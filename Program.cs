using System.Runtime.InteropServices;
using System;
using System.IO;

namespace MediaProject
{
    class Program
    {

        static void Main(string[] args)
        {

            string selectOption = "";
        andAgain:
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine();
            System.Console.Write("[S]earch\t[L]ist\t\t[E]xit\t ");
            selectOption = Console.ReadLine();
            if (selectOption == "E" || selectOption == "e")
            {
                System.Environment.Exit(0);
            }

            if (selectOption == "S" || selectOption == "s")
            {

                MovieProcess movieProcess = new MovieProcess();
                goto andAgain;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                System.Console.WriteLine("\nThe Movie List\n");
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine(File.ReadAllText("movies.csv"));

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                System.Console.WriteLine("\nThe Show List\n");
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine(File.ReadAllText("shows.csv"));

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                System.Console.WriteLine("\nThe Video List\n");
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine(File.ReadAllText("videos.csv"));

            }
            goto andAgain;



        }



    }

}


