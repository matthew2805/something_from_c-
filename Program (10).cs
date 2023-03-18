using System;
using System.IO;

namespace lab3_3
{
    class Program
    {
        static int[,] Generate(int n)
        {
            int[,] zal = new int[n, n];
            Random gena = new Random();
            for (int y = 0; y < zal.GetLength(0); y++)
            {
                for (int x = 0; x < zal.GetLength(1); x++)
                {
                    zal[y, x] = gena.Next(0,9);
                }

            }
            return zal;
        }
        static void Writer()
        {
            Random gena = new Random();
            Console.WriteLine("на сколько массив:");
            int strok = int.Parse(Console.ReadLine());
            int[,] ara2 = new int[strok, strok];
            FileStream file1 = new FileStream("input2.txt", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(file1);
            writer.WriteLine(strok);
            for (int i = 0; i < ara2.GetLength(0); i++)
            {
                for (int j = 0; j < ara2.GetLength(1); j++)
                {
                    writer.Write((ara2[i, j] = gena.Next(0,9))+" ");
                }
            }
            writer.Close();
            
            file1.Close();
            
           

        }
        static int[,] Generate()
        {

            
            FileStream file = new FileStream("input2.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file);

            int strok = int.Parse(reader.ReadLine());
            
            int[,] ara2 = new int[strok, strok];

            string a = reader.ReadLine();
            string[] a2 = a.Split(" ");

            int count = 0;
            for (int i = 0; i < strok; i++)
            {
                for (int j = 0; j < strok; j++)
                {
                    ara2[i, j] = int.Parse(a2[count]);
                    count++;
                }
                
            }
            reader.Close();
            file.Close();
            return ara2;
        }
        static int[] Soulition(int[,] dio)
        {
            int[] nadpobbdio = new int[dio.GetLength(0) - 1];
            int i = dio.GetLength(0) - 1;
            int j = 0;
            while (i > 0)
            {
                i--;
                while (j < dio.GetLength(0) - 1)
                {

                    nadpobbdio[i] = dio[i, j];
                    j++;
                    break;
                }
            }
            return nadpobbdio;
        }
        static void Zapis(int[]ara, string name)
        {
            FileStream file = new FileStream(name, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(ara.Length);
            for (int i = 0; i < ara.GetLength(0); i++)
            {
                writer.Write(ara[i] + " ");
            }
            writer.Close();
            file.Close();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("на сколько массив:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("генерация массива случ числами:");
            int[,] dio = Generate(n);
            for (int i = 0; i < dio.GetLength(0); i++)
            {
                for (int j = 0; j < dio.GetLength(1); j++)
                {
                    Console.Write(dio[i, j] + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("запись масива в файл:");
            Writer();
            Console.WriteLine();
            Console.WriteLine("извлечение массива из файла:");
            int[,] dio2 = Generate();
            for (int i = 0; i < dio2.GetLength(0); i++)
            {
                for (int j = 0; j < dio2.GetLength(1); j++)
                {
                    Console.Write(dio2[i, j] + "  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("результат работы с первым массивом:");
            Console.WriteLine();
            int[] nadpobdio = Soulition(dio);
            Zapis(nadpobdio, "дата1.txt");
            int[] nadpobdio2 = Soulition(dio2);
            Zapis(nadpobdio2, "дата2.txt");

        }

       
    }
}
