using System.Collections.Concurrent;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;

internal class Program
{
   
    public static void Main(string[] args)
    {
      
        StreamReader reader = new StreamReader(@"D:\files\3.Scrambled.txt");
        reader.ReadLine();
        CreateArra(reader.ReadLine(), out int[] key);
        reader.ReadLine();
        int numofchar = Convert.ToInt32(reader.ReadLine());
        StringBuilder unscrambledtext = new StringBuilder();
        reader.ReadLine();

        char[] buff = new char[20];
        

        int a;
        int count = 0;
        while ((a = reader.Read()) != -1)
        {
            if (a == 13)
            {

                continue;
            }

            
            if ((count == 20) && (count != 0))
            {
                Decrypt(buff, key, unscrambledtext); //1
                buff = new char[20];
                numofchar -= count;
                count = 0;
                if (numofchar < 20)
                {
                    //Console.WriteLine(Math.Abs(numofchar));
                    buff = new char[Math.Abs(numofchar)+1];
                    buff[0] = (char)a;

                    int a2 = 0;
                    int count2 = 1;
                    while ((a2 = reader.Read()) != -1)
                    {
                        if (a2 == 13)
                        {
                            continue;
                        }
                        buff[count2] = (char)a2;
                        count2++;
                    }
                    buff = buff.SkipLast(1).ToArray();
                    Decrypt(buff, key, unscrambledtext);//1
                    break;
                }

            }
            buff[count] = (char)a;
            count++;
            
        }
        Console.WriteLine(unscrambledtext.ToString());//1
        reader.Close();




    }

    static void CreateArra(string str, out int[] ara)
    {
        string[] a = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        ara = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            ara[i] = Convert.ToInt32(a[i]);
        }
    }

    static void Decrypt(char[] buff, int[] key, StringBuilder unscrambledtext)
    {

        char[] decript = new char[buff.Length];

        int simbol = 0;
        int position = 0;


        for (int i = 0; i < buff.Length; i++)
        {

            simbol = key[Array.IndexOf(key, i)];
            //Console.Write(simbol + "\t");
            position = Array.IndexOf(key, i);
            //Console.Write(position + "\n");
            while (position > buff.Length - 1)
            {
                if (position > buff.Length - 1)
                {
                    position = Array.IndexOf(key, position);
                }
            }


            decript[position] = buff[simbol];
        }
        for (int i = 0; i < decript.Length; i++)
        {
            unscrambledtext.Append(decript[i]);
        }


    }
    static void CheckCondition(int a)
    {

    }
}