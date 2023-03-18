using System.Collections;
using System.Diagnostics;
using System.Text;

namespace project_5
{
    class Program
    {
        
        ///------------------------------------------------------------------------------------------------------------------
        public static bool StackComapare(Stack<char> st1, Stack<char> st2)
        {
            if (st1.Count != st2.Count)
            {
                return false;
            }
            int i = st1.Count;
            char a;
            char b;
            while (i > 0)
            {
                a = st1.Pop();
                b = st2.Pop();
                if (a != b) { return false; }
                i--;
            }
            return true;
        }
        ///------------------------------------------------------------------------------------------------------------------
        public static void Calculate(int operand1,int operand2, string operatr, Stack<int> result)
        {
            switch (operatr)
            {
                case "*":
                    result.Push(operand1 * operand2);
                    break;
                case "-":
                    result.Push(operand1 - operand2);
                    break;
                case "+":
                    result.Push(operand1 + operand2);
                    break;
                case "/":
                    if (operand2 < 0)
                    {
                        Console.WriteLine("операнд меньше нуля");
                        return;
                    }
                    result.Push(Convert.ToInt32(operand1 / operand2));
                    break;
            }
        }
            

            public static bool IsOperand( char c)
        {
            return char.IsDigit(c);
        }

        public static bool IsOperator( string c)
        {
            switch (c)
            {
                case "-":
                    return true;
                case "*":
                    return true;
                case "+":
                    return true;
                case "/":
                    return true;
                default:
                    return false;
            }
        }
        static void ApplyFunc(string f, Stack<int> znach)
        {
            int res;
            switch (f)
            {
                case "M":
                    res = Math.Max(znach.Pop(), znach.Pop());
                    znach.Push(res);
                    break;
                case "m":
                    res = Math.Min(znach.Pop(), znach.Pop());
                    znach.Push(res);
                    break;
            }
        }
        static void Main(String[] args)
        {
           
            


            //1)
            ///------------------------------------------------------------------------------------------------------------------
            //Console.WriteLine("write a first string here");
            //string? s1 = Console.ReadLine();
            //Console.WriteLine("write a second string here");
            //string? s2 = Console.ReadLine();

            //char[] ara1 = s1.ToCharArray();
            //char[] ara2 = new char[s2.Length];
            //for (int i = 0; i < s2.Length; i++)
            //{
            //    ara2[i] = s2[(s2.Length - 1) - i];
            //}
            //Stack<char> st1 = new Stack<char>(ara1);
            //Stack<char> st2 = new Stack<char>(ara2);
            //Console.WriteLine(StackComapare(st1, st2));
            ///------------------------------------------------------------------------------------------------------------------
            //2)
            ///------------------------------------------------------------------------------------------------------------------
            //int i = 1;
            //while (i != 0)
            //{
            //    //string input =  //"-*+222*23";+-(ab)cd/ef+gh
            //    string[] ara = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //    Stack<string> st = new Stack<string>(ara);
            //    Stack<int> buff = new Stack<int>();
            //    Console.WriteLine("вывод первого стэка");
            //    foreach (var item in st)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    string r;

            //    while (st.Count > 0)
            //    {
            //        //Console.WriteLine("сейчас стэк"+st.Count);
            //        r = st.Pop();
            //        if (IsOperator(r))
            //        {

            //            int op1 = buff.Pop();

            //            int op2 = buff.Pop();

            //            //Console.Write(op1);
            //            //Console.Write(r);
            //            //Console.Write(op2);
            //            Calculate(op1, op2, r, buff);
            //            //Console.WriteLine();
            //        }
            //        else
            //        {
            //            buff.Push(Convert.ToInt32(r));
            //        }
            //    }
            //    Console.WriteLine("вывод результата");
            //    foreach (var item in buff)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    i = int.Parse(Console.ReadLine());
            //}
            ///------------------------------------------------------------------------------------------------------------------
            //3)
            ///------------------------------------------------------------------------------------------------------------------

            //string path = @"D:\files\formula.txt";
            //StreamReader reader = new StreamReader(path);
            //char[] sep = { '(', ')', ',' };
            //string l;
            //string[] line;
            //Stack<string> stf;

            //while ((l = reader.ReadLine()) != null)
            //{
            //    line = l.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            //    stf = new Stack<string>(line);
            //    Stack<int> znach = new Stack<int>();

            //    string s;
            //    int chis;
            //    while (stf.Count > 0)
            //    {
            //        s = stf.Pop();
            //        if (int.TryParse(s, out chis))
            //        {
            //            znach.Push(chis);
            //        }
            //        else
            //        {
            //            ApplyFunc(s, znach);
            //        }
            //    }
            //    Console.WriteLine("result");
            //    foreach (var item in znach)
            //    {
            //        Console.WriteLine(item);
            //    }
            // }
            ///------------------------------------------------------------------------------------------------------------------
            //4)
            ///------------------------------------------------------------------------------------------------------------------
            //string path = @"D:\files\text.txt";
            //StreamReader reader = new StreamReader(path);
            //int a;
            //Stack<char> stch = new Stack<char>();

            //while ((a = reader.Read()) != -1)
            //{
            //    if (a == Convert.ToInt32('#'))
            //    {
            //        stch.Pop();
            //    }
            //    else
            //    {
            //        stch.Push((char)a);
            //    }
            //}
            //Stack<char> newstch = new Stack<char>(stch);
            //foreach (var item in newstch)
            //{
            //    Console.Write(item);
            //}
            //Console.WriteLine();
            ///------------------------------------------------------------------------------------------------------------------

        }
    }
}