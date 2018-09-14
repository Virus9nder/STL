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
        public static Double First;
        public static Double Second;
        public static Double c;
        public static Double Correct(string x)
        {
            int ui = 0;
            foreach (var item in x)
            {
                foreach (var item2 in Calc.check)
                {
                    if (item == item2) ui = 1;
                }
                if (ui == 0) { Console.WriteLine("Введены некорректные данные, повторите ввод:"); x = Console.ReadLine(); return Calc.Correct(x);  }
            }
            string cc2 = "";
            foreach (var item in x)
            {
                if (item == '.') cc2 += ',';
                else cc2 += item;
            }

            return Double.Parse(cc2);
        }
        public static void Add()
        {

            Calc.c= Calc.First + Calc.Second;
        }
        public static void Sub()
        {

            Calc.c = Calc.First - Calc.Second;
        }
        public static void Div()
        {

            Calc.c = Calc.First / Calc.Second;
        }
        public static void Mull()
        {

            Calc.c = Calc.First * Calc.Second;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            int int1 = 0;
            while (true)
            {
                Console.WriteLine("Введите A:");

                string A = Console.ReadLine();

                Calc.First = Calc.Correct(A);
                Console.WriteLine("Введите B:");

                string B = Console.ReadLine();

               Calc.Second = Calc.Correct(B);
                Console.WriteLine("Выберите операцию:\n\t1-Сложение\n\t2-Вычитание\n\t3-Деление\n\t4-Умножение");

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
