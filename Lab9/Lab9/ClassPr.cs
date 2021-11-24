using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab9
{
    class ClassPr
    {
        public delegate void Words(List<string> list);
        public event Words Removee;
        public event Words Change;

        public delegate void Words2(List<string> list);
        public event Words2 Addd;


        public void ADD(List<string> list)
        {
            string item = Console.ReadLine();
            list.Add(item);

            Addd?.Invoke(list);
        }
        public void Remove(List<string> list)
        {
            Console.WriteLine("");
            int ind = int.Parse(Console.ReadLine());
            list.RemoveAt(ind);

            Removee?.Invoke(list);
        }

        public void Mutate(List<string> list)
        {
            Random rand = new Random();
            List<string> NL = list.OrderBy(item => rand.Next()).ToList();
            list.Clear();
            list.AddRange(NL);

            Change?.Invoke(list);
        }
    }
}
