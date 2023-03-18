using System;

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
            //Flights(int number, string paddres, string address, double bortime, double distime)
            //{
            //    this.number = number;
            //    this.paddres = paddres;
            //    this.address = address;
            //    this.bortime = bortime;
            //    this.distime = distime;
            //}
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
            public  void Print()
            {
                Console.WriteLine($"имя:\t{name}\tкол-во перелетов:\t{overflights}\tдетей на борту\t{children}\tсудимостей\t{crimrecords}");
            }

        }
        static Flights deflt()
        {
            Flights def = new Flights();
            def.number = 0;
            def.paddres = "homeless";
            def.address = "to nowhere";
            def.bortime = 0;
            def.distime = 0;
            def.info.name = "None";
            def.info.overflights = 0;
            def.info.children = 0;
            def.info.crimrecords = 0;
            return def;
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
       static Flights[] Search(Flights[] ara,string ad, out int count)
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
        static void Pov(Flights[] ara)
        {
            int count = 0;
            string same = "";
            for (int i = 0; i < ara.Length; i++)
            {
                same = "";
                count = 0;


                for (int j = 0; j < ara.Length; j++)
                {

                    if (ara[i].address == ara[j].address)
                    {
                        count++;
                        same += Convert.ToString(j);
                    }
                }
                char[] sm = same.ToCharArray();
                if (sm.Length > 1)
                {
                    string keyword = ara[int.Parse(Convert.ToString(sm[0]))].address;

                    Console.WriteLine($"Кол-во повторений:{count}");
                    for (int u = 0; u < sm.Length; u++)
                    {
                        ara[int.Parse(Convert.ToString(sm[u]))].Print();
                    }
                    for (int u = 0; u < sm.Length; u++)
                    {
                        Remuve(ref ara, keyword);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("не повторяются вообще");
            for (int i = 0; i < ara.Length; i++)
            {
                ara[i].Print();
            }
        }
        static void Remuve(ref Flights[] ara, string str)
        {
            int key = -1;
            for (int i = 0; i < ara.Length; i++)
            {
                if (ara[i].address == str)
                {
                    key = i;
                }
            }
            if(key == -1) { return; }

            Flights[] newara = new Flights[ara.Length - 1];
            for (int i = 0; i < key; i++)
            {
                newara[i] = ara[i];
            }
            for (int i = key +1; i <ara.Length ; i++)
            {
                newara[i-1] = ara[i];
            }
            ara = newara;
        }
        static void Show(Flights[] ara)
        {
            for (int i = 0; i < ara.Length; i++)
            {
                ara[i].Print();
            }
        }
        static Flights[] Sercone(Flights [] ara,string paddres)
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
                if (ara[i].bortime==pos && ara[i].distime == vis)
                {
                    o[j] = ara[i];
                    j++;
                }
            }
            return o;
        }
        static void InitialSh( Flights[] inf)
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
            Flights [] o = new Flights[jj];
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

            Initial(ara);
            Console.WriteLine("метод вывода инфы о всех пассажирах");
            Show(ara);
            //Console.WriteLine("метод вывода информации о повторяющихся рейсах");
            //Pov(ara);
            Console.WriteLine("кол-во повторений и новый массив" +
                "\n по какому адресу хотите искать");
            string ad = Console.ReadLine();
            
            Flights[] poisk = Search(ara, ad, out int count);
            Show(poisk);
            Console.WriteLine($"кол-во повторений {count}");
            
            //Console.WriteLine("метод поиска данных по адресу: какой адрес вы хотите найти:");
            //string paddres = Console.ReadLine();
            //Flights[] t1 = Sercone(ara,paddres);
            //Show(t1);
           
            //Console.WriteLine("метод поиска данных по  посадкe и высадкe");
            //Console.WriteLine("время посадки");
            //double pos = double.Parse(Console.ReadLine());
            //Console.WriteLine("время высадки");
            //double vis = double.Parse(Console.ReadLine());
            //Flights[] t2 = Searchtwo(ara,pos,vis);
            //Show(t2);
            //Console.WriteLine("создание вложенной стурктуры");
            //Console.WriteLine("на сколько массив:");

            //int razm = int.Parse(Console.ReadLine());
            //Flights[] sh = new Flights[razm];

            //Console.WriteLine("заполнение нового массива");
            //InitialSh(sh);

            //Console.WriteLine("поиск по новой строке\n");

            //Console.WriteLine("метод по выявлению судимостей\n");
            //Console.WriteLine("какое кол-во судимостей вас интересует\n");
            //int count = int.Parse(Console.ReadLine());
            //Flights[] t3 = Gotojail(sh,count);
            //Show(t3);

        }
    }
}
