using System;
using System.IO;

namespace lab2
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
        static void Write(Flights[]ara, string name)
        {
            FileStream file = new FileStream(name, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(ara.Length);
            for (int i = 0; i < ara.Length; i++)
            {
                writer.Write(ara[i].number +" ");
                writer.Write(ara[i].paddres+" ");
                writer.Write(ara[i].address+" ");
                writer.Write(ara[i].bortime+" ");
                writer.Write(ara[i].distime+" ");
                writer.WriteLine();
            }
            writer.Close();
            file.Close();
        } 
        static void Read(string name)
        {
            FileStream file = new FileStream(name, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);

            reader.Close();
            file.Close();

        }
        static void Initial(ref Flights[] ara)
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
            return newara;
        }
        
        static void Show(Flights[] ara)
        {
            for (int i = 0; i < ara.Length; i++)
            {
                ara[i].Print();
            }
        }
        static void ShowSh(Flights[] ara)
        {
            for (int i = 0; i < ara.Length; i++)
            {
                ara[i].info.Print();
            }
        }
        static Flights[] Sercone(Flights[] ara, string paddres)
        {

            int count = 0;
            for (int i = 0; i < ara.Length; i++)
            {
                if (ara[i].paddres == paddres)
                {
                    count++;
                }
            }
            Flights[] o = new Flights[count];
            int j = 0;
            for (int i = 0; i < ara.Length; i++)
            {
                if (ara[i].paddres == paddres)
                {
                    o[j] = ara[i];
                    j++;
                }
            }
            return o;
        }
        static Flights[] Searchtwo(Flights[] ara, double pos, double vis)
        {

            int count = 0;
            for (int i = 0; i < ara.Length; i++)
            {
                if (ara[i].bortime == pos && ara[i].distime == vis)
                {
                    count++;
                }
            }
            Flights[] o = new Flights[count];
            int j = 0;
            for (int i = 0; i < ara.Length; i++)
            {
                if (ara[i].bortime == pos && ara[i].distime == vis)
                {
                    o[j] = ara[i];
                    j++;
                }
            }
            return o;
        }
        static void InitialSh(Flights[] inf)
        {
            for (int i = 0; i < inf.Length; i++)
            {
                Console.WriteLine("как вас зовут");
                inf[i].info.name = Console.ReadLine();
                Console.WriteLine("сколько детей с вами:");
                inf[i].info.children = int.Parse(Console.ReadLine());
                Console.WriteLine("сколько раз вы уже вылетали:");
                inf[i].info.overflights = int.Parse(Console.ReadLine());
                Console.WriteLine("сколько у вас судимостей:");
                inf[i].info.crimrecords = int.Parse(Console.ReadLine());
            }
        }
        static Flights[] Gotojail(Flights[] inf, int count)
        {

            int jj = 0;
            for (int i = 0; i < inf.Length; i++)
            {
                if (inf[i].info.crimrecords > count)
                {
                    jj++;
                }
            }
            Flights[] o = new Flights[jj];
            int g = 0;
            for (int i = 0; i < inf.Length; i++)
            {

                if (inf[i].info.crimrecords > count)
                {
                    o[g].info = inf[i].info;
                    g++;
                }
            }
            return o;
        }

        static void Main(string[] args)
        {



            Console.WriteLine("на сколько хотите массив");
            int n = int.Parse(Console.ReadLine());
            Flights[] ara = new Flights[n];
            Initial(ref ara);
            //Write(ara, "fileee.txt");
            //Flights[] t1;
            int meny = 0;
            bool fl = true;

            Console.WriteLine("какие ваши дальнейшие действия:" +
                "\nвыберите 1 если хотите вызвать массив на экран" +
                "\nвыберите 2 если хотите запустить метод по нахождению повторяющихся элементов" +
                "\nвыберите 3 если хотите запустить метод по поиску одного элемета" +
                "\nвыберите 4 если хотите запустить метод по поиску двух элементов" +
                "\nвыберите 5 если хотите создать вложенную структуру" +
                "\nвыберите 6 если хотите выйти из меню");

            while (true && fl == true)
            {
                meny = int.Parse(Console.ReadLine());

                switch (meny)
                {

                    case 1:
                        Show(ara);
                        break;
                    case 2:
                        int count = 0;
                        Console.WriteLine("какой адрес");
                        string ad = Console.ReadLine();
                        Flights [] ar = Search(ara,ad,out count);
                        Show(ar);
                        Console.WriteLine($"кол-во повторений: {count}");
                        break;
                    case 3:
                        Console.WriteLine("введтите адрес котрый хотите найти:");
                        string paddres = Console.ReadLine();

                        Flights[] a = Sercone(ara,paddres);
                        Show(a);
                        break;
                    case 4:
                        Console.WriteLine("введите время высадки и посадки ");
                        int vis = int.Parse(Console.ReadLine());
                        int pos = int.Parse(Console.ReadLine());
                        Flights[] b = Searchtwo(ara,vis,pos);
                        Show(b);
                        break;
                    case 5:
                        Console.WriteLine("на сколько хотите массив");
                        int razm = int.Parse(Console.ReadLine());
                        Flights[] sh = new Flights[razm];
                        Console.WriteLine("меню вложенного массива:" +
                            "\nвыберите 1 для инициализации массива" +
                            "\nвыберите 2 для поиска по строке массива" +
                            "\nвыберите 3 для выхода из меню");
                        int meny2 = 0;
                        bool fl2 = true;
                        while (fl2 == true)
                        {
                            meny2 = int.Parse(Console.ReadLine());
                            switch (meny2)
                            {
                                case 1:

                                    InitialSh(sh);
                                    ShowSh(sh);
                                    break;
                                case 2:
                                    if (sh[0].info.name == null && sh[0].info.children == 0 && sh[0].info.overflights == 0 & sh[0].info.crimrecords == 0)
                                    {
                                        Console.WriteLine("вы не заполнили массив данными".ToUpper());
                                    }
                                    else
                                    {
                                        Console.WriteLine("какое кол-во судимостей вас интересует:");
                                        int count1 = int.Parse(Console.ReadLine());
                                        sh = Gotojail(sh,count1);
                                        ShowSh(sh);
                                    }

                                    break;
                                case 3:
                                default:
                                    fl2 = false;
                                    break;


                            }
                            Console.WriteLine("что хотите делать дальше");
                        }
                        break;
                    case 6:
                    default:
                        fl = false;
                        break;

                }
                Console.WriteLine("что хотите делать дальше");
            }
        }
    }
}
