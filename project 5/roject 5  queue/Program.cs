using roject_5__queue;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace project_5
{
    class Program
    {

        public static bool CheckGlas(string str, char[] glas,Queue<string> startwa)
        {
            char startletter = (char)str[0];
            if (glas.Contains(Char.ToUpper(startletter)))
            {
               
                return true;
            }
            else
                return false;
        }
        public static bool CheckSogl(string str, char[] sogl, Queue<string> startwb)
        {
            char startletter = (char)str[0];
            if (sogl.Contains(Char.ToUpper(startletter)))
            { 
                return true;
            }
            else
                return false;
        }
        static void Main(String[] args)
        {
            ///------------------------------------------------------------------------------------------------------------------
            ///1)
            //string path1 = @"D:\files\nums.txt";

            //StreamReader reader = new StreamReader(path1);
            //string[] ab = reader.ReadLine().Split(" ");
            //int a = int.Parse(ab[0]);
            //int b = int.Parse(ab[1]);
            //int[] nums = Array.ConvertAll(reader.ReadToEnd().Split(" "), int.Parse);
            //reader.Close();
            //Queue<int> lessthana = new Queue<int>();
            //Queue<int> morethanb = new Queue<int>();
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] >= a && nums[i] <= b)
            //    {
            //        Console.Write(nums[i] + " ");
            //    }
            //    else if (nums[i] < a)
            //    {
            //        lessthana.Enqueue(nums[i]);
            //    }
            //    else if (nums[i] > b)
            //    {
            //        morethanb.Enqueue(nums[i]);
            //    }
            //}
            //Console.WriteLine();
            //while (lessthana.Count > 0)
            //{
            //    Console.Write(lessthana.Dequeue() + " ");
            //}
            //Console.WriteLine();
            //while (morethanb.Count > 0)
            //{
            //    Console.Write(morethanb.Dequeue() + " ");
            //}
            /////------------------------------------------------------------------------------------------------------------------
            /// 2)
            //string path2 = @"D:\files\words.txt";

            //StreamReader reader = new StreamReader(path2);

            //string[] ara = reader.ReadToEnd().Split(" ");

            //reader.Close();
            //char[] glas = new char[] { 'A', 'E', 'O', 'I', 'U', 'Y' };
            //char[] sogl = new char[] { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z' };
            //Queue<string> startwa = new Queue<string>();
            //Queue<string> startwb = new Queue<string>();
            //for (int i = 0; i < ara.Length; i++)
            //{
            //    if (CheckGlas(ara[i], glas, startwa))
            //    {
            //        startwa.Enqueue(ara[i]);
            //    }
            //    else if (CheckSogl(ara[i], sogl, startwb))
            //    {
            //        startwb.Enqueue(ara[i]);
            //    }
            //}
            //while (startwa.Count > 0)
            //{
            //    Console.Write(startwa.Dequeue() + " ");
            //}
            //Console.WriteLine();
            //while (startwb.Count > 0)
            //{
            //    Console.Write(startwb.Dequeue() + " ");
            //}
            //Console.WriteLine();
            /// ------------------------------------------------------------------------------------------------------------------------------------
            /// 3)
            string path3 = @"D:\files\wordsupper.txt";

            StreamReader reader = new StreamReader(path3);

            string[] ara = reader.ReadToEnd().Split(" ");

            reader.Close();

            Queue<string> up = new Queue<string>();
            Queue<string> low = new Queue<string>();
            for (int i = 0; i < ara.Length; i++)
            {
                if (Char.IsUpper((ara[i])[0]))
                {
                    up.Enqueue(ara[i]);
                }
                else if (Char.IsLower((ara[i])[0]))
                {
                    low.Enqueue(ara[i]);
                }
            }

            //while(up.Count>0 || low.Count > 0)
            //{
            
            List<string> s = new List<string>();
            while (up.Count>0 || low.Count>0)
            {
                if (up.Count > 0)
                {
                    s.Add(" "+up.Dequeue());
                }
                if(up.Count==0 && low.Count > 0)
                {
                    s.Add(" "+low.Dequeue());
                }
                                  
            }
            foreach (var item in s )
            {
                Console.Write(item);
            }
           
                //if(up.Count==0 && low.Count > 0)
                //{
                //    Console.Write(low.Dequeue()+" ");
                //}
            //}

            /// ------------------------------------------------------------------------------------------------------------------------------------
            //    string path4 = @"D:\files\pipli.txt";

            //    StreamReader reader = new StreamReader(path4);
            //    Queue<Person> thirty = new Queue<Person>();
            //    Queue<Person> notthirty = new Queue<Person>();
            //    string line;
            //    List<Person> p = new List<Person>();
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        string[] ara = line.Split("|");
            //        //foreach (var item in ara)
            //        //{
            //        //    Console.WriteLine(item);
            //        //}
            //        p.Add(new Person(ara[0], ara[1], ara[2], ara[3], Convert.ToInt32(ara[4]), Convert.ToDouble(ara[5])));
            //    }
            //    for (int i = 0; i < p.Count; i++)
            //    {
            //        if (p[i].Age <= 30)
            //        {
            //            thirty.Enqueue(p[i]);
            //        }
            //        else
            //        {
            //            notthirty.Enqueue(p[i]);
            //        }
            //    }
            //    Console.WriteLine("30's");
            //    while (thirty.Count > 0)
            //    {
            //        Person pip = thirty.Dequeue();
            //        Console.WriteLine(pip.ToString() + "\t");
            //    }
            //    Console.WriteLine("\n not 30");
            //    while (notthirty.Count > 0)
            //    {
            //        Person pip = notthirty.Dequeue();
            //        Console.WriteLine(pip.ToString() + "\t");
            //    }
            //    Console.WriteLine();
        }
        }
}