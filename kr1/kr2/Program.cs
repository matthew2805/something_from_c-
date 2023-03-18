using System.Text;

namespace kr2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StringWorker sw = new StringWorker(5);
            sw.Line = "yasosubibu";
            Console.WriteLine(sw.Line);
        }
    }
}