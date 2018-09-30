using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public static class Triangle
    {
        public static bool Check(double AB, double BC, double CA)
        {
            if ((AB!=null&& BC != null&& CA != null) &&(AB > 0 && BC > 0 && CA > 0 ) &&!(AB + BC <= CA || AB + CA <= BC || BC + CA <= AB))
            { return true; }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (Triangle.Check(0.0000000000001, 0.0000000000001, 0.0000000000001)) Console.WriteLine("Норм");
            else Console.WriteLine("bad"); ;
        }
    }
}
