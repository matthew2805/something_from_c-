using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TrySmthing
{
    class Program
    {
        //programmer is not a number
        //blank string
        //кол-во обработанных знаков


        public static List<string> ReadFromFile(string path)//that place
        {
            List<string> text = new List<string>();
            FileStream f = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(f, Encoding.Default);
            string str;
            while ((str = reader.ReadLine()) != null)
            {
                str = str.Trim();
                if (!str.Equals("Plate Numbers") && !str.Equals(""))//""-обработка последней идет
                {
                    text.Add(str);
                }
            }
            f.Close();
            return text;
        }



        static void WriteToConsole(List<string> text, List<string> nums)
        {
            string name = "Arina Yuzvovich";
            Console.WriteLine("Programmer: " + name);
            Console.WriteLine();
            {
                for (int i = 0; i < text.Count; i++)
                {
                    Console.WriteLine(text[i] + "--->" + nums[i]);
                }
            }


            Console.WriteLine();
            Console.WriteLine("Number of plates processed:" + "  " + nums.Count);

        }

        static bool CheckElements(string[] numberPlate)//проверяем 2 ли слова в строке
        {
            if (numberPlate.Length != 2) return false;
            else return true;
        }

        static bool CheckNumber(string parts)
        {
            int number;
            return int.TryParse(parts, out number) && number >= 0 && parts.Length == 4;//номер не отриц и количество цифр 4
        }

        static bool CheckString(string parts)//провер буквы
        {
            if (parts.Length != 3) return false;
            for (int i = 0; i < parts.Length; i++)
            {
                if (!(parts[i] >= 'A' && parts[i] <= 'Z')) return false;
            }
            return true;
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
            string path = @"C:\Users\Violetta\Desktop\song.txt";
            //string path1 = @"C:\Users\Violetta\Desktop\output.txt";
            List<string> text = ReadFromFile(path);
            List<string> nums = new List<string>();
            foreach (string number in text)//number-just strings with an exception of 1
            {
                string[] numberPlate = number.Split(' ');
                if (CheckElements(numberPlate) && CheckNumber(numberPlate[1]) && CheckString(numberPlate[0]))
                {
                    nums.Add(ReplaceNumbers(number, numberPlate));
                }
                else
                {
                    nums.Add("Invalid");//ч/з консоль все время ошибка
                }
            }
            WriteToConsole(text, nums);
        }
    }
}

//обработку plate numbers
//in if checked if there were 2 el, checked num on 1 position and string on 0