using System.ComponentModel;
using System.Globalization;
using System.IO.Pipes;
using System.Text.RegularExpressions;

class Program
{
    public static void FindMatches(int page,List<string> list, Dictionary<string, List<int>> dict)
    {

        string[] words = list.ToArray();
        for (int i = 0; i < words.Length; i++)
        {
            if (dict.ContainsKey(words[i]))
            {
                int zeroindex = dict[words[i]][0];

                dict[words[i]].RemoveAt(0);
                dict[words[i]].Insert(0, ++zeroindex);
                if (dict[words[i]].IndexOf(page) == -1)
                {
                    dict[words[i]].Add(page);
                }
               

            }
            else
            {
                dict.Add(words[i], new List<int> { 1 });
                dict[words[i]].Add(page);
            }
        }

        
    }
    public static List<char> WhoIsHere(string[] keys)
    {
        List<char> result = new List<char>();
        for (int i = 0; i < keys.Length; i++)
        {
            if(result.IndexOf( Char.ToUpper((keys[i])[0]))==-1)
            {
                result.Add(Char.ToUpper((keys[i])[0]));
                
            }
           
            
        }
        return result;
        
    }
    static void Main(String[] args)
    {
        string path = @"D:\files\analysis.txt";
        int stranica = int.Parse(Console.ReadLine());
        StreamReader reader = new StreamReader(path);
        
        char[] options = { ' ', '.', ',', '!', '?', '\"' };
       
        Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
        int page = 0;
        bool tr = true;
        string line;
        while (tr)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < stranica; i++)
            {
                if((line = reader.ReadLine()) == null)
                {
                    tr = false;
                    break;
                }    
                string[] words = line.Split(options, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in words)
                {
                    list.Add(item);
                }
            }
            page++;
            FindMatches(page, list, dict);
            
            
           
            
        }
        reader.Close();

        string[] keys = dict.Keys.ToArray();
        Array.Sort(keys);

        List<char> ishere = WhoIsHere(keys);
       
        foreach (var item in ishere)
        {
            Console.WriteLine(item+":");

          
            for (int i = 0; i < keys.Length; i++)
            {
                if (Char.ToUpper((keys[i])[0]) == item)
                {

                    Console.Write(keys[i]);
                    Console.Write(new string('.', Math.Abs(30 - keys[i].Length)) + dict[keys[i]][0] + ":");
                    for (int v = 1; v < dict[keys[i]].Count; v++)
                    {

                        Console.Write("\t" + dict[keys[i]][v]);
                    }
                    Console.WriteLine();
                }

            }

        }

    }
}