using System;

namespace TimeClass
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Time t = new Time(10, 50);
                Console.WriteLine(t);
                string k = "11:46";
                Time s = Time.Parse(k);
                Console.WriteLine(s);
                Time z = s + 26;
                Time m = s - t;
                Console.WriteLine(z);
                Console.WriteLine(m);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            
        }
    }
}
