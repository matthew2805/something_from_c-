
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sonofadog
{
    class Program
    {

        static readonly Dictionary<string, string> garbade = new Dictionary<string, string>();
        static int count = 1;


        public static List<string> ReadFromFile(string path)
        {
            List<string> text = new List<string>();
            FileStream f = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(f, Encoding.Default);
            string? str;
            while ((str = reader.ReadLine()) != null)
            {
                str = str.Trim();
                if (!str.Equals("Plate Numbers") && !str.Equals(""))
                {
                    string[] ar = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string let = ar[0];
                    string nums = ar[1];
                    if (Checklet(let) && Checknums(nums))
                    {
                        text.Add(str);
                    }
                    else
                    {
                        garbade.Add("invalid"+Convert.ToString(count), str);
                        count++;
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
                if (char.IsUpper(let[i]))
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
                if (char.IsDigit(a[i]))
                {
                    count++;
                }
            }
            if (count == a.Length && a.Length == 4) return true;
            else return false;
        }


        static void WriteToConsole(List<string> text, List<string> nums,string path)
        {
            FileStream f = new FileStream(path, FileMode.Create);
            StreamWriter writer = new StreamWriter(f);
            writer.WriteLine("Programmer: " + "Maxim Grickevich");
            writer.WriteLine();
            {
                for (int i = 0; i < text.Count; i++)
                {
                    writer.WriteLine(text[i] + "--->" + nums[i]);
                    writer.Flush();
                }
            }

            writer.WriteLine();
            foreach (var item in garbade)
            {
                writer.WriteLine($"{item.Key} ==> {item.Value}");
            }

            writer.WriteLine();
            writer.WriteLine("Number of plates processed:" + "  " + nums.Count);
            writer.Flush();
            writer.Close();
            f.Close();

        }



        static string ReplaceLetter(string letters)
        {
            for (int i = 2; i >= 0; i--)
            {
                if (letters[i] != 'Z')
                {
                    letters = letters.Remove(i, 1).Insert(i, ((char)(letters[i] + 1)).ToString());
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
                number = $"{letters} {string.Format("{0:d4}", nums)} ";
            }
            return number;
        }

        
        static void Main(string[] args)
        {
            string path = @"D:\files\input.txt";
            string path1 = @"D:\files\output.txt";
            List<string> text = ReadFromFile(path);
            List<string> nums = new List<string>();
            foreach (string number in text)
            {
                string[] numberPlate = number.Split(' ');
                nums.Add(ReplaceNumbers(number, numberPlate));



            }
            WriteToConsole(text, nums,path1);
        }
    }
}

//обработку plate numbers
//in if checked if there were 2 el, checked num on 1 position and string on 0