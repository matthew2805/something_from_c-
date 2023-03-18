using System.Collections;
using System.Diagnostics.Tracing;
using System.Text;
using System.Xml.Schema;

internal class Program
{
   
    public static void Main(string[] args)
    {
        
        int[] key = null;
        int numofchar = 0;
        const int maxchar = 20;
        StringBuilder unscrambledtext = new StringBuilder();
        
        ReadFromFile(ref key,ref numofchar, unscrambledtext, maxchar);
        int[] newkey = ModKey(key);
        WriteToFile(key, newkey, numofchar, unscrambledtext);

    }
    static int[] ModKey(int[] key)
    {
        int simbol;
        int position;
        int[] newkey = new int[20];
        for (int i = 0; i <key.Length; i++)
        {
            simbol = key[Array.IndexOf(key, i)];
                
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
    static void ReadFromFile(ref int[] key,ref int numofchar,StringBuilder unscrambledtext,int maxchar)
    {
        StreamReader reader = new StreamReader(@"D:\files\1.Scrambled.txt");
        reader.ReadLine();
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
    static void WriteToFile(int[] key, int[] newkey, int numofchar, StringBuilder unscrambledtext)
    {
        FileStream f = new FileStream(@"D:\files\result.txt", FileMode.Create);
        StreamWriter writer = new StreamWriter(f);
        writer.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        writer.WriteLine($"Decrypting {numofchar} characters");
        writer.WriteLine("Using:   0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19");
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
//StreamReader reader = new StreamReader(@"D:\files\3.Scrambled.txt");
//reader.ReadLine();
//char[] test;
//CreateArra(reader.ReadLine(), out int[] key);
//reader.ReadLine();
//int numofchar = Convert.ToInt32(reader.ReadLine());
//StringBuilder unscrambledtext = new StringBuilder();
//reader.ReadLine();
//char[] buff = new char[20];


//int a;
//int count = 0;
//while ((a = reader.Read()) != -1)
//{
//    if (a == 13)
//    {

//        continue;
//    }


//    if ((count == 20) && (count != 0))
//    {
//        Decrypt(buff, key, unscrambledtext); //1
//        buff = new char[20];
//        numofchar -= count;
//        count = 0;
//        if (numofchar < 20)
//        {
//            //Console.WriteLine(Math.Abs(numofchar));
//            buff = new char[Math.Abs(numofchar) + 1];
//            buff[0] = (char)a;

//            int a2 = 0;
//            int count2 = 1;
//            while ((a2 = reader.Read()) != -1)
//            {
//                if (a2 == 13)
//                {
//                    continue;
//                }
//                buff[count2] = (char)a2;
//                count2++;
//            }
//            buff = buff.SkipLast(1).ToArray();
//            Decrypt(buff, key, unscrambledtext);//1
//            break;
//        }

//    }
//    buff[count] = (char)a;
//    count++;

//}
//Console.WriteLine(unscrambledtext.ToString());//1
//reader.Close();

























//char[] s = reader.ReadToEnd().ToCharArray();
//char[] decript = new char[20];
////Console.WriteLine(s.Length);
//string str = "\"The time has come,\"";
//int[] key = { 16,  9, 15, 10, 18,  3, 17,  4, 14, 19,  0,  1,  7,  8,  2,  5,  6, 11, 12, 13 };
////Console.WriteLine(key.Length);
////Console.WriteLine(Array.IndexOf(key, 0));
//int simbol = 0;
//int position = 0;
//for (int i = 0; i < s.Length; i++)
//{

//    simbol = key[Array.IndexOf(key, i)];
//    //simbol = key[Array.IndexOf(key,simbol)];
//    // Console.Write(simbol + "\t");
//    position = Array.IndexOf(key, i);
//    //Console.Write(position + "\n");
//    while (position > s.Length - 1)
//    {

//        position = Array.IndexOf(key, position);
//        Console.WriteLine(position);

//    }
//    Console.WriteLine("final - " + position);

//    decript[position] = s[simbol];


//}
//for (int i = 0; i < decript.Length; i++)
//{
//    Console.Write(decript[i]);
//}

///берем незашифрованную строку и ключ,
///далее расставляем ключи начиная с 0 и соответствующие кадому ключу символы
///далее i-тый  символ зашифрованной строки должен пойти на j-ое место незашифрованной строки
///(ищем индекс нуля 0,1,2...n это i, j -это его индекс и далее i-тый индекс зашифрованной строки ставим на j-тое метсо незашифрованной строки)
///ez