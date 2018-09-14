using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Calc
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
                foreach (var item2 in Calc.check)
                {
                    if (item == item2) ui = 1;
                }
                if (ui == 0) { Console.WriteLine("Введены некорректные данные, повторите ввод:"); x = Console.ReadLine(); return Calc.Do(x);  }
            }
            string cc2 = "";
            foreach (var item in x)
            {
                if (item == '.') cc2 += ',';
                else cc2 += item;
            }

            return double.Parse(cc2);
        }
        public static void Add()
        {

            Calc.c= Calc.a+ Calc.b;
        }
        public static void Sub()
        {

            Calc.c = Calc.a - Calc.b;
        }
        public static void Div()
        {

            Calc.c = Calc.a / Calc.b;
        }
        public static void Mull()
        {

            Calc.c = Calc.a * Calc.b;
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

                string A = Console.ReadLine();

                Calc.a = Calc.Do(A);
                Console.WriteLine("Введите B:");

                string B = Console.ReadLine();

                Calc.b = Calc.Do(B);
                Console.WriteLine("Выберите операцию:\n1-Сложение\n2-Вычитание\n3-Деление\n4-Умножение");
                int1= int.Parse(Console.ReadLine());
                switch (int1)
                {
                    case 1: Calc.Add(); break;
                    case 2: Calc.Sub(); break;
                    case 3: Calc.Div(); break;
                    case 4: Calc.Mull(); break;
                    default: Console.WriteLine("Введите корректные данные"); break;
                }
                Console.WriteLine("Ответ: "+ Calc.c);
            }

        }
    }
}
