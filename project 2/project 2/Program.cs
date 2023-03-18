

using System;
using System.Numerics;

internal class Program
{
    static int cat = 0;
    static int catcount = 0;
    static int mouse = 0;
    static int mousecount = 0;
    static int border = 0;
    static int final;
    static int firstc = 0;
    static int firstm = 0;
    static bool gameison = true;
    private static void Main(string[] args)
    {
        StreamReader reader = new StreamReader(@"D:\files\2.ChaseData.txt");

        FileStream f = new FileStream(@"D:\files\result.txt", FileMode.Create);
        StreamWriter writer = new StreamWriter(f);
        const int lowborder = 0;
        const int highborder = 10000;
        writer.WriteLine("Cat and Mouse\n");
        writer.WriteLine("Cat Mouse  Distance\n-------------------");

         
        
        string? str;
        try
        {
            border = Convert.ToInt32(reader.ReadLine()?.Trim());
            if (border <= lowborder || border > highborder)
            {
                throw new Exception("border is more than 10000 or its negative");

            }
            else
            {
                while ((str = reader.ReadLine()) != null && gameison)
                {
                    Tracking(str, writer);
                    writer.Flush();//здесь
                }
                
                
            }

        }
        catch (Exception ex)
        {
            //Console.WriteLine(ex.Message);
            writer.WriteLine(ex.Message);
            writer.Flush();
           
            
        }

        writer.WriteLine("-------------------\n\n");
        writer.WriteLine($"Distance traveled:   Mouse    Cat");
        writer.WriteLine($"\t\t\t{mousecount}\t{catcount}");

        writer.WriteLine(" ");

        if (final == 0)
            writer.WriteLine("Mouse evaded Cat");
        else
            writer.WriteLine($"Mouse caught at: {final}");

        writer.Flush();
        writer.Close();
        f.Close();

    }
   
    static void Tracking(string str,StreamWriter writer)
    {

        string? player = str[0].ToString();

        string strtocheck = (str.Substring(1, str.Length - 1)).Trim();

        int step;

        bool isNum = Int32.TryParse(strtocheck, out step);
        if (!isNum && !player.Equals("P"))
        {
            throw new Exception("Wrong data");

        }
        

        switch (player)
        {

            case "M":
               
                if (firstm > 0)
                {
                    mousecount += Math.Abs(step);
                }
                if (mouse + step < 1)
                {
                   
                    while (step < 1)
                    {
                        step += border;
                    }
                }
                else if (mouse + step > border)
                {
                    while (step >  border)
                    {
                        step -= border;
                    }
                }
                
                mouse += step;
               
                firstm++;
                break;
            case "C":
                
                if (firstc > 0)
                {
                    catcount += Math.Abs(step);

                }

                if (cat + step < 1 || cat + step > border)
                {
                    cat = Math.Abs(border - Math.Abs(cat + step));
                }
                else
                {
                    cat += step;
                }
                firstc++;
                break;
            case "P":
                Print(writer);
                break;



        }

    }
    static void Print(StreamWriter writer)
    {
        
        if (mouse == cat)
        {
            final = cat;
            gameison = false;

            writer.Flush();
            
            return;
        }
        else
        {
            if(cat== 0)
                writer.Write("??\t");
            else
                writer.Write(cat+"\t");

            if (mouse == 0)
                writer.Write("??");
            else
            writer.Write(mouse+"\t");

            if (cat == 0 || mouse == 0)
                writer.Write("?? \n");
            else
            {
                writer.Write(Math.Abs(mouse - cat) + "\n");
            }

            writer.Flush();//здесь
        }
        




    }
    
}