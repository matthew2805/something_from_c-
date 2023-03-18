using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace lab3_2
{
    class Program
    {
        static void Solution(int[,] zal)
        {
            Console.WriteLine("какой ряд вы хотите заполнить");
            int rm = int.Parse(Console.ReadLine());

            int count = 0;
            try
            {
                for (int i = 0; i < zal.GetLength(1); i++)
                {

                    Console.WriteLine($"введите информацию о месте: ряд{rm} место{i} (1 ; 0)");
                    zal[rm - 1, i] = int.Parse(Console.ReadLine());
                    if (zal[rm - 1, i] > 1 || zal[rm - 1, i] < 0)
                    {
                        throw new Exception("введенные данные могут быть только 1 или 0");
                    }
                    count += zal[rm - 1, i];

                }
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

            finally
            {
                Console.WriteLine($"кол-во забронированных мест: {count}");
            }

        }
        static int[,] Fulthezal(int r, int m)
        {
            int[,] zal = new int[r,m];
            Random gena = new Random();
            for (int y = 0; y < zal.GetLength(0); y++)
            {
                for (int x = 0; x < zal.GetLength(1); x++)
                {
                    zal[y, x] = gena.Next(0, 2);
                }
                
            }
            return zal;
        }
        static int[,] Fulthezal()
        {
            
            
            FileStream file = new FileStream("input.txt",FileMode.Open);
            StreamReader reader = new StreamReader(file);

            int strok = int.Parse(reader.ReadLine());
            int stolb = int.Parse(reader.ReadLine());
            int[,] zal = new int[strok, stolb];

            string mass = reader.ReadLine();
            string[] mass2 = mass.Split(" ");

            int count = 0;
            for (int i = 0; i < strok; i++)
            {
                for (int j = 0; j < stolb; j++)
                {
                        zal[i, j] = int.Parse(mass2[count]);
                        count++;
                }
            }
            reader.Close();
            file.Close();
            return zal;
        }
        static int[,] Gene(int r2, int m2)
        {
            int[,]ara = new int[r2, m2];
            Random gena = new Random();
            for (int i = 0; i < ara.GetLength(0); i++)
            {
                for (int j = 0; j < ara.GetLength(1); j++)
                {
                    ara[i, j] = gena.Next(0, 2);
                }
            }
            return ara;
        }
        static void Writer(int[,] ara2)
        {
            int strok = ara2.GetLength(0);
            int stolb = ara2.GetLength(1);
            FileStream file = new FileStream("input.txt",FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(strok);
            writer.WriteLine(stolb);
            for (int i = 0; i < ara2.GetLength(0); i++)
            {
                for (int j = 0; j < ara2.GetLength(1); j++)
                {
                    writer.Write(ara2[i, j]+" ");
                }
            }
            writer.Close();
            file.Close();
            

        }
        static void Main(string[] args)
        {
            Console.WriteLine("сколько рядов");
            int r = int.Parse(Console.ReadLine());
            Console.WriteLine("сколько мест");
            int m = int.Parse(Console.ReadLine());
            int[,] zal1 = Fulthezal(r, m);
            Console.WriteLine(  "так выглядит зал 1");
            for (int i = 0; i < zal1.GetLength(0); i++)
            {
                for (int j = 0; j < zal1.GetLength(1); j++)
                {
                    Console.Write(zal1[i,j]+" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("сколько рядов");
            int r2 = int.Parse(Console.ReadLine());
            Console.WriteLine("сколько мест");
            int m2 = int.Parse(Console.ReadLine());

            int[,] ara2 = Gene(r2, m2);

            Console.WriteLine();
            Writer(ara2);

            
            int[,] zal2 = Fulthezal();
            Console.WriteLine("так выглядит зал 2");
            for (int i = 0; i < zal2.GetLength(0); i++)
            {
                for (int j = 0; j < zal2.GetLength(1); j++)
                {
                    Console.Write(zal2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("работа с первым залом");
            Solution(zal1);
            Console.WriteLine("второй зал");
            Solution(zal2);
        }
    }
}
