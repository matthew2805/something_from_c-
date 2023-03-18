using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace project_01
{
    class Program
    {
        //programmer is not a number
        //blank string
        //кол-во обработанных знаков
        static readonly Dictionary<string, string> garbade = new Dictionary<string, string>();
        static int count = 1;


        public static List<string> ReadFromFile(string path)//that place
        {
            List<string> text = new List<string>();
            FileStream f = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(f, Encoding.Default);
            string? str;
            while ((str = reader.ReadLine()) != null)
            {
                str = str.Trim();
                if (!str.Equals("Plate Numbers") && !str.Equals(""))//""-обработка последней идет
                {
                    string[] ar = str.Split(" ");
                    string let = ar[0];
                    string nums = ar[1];
                    if (Checklet(let) && Checknums(nums))
                    {
                        text.Add(str);
                    }
                    else
                    {
                        garbade.Add(String.Concat("Invalid", Convert.ToString(count)), str);
                    }
                }





            }
            f.Close();
            return text;
        }
        static bool Checklet(string let)
        {
            int count = 0;
            for (int i = 0; i < let.Length; i++)
            {
                if (Char.IsUpper(let[i]))
                {
                    count++;
                }

            }
            if (count == let.Length) return true;
            else return false;



        }
        static bool Checknums(string a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                {
                    count++;
                }
            }
            if (count == a.Length && a.Length == 4) return true;
            else return false;
        }


        static void WriteToConsole(List<string> text, List<string> nums)
        {
            
            Console.WriteLine("Programmer: " + "dixie normous");
            Console.WriteLine();
            {
                for (int i = 0; i < text.Count; i++)
                {
                    Console.WriteLine(text[i] + "--->" + nums[i]);
                }
            }

            Console.WriteLine();
            foreach (var item in garbade)
            {
                Console.WriteLine($"{item.Key} ==> {item.Value}");
            }

            Console.WriteLine();
            Console.WriteLine("Number of plates processed:" + "  " + nums.Count);

        }



        static string ReplaceLetter(string letters)
        {
            for (int i = 2; i >= 0; i--)//с конца чтобы легче было+начинаем проверять с Z
            {
                if (letters[i] != 'Z')
                {
                    letters = letters.Remove(i, 1).Insert(i, ((char)(letters[i] + 1)).ToString());//remove from ind i to length 1
                    break;
                }
                else
                {
                    letters = letters.Remove(i, 1).Insert(i, "A");
                }
            }
            return letters;
        }
        static string ReplaceNumbers(string number, string[] numberPlate)
        {
            if (number == "ZZZ 9999") return "The last one";
            else
            {
                int nums;
                string letters = numberPlate[0];
                int.TryParse(numberPlate[1], out nums);

                if (nums == 9999)
                {
                    letters = ReplaceLetter(numberPlate[0]);
                    nums = 0;
                }
                else
                {
                    nums++;
                }
                number = $"{letters} {string.Format("{0:d4}", nums)} ";//d-цифры
            }
            return number;
        }


        static void Main(string[] args)
        {
            string path = @"D:\files\input.txt";
            //string path1 = @"C:\Users\Violetta\Desktop\output.txt";
            List<string> text = ReadFromFile(path);


            List<string> nums = new List<string>();
            foreach (string number in text)//number-just strings with an exception of 1
            {
                string[] numberPlate = number.Split(' ');
                nums.Add(ReplaceNumbers(number, numberPlate));



            }
            WriteToConsole(text, nums);
        }
    }
}

//обработку plate numbers
//in if checked if there were 2 el, checked num on 1 position and string on 0