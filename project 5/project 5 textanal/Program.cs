using System.Globalization;

class Program
{
    static void Main(String[] args)
    {
        string path = @"D:\files\analysis.txt";
        StreamReader reader = new StreamReader(path);
        string line;
        List<int> location = new List<int>();
        Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();  
        int page = 1;
        while((line = reader.ReadLine()) != null)
        {
            char[] options = { ' ', '.', ',' , '!', '?', '\"'};
            string[] words = line.Split(options, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (dict.ContainsKey(Convert.ToString(words[i])))
                {
                    //dict[words[i]].[0];
                    
                }
                else
                {
                    dict.Add(words[i],new List<int> {1});
                }
            }
            //foreach (var item in dict)
            //{
            //    Console.Write(item.Key);
            //    for (int i = 0; i < item.Value.Count; i++)
            //    {
            //        Console.Write("\t\t"+ item.Value.Count+"\t");
            //    }
            //    Console.WriteLine();
            //}

        }
    }
}