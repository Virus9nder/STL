namespace UnitTest
{
    public static class Figure
    {
        public static bool isTriangle(double AB, double BC, double CA)
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
          
        }
    }
}
