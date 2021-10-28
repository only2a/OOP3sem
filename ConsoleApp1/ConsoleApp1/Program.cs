using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool alive = true;
            bool isDead = false;

            byte bit1 = 1;
            byte bit2 = 102; /*хранит целое число от 0 до 255 и занимает 1 байт. */

            sbyte sbit1 = -101;
            sbyte sbit2 = 102; /* хранит целое число от -128 до 127 и занимает 1 байт.*/

            short n1 = 1;
            short n2 = 102; /* хранит целое число от -32768 до 32767 и занимает 2 байта.*/

            ushort un1 = 1;
            ushort un2 = 102; /* хранит целое число от 0 до 65535 и занимает 2 байта*/

            int a = 10; /*от -2147483648 до 2147483647 и занимает 4 байта*/
            int b = 0b101;  // бинарная форма b =5
            int c = 0xFF;   // шестнадцатеричная форма c = 255

            uint ua = 10;
            uint ub = 0b101; /*ранит целое число от 0 до 4294967295 и занимает 4 байта. */
            uint uc = 0xFF;

            long la = -10;
            long lb = 0b101;
            long lc = 0xFF;

            double kk = 73.4;
            float ff = 6.98f;
            decimal dd = 6.99m;
            char ca = 'A';
            char cb = '\x5A';
            char cc = '\u0420'; /*хранит одиночный символ в кодировке Unicode и занимает 2 байта.*/

            string hello = "Hello";
            string word = "world"; /*набор символов */

            object oa = 22;
            object ob = 3.14;
            object oc = "hello code"; /*mожет хранить значение любого типа данных и занимает 4 байта на 32-разрядной платформе и 8 байт на 64-разрядной платформе.*/

            string name = "Tom";
            int age = 33;
            bool isEmployed = false;
            double weight = 78.65;
            /*-------------------------------------*/
                /*явное преобразование */
            byte x = 4;
            short z = x;

            short m = 4;
            int k = m;
            /*явное преобразование*/
            int q = 4;
            short o = (short)q;

            int ai = 6;
            int bi = 8;
            byte cbb = (byte)(ai + bi);
            /*Convert*/

            Console.WriteLine("Введите возраст.");
            int agei = Convert.ToInt32(Console.ReadLine());
          
            

            Console.WriteLine("Введите рост(м)");
            double height = Convert.ToDouble(Console.ReadLine());
            /*---------------------------------------------------*/

            /*Упоковка и распоковка*/
            int a1 = 111;
            object o1 = a1;
            int j1 = (int)o1;
            a1 = 444;
            Console.WriteLine(a1);
            Console.WriteLine(j1);

            /*---------------------------------------------------*/
            /*Неявная типизация*/
            var hello2 = "hello,world";
            var c3= 2;
            Console.WriteLine(hello2.GetType().ToString());
            Console.WriteLine(c3.GetType().ToString());



           
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Вес: {weight}");
            Console.WriteLine($"Работает: {isEmployed}");
            /*---------------------------------------------------*/

            // этот код работает
            int a10;
            a10 = 20;

            // этот код не работает
            // var с2;
            // с2 = 20;
            int? x3 = null;
            int? x4 = null;
            Console.WriteLine(x3 == x4);
        }
    }
}
