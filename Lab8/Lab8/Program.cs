using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab8
{
    public class Node<T>
    {


        public Node(T data)
        {
            Data = data;
        }
        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> SetNextNode(Node<T> node) => Next = node;

    }

    public class Owner
    {
        private string _name;
        private string _organization;
        private static int Id;

        public Owner(string name, string organization)
        {
            this._name = name;
            this._organization = organization;
            Id++;
        }
        public void Print()
        {
            Console.WriteLine($"ID: {Id}\n" +
                $"Name: {_name}\n" +
                $"Organization: {_organization}");
        }
    }

    public class Date
    {
        private DateTime _time;

        public Date()
        {
            _time = DateTime.Now;
        }

        public void ShowDate()
        {
            Console.WriteLine(_time+"\n");
        }
    }


    public class LinkedList<T> : IGen<T> where T : class
    {
        Node<T> head;
        Node<T> tail;
        int count;

        public Node<T> GetHead() => head;

        public T this[int index]
        {
            get
            {
                if (index > count - 1 || index < 0) throw new WrongIndexException("ERROR: индекс");

                Node<T> temp = head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.Next;
                }

                return temp.Data;
            }
            set
            {
                if (index > count - 1 || index < 0) throw new WrongIndexException("ERROR: индекс");

                Node<T> temp = head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.Next;
                }

                temp.Data = value;
            }
        }





        public void Add(T item)// добавление элемента
        {
            Node<T> node = new Node<T>(item);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }

      
        

        

        public void ShowInfo() //Вывод списка
        {
            Node<T> node = head;
            while (node.Next != null)
            {
                Console.Write(node.Data + " --> ");
                node = node.Next;
            }
            Console.WriteLine(node.Data + "\n");
        }

        public bool Remove(T item) //Удаление по элементу
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {

                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head

                        head = head.Next;
                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public void Remove(int index)//Удаление по индексу 
        {
            if (this.count == 0)
            {
                Console.WriteLine("Список пуст!");
            }
            if (this.count == 1)
            {
                head = null;
            }
            if (index == 1)
            {
                Console.WriteLine($"Узел {head.Data} удалён!");
                head = head.Next;
                return;
            }

            Node<T> node = head;
            Node<T> nextNode = head.Next;

            for (int i = 0; i < index - 2; i++)
            {
                node = node.Next;
                nextNode = nextNode.Next;
            }
            Console.WriteLine($"Узел {nextNode.Data} удалён!");
            node.SetNextNode(nextNode.Next);
        }

        //public int Count { get { return count; } }
        //public bool IsEmpty { get { return count == 0; } }

        //public void Clear()   // очистка списка
        //{
        //    head = null;
        //    tail = null;
        //    count = 0;
        //}

        public bool Contains(T data)  // Проверка на наличие 
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        //public void AppendFirst(T data)// добвление в начало
        //{
        //    Node<T> node = new Node<T>(data);
        //    node.Next = head;
        //    head = node;
        //    if (count == 0)
        //        tail = head;
        //    count++;
        //}

        private Node<T> _tail = null;
        public void AddBack(T data)
        {
            if (head == null)
            {
                head = new Node<T>(data, null);
                _tail = head;
            }

            else
            {
                _tail.Next = new Node<T>(data, null);
                _tail = _tail.Next;
            }

            ++count;
        }

        public override string ToString()
        {
            var res = "";
            for (Node<T> pA = head; pA != null; pA = pA.Next)
            {
                res += pA.Data + " ";
            }
            return res;
        }



        #region Перегрузки
        public static LinkedList<T> operator +(LinkedList<T> A, LinkedList<T> B)
        {
            LinkedList<T> list = new LinkedList<T>();

            for (Node<T> p = A.head; p != null; p = p.Next)
                list.Add(p.Data);
            for (Node<T> p = B.head; p != null; p = p.Next)
                list.Add(p.Data);
            return list;
        }


        public static LinkedList<string> operator !(LinkedList<T> A)
        {

            string test = A.ToString();
            var strArr = test.Split(" ");
            string[] strArr2 = new string[strArr.Length - 1];
            Array.Copy(strArr, strArr2, strArr.Length - 1);
            LinkedList<string> list0 = new LinkedList<string>();
            for (int i = strArr2.Length - 1; i > -1; i--)
            {

                string temp = strArr2[i];
                //strArr2[i] = null;
                list0.Add(temp);
            }



            return list0;
        }

        public static LinkedList<T> operator --(LinkedList<T> A)
        {

            A.Remove(1);

            return A;
        }


        public static bool operator !=(LinkedList<T> A, LinkedList<T> B)
        {

            return A.ToString() != B.ToString();
        }
        public static bool operator ==(LinkedList<T> A, LinkedList<T> B)
        {
            return A.ToString() == B.ToString();
        }



        public static bool operator true(LinkedList<T> A)
        {
            return A.head == null;
        }
        public static bool operator false(LinkedList<T> A)
        {
            return A.head != null;
        }
        #endregion

        public class Owner
        {
            string id;
            string name;
            string edition;

            public Owner(string _ID, string _NAME, string _EDITION)
            {
                id = _ID;
                name = _NAME;
                edition = _EDITION;
            }
        }
        public class Date
        {
            DateTime time = new DateTime();

            public DateTime Time { get { return time; } set { this.time = value; } }
            public Date(DateTime time)
            {
                if (time != null)

                    this.time = time;
                else
                    this.time = DateTime.Now;
            }
        }




        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return ((IEnumerable)this).GetEnumerator();
        //}

        //    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        //    {
        //        Node<T> current = head;
        //        while (current != null)
        //        {
        //            yield return current.Data;
        //            current = current.Next;
        //        }
        //    }
    }



    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Console.ForegroundColor = ConsoleColor.Cyan;

                //LinkedList<string> list1 = new LinkedList<string>();
                //Console.Write("1й список: ");
                //list1.Add("word1");
                //list1.Add("word2");
                //list1.Add("word3");
                //list1.Add("word4");
                //list1.ShowInfo();

                //Console.ForegroundColor = ConsoleColor.DarkMagenta;
                //LinkedList<string> list2 = new LinkedList<string>();
                //Console.Write("2й список: ");
                //list2.Add("word5");
                //list2.Add("word6");
                //list2.Add("word7");
                //list2.Add("word8");
                //list2.ShowInfo();

                //Console.ForegroundColor = ConsoleColor.Green;
                //LinkedList<string> list1and2 = new LinkedList<string>();
                //Console.Write("\nОбъединение 1 и 2 списков: ");
                //list1and2 = list1 + list2;
                //list1and2.ShowInfo();

                //Console.ForegroundColor = ConsoleColor.Gray;
                //Console.WriteLine("\nУдаление первого элемента(перегрузка) и 4 выбором:");
                //--list1and2;
                //list1and2.Remove("word4");
                //list1and2.ShowInfo();


                //Console.ForegroundColor = ConsoleColor.Red;
                //if (list1 == list2) Console.WriteLine("\nРавенство 1 и 2 списков:\n------Списки равны------"); else if (list1 != list2) Console.WriteLine("\nРавенство 1 и 2 списков:\n------Списки не равны------");
                //LinkedList<string> list11 = new LinkedList<string>();
                //Console.Write("Список для сравнения с 1м: ");
                //list11.Add("word1");
                //list11.Add("word2");
                //list11.Add("word3");
                //list11.Add("word4");
                //list11.ShowInfo();
                //if (list1 == list11) Console.WriteLine("Равенство 1 и идентичного ему списков:\n------Списки равны------"); else if (list1 != list11) Console.WriteLine("\nРавенство 1 и 2 списков:\n------Списки не равны------");




                //LinkedList<string> emptyList = new LinkedList<string>();
                //if (emptyList)
                //    Console.WriteLine("\nСписок пустой!\n");


                Console.ForegroundColor = ConsoleColor.Yellow;
                LinkedList<string> list3 = new LinkedList<string>();
                Console.Write("3й список: ");
                list3.Add("Hello");
                list3.Add("Hell");
                list3.Add("DontBe3Sad");
                list3.Add("HaveAGoodTime51");
                list3.ShowInfo();

                Console.WriteLine(list3[0]+"\n");
                list3[0] = "Olleh";
                list3.ShowInfo();

                //Console.WriteLine($"Общая длина элементов списка:{list3.Sum()}");
                //Console.WriteLine($"Разница между длинами максимальной и минимальной строк: {list3.Difference()}");
                //Console.WriteLine($"В списке {list3.CountOfS()} элементов(a)");
                //Console.WriteLine($"Последнее число в списке {list3.LastNumb()} \n");
                //Console.ForegroundColor = ConsoleColor.White;

             



                //Owner own = new Owner("Dmitry", "BSTU");
                //own.Print();

                //Date d = new Date();
                //d.ShowDate();
                Console.ForegroundColor = ConsoleColor.Magenta;

                INfile.WriteToFile(!list3);

                LinkedList<string> FromFile = new LinkedList<string>();
                FromFile.Add("WORD1");
                INfile.ReadFromFile(ref FromFile);
                FromFile.ShowInfo();

                bool b=FromFile.Contains("WORD1");
                Console.WriteLine(b);

                Console.ForegroundColor = ConsoleColor.DarkRed;
                LinkedList<Pastry> pastry = new LinkedList<Pastry>();
                pastry.Add(new Cake());
                pastry.Add(new Sweets());
                pastry.ShowInfo();
               

            }
            catch (WrongIndexException ex) { Console.WriteLine(ex); }
            catch (WrongElementException ex) { Console.WriteLine(ex); }
            finally { Console.WriteLine("FINALLY:That's all.\n"); }



           

            

         
        }
    }
}
