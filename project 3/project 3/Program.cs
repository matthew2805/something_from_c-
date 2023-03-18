using System.Collections.Concurrent;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;

internal class Program
{

    public static void Main(string[] args)
    {

        int[] key = null;
        int numofchar = 0;
        const int maxchar = 20;
        int[] defkey = null;
        StringBuilder unscrambledtext = new StringBuilder();

        ReadFromFile(ref key, ref numofchar, unscrambledtext, maxchar,ref defkey);
        Console.WriteLine("дефолтный массив ");
        for (int i = 0; i < defkey.Length; i++)
        {
            Console.Write(defkey[i]+"  ");
        }
        Console.WriteLine();
        int[] newkey = ModKey(key);
        WriteToFile(key, newkey, numofchar, unscrambledtext, defkey);

    }
    static int[] ModKey(int[] key)
    {
        int simbol;
        int position;
        int[] newkey = new int[20];
        for (int i = 0; i < key.Length; i++)
        {
            

            position = Array.IndexOf(key, i);

            newkey[i] = position;
        }



        return newkey;
    }
    static void CreateArra(string str, ref int[] ara)
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
    static void ReadFromFile(ref int[] key, ref int numofchar, StringBuilder unscrambledtext, int maxchar, ref int[] defkey)
    {
        StreamReader reader = new StreamReader(@"D:\files\3.Scrambled.txt");
        char[] bb = new char[17];
        reader.Read(bb);
        CreateArra(reader.ReadLine(), ref defkey);
       
        CreateArra(reader.ReadLine(), ref key);
        reader.ReadLine();
        numofchar = Convert.ToInt32(reader.ReadLine());
        int numofcharleft = numofchar;

        reader.ReadLine();

        char[] buff = new char[maxchar];


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
                buff = new char[maxchar];
                numofcharleft -= count;
                count = 0;
                if (numofcharleft < 20)
                {
                    //Console.WriteLine(Math.Abs(numofchar));
                    buff = new char[Math.Abs(numofcharleft) + 1];
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
        reader.Close();

    }
    static void WriteToFile(int[] key, int[] newkey, int numofchar, StringBuilder unscrambledtext, int[] defkey )
    {
        FileStream f = new FileStream(@"D:\files\result.txt", FileMode.Create);
        StreamWriter writer = new StreamWriter(f);
        writer.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        writer.WriteLine($"Decrypting {numofchar} characters");
        writer.Write("Using:   ");
        for (int i = 0; i < defkey.Length; i++)
        {
            if (defkey[i] >= 10) 
            {
                writer.Write(defkey[i] + " ");
            }
            else if (defkey[i]<10)
            {
                writer.Write(defkey[i] + "  ");
            }

            
        }
        writer.Write("\n");

        writer.Write("\t");
        for (int i = 0; i < newkey.Length; i++)
        {
            if (newkey[i] >= 10)
            {
                writer.Write(newkey[i] + " ");
            }
            else if (newkey[i] < 10)
            {
                writer.Write(newkey[i] + "  ");
            }
        }
        writer.Write("\n");
        writer.WriteLine();

        writer.Write(unscrambledtext.ToString());

        writer.WriteLine();
        writer.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        writer.Flush();
        writer.Close();
        f.Close();
    }
}