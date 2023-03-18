using System;
using System.IO;

namespace test1111
{
    class Program
    {
        public struct Flights
        {
            public int number;
            public string paddres;
            public string address;
            public double bortime;
            public double distime;
            public data info;
           
            public void Print()
            {
                Console.WriteLine($"время высадки:\t{distime}\tвремя посадки:\t{bortime}\tадрес назначения:\t{address}\tадрес пассажира:\t{paddres}\tномер рейса:\t{number}");
            }

        }
        public struct data
        {
            public string name;
            public int overflights;
            public int children;
            public int crimrecords;
            public void Print()
            {
                Console.WriteLine($"имя:\t{name}\tкол-во перелетов:\t{overflights}\tдетей на борту\t{children}\tсудимостей\t{crimrecords}");
            }

        }

        static void Write(Flights[] ara, string name)
        {
            FileStream file = new FileStream(name, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(ara.Length);
            for (int i = 0; i < ara.Length; i++)
            {
                writer.Write(ara[i].number + "|" );
                writer.Write(ara[i].paddres +"|");
                writer.Write(ara[i].address + "|" );
                writer.Write(ara[i].bortime + "|" );
                writer.Write(ara[i].distime);
                writer.WriteLine();
            }
            writer.Close();
            file.Close();
        }
        static void Read(out Flights[] ar)
        {
            FileStream file = new FileStream("slozhno.txt", FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);
            int n = int.Parse(reader.ReadLine());
            ar = new Flights[n];
            for (int i = 0; i < n; i++)
            {
                String[] a = reader.ReadLine().Split("|");
                int j = 0;
                j = 0;
                ar[i].number = int.Parse(Convert.ToString(a[j]));
                j++;
                ar[i].paddres = Convert.ToString(a[j]);
                j++;
                ar[i].address = Convert.ToString(a[j]);
                j++;
                ar[i].bortime = int.Parse(Convert.ToString(a[j]));
                j++;
                ar[i].distime = int.Parse(Convert.ToString(a[j]));
            }
            reader.Close();
            file.Close();
            
        }
        
        static void Initial(Flights[] ara)
        {
            for (int i = 0; i < ara.Length; i++)
            {
                Console.WriteLine($"номер {i + 1}-го пассажира");
                ara[i].number = int.Parse(Console.ReadLine());
                Console.WriteLine($"адрес {i + 1}-го пассажира");
                ara[i].paddres = Console.ReadLine();
                Console.WriteLine($"адрес назначения {i + 1}-го пассажира");
                ara[i].address = Console.ReadLine();
                Console.WriteLine($"время посадки {i + 1}-го пассажира");
                ara[i].bortime = double.Parse(Console.ReadLine());
                Console.WriteLine($"время высадки  {i + 1}-го пассажира");

                ara[i].distime = double.Parse(Console.ReadLine());
            }
        }

        static Flights[] Search(Flights[] ara, string ad, out int count)
        {
            count = 0;
            string same = "";

            for (int i = 0; i < ara.Length; i++)
            {
                if (ara[i].address == ad)
                {
                    count++;
                    same += Convert.ToString(i);
                }
            }
            Flights[] newara = new Flights[count];
            char[] sm = same.ToCharArray();
            for (int i = 0; i < count; i++)
            {
                newara[i] = ara[int.Parse(Convert.ToString(sm[i]))];
            }
            Write(newara, "slozhno.txt");
            return newara;
        }

        static void Show(Flights[] ara)
        {
            for (int i = 0; i < ara.Length; i++)
            {
                ara[i].Print();
            }
        }
       
        static void Main(string[] args)
        {

            Console.WriteLine("на сколько хотите массив");
            int r = int.Parse(Console.ReadLine());
            Flights[] ara = new Flights[r];
            Initial( ara);
            int count = 0;
            Console.WriteLine("какой адрес назначения");
            string ad = Console.ReadLine();
            Flights[] ara2 = Search(ara, ad, out count);
            Console.WriteLine($"кол-во повторений: {count}");
            Show(ara2);
           

            Console.WriteLine("ВЫВОД ИЗ ФАЙЛА");
            
            Read(out Flights[] ar);
            Show(ar);
            


        }
    }
}
