
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.SqlTypes;
using System.IO;
using System.Reflection;
using System.Security;

namespace GeneticsProject
{
    public struct GeneticData
    {
        public string name; //protein name
        public string organism;
        public string formula; //formula

    }

    class Program
    {
        static List<GeneticData> data = new List<GeneticData>();
        static int count = 1;
        public static void ShowArray()
        {
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine(data[i].name + " | " + data[i].organism + " | " + data[i].formula + " | ");
            }

        }
        static string GetFormula(string proteinName)
        {
            foreach (GeneticData item in data)
            {
                if (item.name.Equals(proteinName)) return item.formula;
            }
            return null;
        }
        static void ReadGeneticData(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] fragments = line.Split('\t');
                GeneticData protein;
                protein.name = fragments[0];
                protein.organism = fragments[1];
                protein.formula = fragments[2];
                data.Add(protein);
                count++;
            }
            reader.Close();
        }
        static void ReadHandleCommands(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            int counter = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine(); counter++;
                string[] command = line.Split('\t', StringSplitOptions.RemoveEmptyEntries);

                if (command[0].Equals("search"))
                {
                    //001   search  SIIK
                    Console.WriteLine($"{counter.ToString("D3")}   {"search"}   {Decoding(command[1])}");
                    int index = Search(command[1]);

                    if (index != -1)
                        Console.WriteLine($"{data[index].organism}    {data[index].name}");
                    else
                        Console.WriteLine("NOT FOUND");
                    Console.WriteLine("================================================");
                }
                if (command[0].Equals("diff"))
                {
                    Console.WriteLine($"{counter.ToString("D3")}   {"diff"}   {command[1] + "\t" + command[2]}");

                    int d = Diff(command[1], command[2]);
                    if (d != -1)
                        Console.WriteLine("amino-acids difference:\n" + d);
                    else
                        Console.WriteLine("MISSING");
                    Console.WriteLine("================================================");


                }
                if (command[0].Equals("mode"))
                {
                    string s = Mode(command[1]);
                    
                    if (s != null)
                        Console.WriteLine($"amino-acid occurs: \n {s}");
                    else
                        Console.WriteLine("MISSING");
                    Console.WriteLine("================================================");
                }
            }
            reader.Close();
        }
        static bool IsValid(string formula)
        {
            List<char> letters = new List<char>() { 'A', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'Y' };
            foreach (char ch in formula)
            {
                if (!letters.Contains(ch)) return false;
            }
            return true;
        }
        static string Encoding(string formula)
        {

            
            string encoded = String.Empty;
            for (int i = 0; i < formula.Length; i++)
            {
                char ch = formula[i];
                int count = 1;
                while (i < formula.Length - 1 && formula[i + 1] == ch)
                {
                    count++;
                    i++;
                }
                if (count > 2) encoded = encoded + count + ch;
                if (count == 1) encoded = encoded + ch;
                if (count == 2) encoded = encoded + ch + ch;

            }
            return encoded;

        }
        static string Decoding(string formula)
        {
            string decoded = String.Empty;
            for (int i = 0; i < formula.Length; i++)
            {
                if (char.IsDigit(formula[i]))
                {
                    char letter = formula[i + 1];
                    int conversion = formula[i] - '0';
                    for (int j = 0; j < conversion - 1; j++) decoded = decoded + letter;
                }
                else decoded = decoded + formula[i];
            }
            return decoded;
        }
        static int Search(string amino_acid)
        {
            //       FKIII                FK3I
            string decoded = Decoding(amino_acid);

            for (int i = 0; i < data.Count; i++)
            {

                if (Decoding(data[i].formula).Contains(decoded)) return i;


            }
            return -1;
        }
        static int Diff(string protein1, string protein2)
        {
            int count = 0;
            string formula1 = GetFormula(protein1);
            string formula2 = GetFormula(protein2);
            if (formula1 == null || formula2 == null)
            {
                return -1;
            }
            if (formula1.Length == formula2.Length)
            {
                for (int i = 0; i < formula1.Length; i++)
                {
                    if (formula1[i] != formula2[i])
                    {
                        count++;
                    }
                }

                return count;
            }
            else
            {
                count = Math.Abs(formula1.Length - formula2.Length);
                int length = Math.Min(formula1.Length, formula2.Length);
                for (int i = 0; i < length; i++)
                {
                    if (formula1[i] != formula2[i])
                    {
                        count++;
                    }
                }

                return count;
            }
           

        }
        static string Mode(string name1)
        {
            string formula = GetFormula(name1);
            if (formula == null)
            {
                return null;
            }

            Dictionary<string, int> dict = new Dictionary<string, int>();
            char[] check = (Decoding(formula)).ToCharArray();
            for (int i = 0; i < check.Length; i++)
            {
                if (dict.ContainsKey(Convert.ToString(check[i])))
                {
                    dict[Convert.ToString(check[i])]++;
                }
                else
                {
                    dict.Add(Convert.ToString(check[i]), 1);
                }
            }
            int[] keys = dict.Values.ToArray();
            Array.Sort(keys);
            int m = keys[keys.Length - 1]; 
            var kvmax = new KeyValuePair<string, int>("Z", m);
            foreach (var item in dict)
            {
                if (item.Value == kvmax.Value)
                {
                   if(Convert.ToChar(item.Key) < Convert.ToChar(kvmax.Key))
                    {
                        kvmax = item;
                    }
                }

            }
           
            return $"{kvmax.Key}     {kvmax.Value}";

        }
        static void Main(string[] args)
        {
            ReadGeneticData(@"D:\files\sequences.0.txt");
            
            ReadHandleCommands(@"D:\files\commands.0.txt");

            //Console.WriteLine(Encoding("AAAAAAAATATTTCGCTTTTCAAAAATTGTCAGATGAGAGAAAAAATAAAA"));
            //// string formula2 =  Decoding("FK3I");
            ////  ReadGeneticData("sequences.0.txt");
            ////  Console.WriteLine("=============Search===================");
            ////  ReadHandleCommands("commands.0.txt");
            ////  Console.WriteLine("=============Get Formula of the Protein===================");
            ////  string formula=GetFormula("6.8 kDa mitochondrial proteolipid");
            //// if (formula != null) Console.WriteLine(formula);
        }
    }
}