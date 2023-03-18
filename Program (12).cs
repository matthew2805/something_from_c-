using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab3
{
    class Program
    {
        
        static int[,] Crea()
        {
            int o = 0;
            int perv = 0;
            int[,] chis = new int[12, 10];
            for (int y = 0; y < chis.GetLength(0); y++)
            {
                perv = perv + 10;
                o = 0;
                for(int x = 0; x < chis.GetLength(1); x++)
                {
                    chis[y, x] = perv - o;
                    o++;  
                }


            }

            return chis;
        } 
        static void Save(int[,] ara,string nameoffile)
        {
            int a = ara.GetLength(0);
            int b = ara.GetLength(1);
            FileStream file = new FileStream(nameoffile, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(a);
            writer.WriteLine(b);
            for (int i = 0; i < ara.GetLength(0); i++)
            {
                for (int j = 0; j < ara.GetLength(1); j++)
                {
                    writer.Write(ara[i, j] + " ");
                }
            }
            writer.Close();
            file.Close();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("создание массива");

            int[,] ara = Crea();
            int a = ara.GetLength(0);
            int b = ara.GetLength(1);
            Console.WriteLine();
            for (int i = 0; i < a; i++)
            {

                for (int j = 0; j < b; j++)
                {
                    Console.Write(ara[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("сохранение в файл\nкак будет называться ваш файл:");
            string nameoffile = Console.ReadLine();
            nameoffile = nameoffile + ".txt";
            Save(ara, nameoffile);


            //FileStream file2 = new FileStream("copy.txt", FileMode.Open);
            //StreamReader reader = new StreamReader(file2);
            //string a2 = reader.ReadLine();
            //string b2 = reader.ReadLine();
            //string g = reader.ReadLine();
            //string [] n = g.Split(" ");
            //int[,] sss = new int[a,b];
            //int f = 0;

            //for(int i = 0; i < a; i++)
            //{

            //    for (int j = 0; j < b; j++)
            //    {
            //        sss[i, j] = int.Parse(n[f]);
            //        f++;
            //    }
            //}
            //for (int i = 0; i < a; i++)
            //{

            //    for (int j = 0; j < b; j++)
            //    {
            //        Console.Write(sss[i,j]+ "\t");
            //    }
            //    Console.WriteLine();
            //}
            //reader.Close();
            //file.Close();








        }

        
    }
}
