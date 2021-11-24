using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab8
{
    class INfile
    {
        
            public static void WriteToFile(LinkedList<string> list)
            {
                using (StreamWriter sw = new StreamWriter(@"D:\ПроектыКЯР\ООП\ЛАБЫ\Lab8\Lab8\input.txt"))
                {
                    Node<string> temp = list.GetHead();
                    while (temp.Next != null)
                    {
                        sw.Write($"{temp.Data} --> ");
                        temp = temp.Next;
                    }
                    sw.Write(temp.Data);
                }
            }

            public static void ReadFromFile(ref LinkedList<string> list)
            {
                using (StreamReader sw = new StreamReader(@"D:\ПроектыКЯР\ООП\ЛАБЫ\Lab8\Lab8\input.txt"))
                {
                    string[] items = sw.ReadToEnd().Split(" --> ");
                    foreach (string item in items)
                    {
                        list.Add(item);
                    }
                }
            }
        
    }
}
