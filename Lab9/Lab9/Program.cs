using System;
using System.Collections.Generic;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassPr.Words Words;
           
            ClassPr programmer = new ClassPr();
            List<string> list = new List<string> { "Walther_P99", "FN_Five_Seven", "Smith&Wesson", "Beretta_92", "Glock_17", "TAR-21", "АК-12", "Винторез", "Barrett M82" };

            Console.Write("Начальный список: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (string item in list)
            {
                Console.Write(item + "   ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            programmer.Removee += list =>
            {
                Console.Write("Меняй: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                foreach (string item in list)
                {
                    Console.Write(item + "   ");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            };

            programmer.Change += list =>
            {
                Console.Write("Меняй: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                foreach (string item in list)
                {
                    Console.Write(item + "   ");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            };

            Words = programmer.Remove;
            Words += programmer.Remove;
            Words += programmer.Mutate;
            Words += programmer.Mutate;
            Words(list);





            ClassPr.Words2 Words2;
            ClassPr programm = new ClassPr();
            List<string> list2 = new List<string>();
            Console.Write("Второй список: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var elem in list)
            {
                list2.Add(elem);
                Console.Write(elem + "   ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            programm.Addd += list2 =>
             {
                 Console.Write("Добавлено : ");
                 Console.ForegroundColor = ConsoleColor.DarkYellow;
                 foreach (string elem in list2)
                 {
                     Console.Write(elem + "   ");
                 }
                 Console.WriteLine();
                 Console.ForegroundColor = ConsoleColor.White;
             };
            Words2 = programm.ADD;
            Words2 += programm.ADD;
            Words2(list2);




            Func<string, string> A;
            string str = "ADS,,, , ; . sdase";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\n\n\nString: {str}");
            A = Str.RemovePunctuation;
            Console.WriteLine($"{A.Method.Name}: {A(str)}");
            A = Str.AddSymbol;
            Console.WriteLine($"{A.Method.Name}: {A(str)}");
            A = Str.ToUpper;
            Console.WriteLine($"{A.Method.Name}: {A(str)}");
            A = Str.ToLower;
            Console.WriteLine($"{A.Method.Name}: {A(str)}");
            A = Str.RemoveSpace;
            Console.WriteLine($"{A.Method.Name}: {A(str)}");
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
