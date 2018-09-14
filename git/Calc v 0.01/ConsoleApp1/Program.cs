using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class F
    {
        private static string check = "0123456789,.";
        public static double a;
        public static double b;
        public static double c;
        public static double Do(string x)
        {
            int ui = 0;
            foreach (var item in x)
            {
                foreach (var item2 in F.check)
                {
                    if (item == item2) ui = 1;
                }
                if (ui == 0) { Console.WriteLine("Введены некорректные данные, повторите ввод:"); x = Console.ReadLine(); return F.Do(x);  }
            }
            string cc2 = "";
            foreach (var item in x)
            {
                if (item == '.') cc2 += ',';
                else cc2 += item;
            }

            return double.Parse(cc2);
        }
        public static void C1()
        {
            
            F.c= F.a+F.b;
        }
        public static void C2()
        {

            F.c = F.a - F.b;
        }
        public static void C3()
        {

            F.c = F.a / F.b;
        }
        public static void C4()
        {

            F.c = F.a * F.b;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from Virus:)");
            
            int int1 = 0;
            while (true)
            {
                Console.WriteLine("Введите A:");

                string cc = Console.ReadLine();

                F.a = F.Do(cc);
                Console.WriteLine("Введите B:");

                cc = Console.ReadLine();

                F.b = F.Do(cc);
                Console.WriteLine("Выберите операцию:\n1-Сложение\n2-Вычитание\n3-Деление\n4-Умножение");
                int1= int.Parse(Console.ReadLine());
                switch (int1)
                {
                    case 1: F.C1(); break;
                    case 2: F.C2(); break;
                    case 3: F.C3(); break;
                    case 4: F.C4(); break;
                    default: Console.WriteLine("Введите корректные данные"); break;
                }
                Console.WriteLine("Ответ: "+F.c);
            }

        }
    }
}
