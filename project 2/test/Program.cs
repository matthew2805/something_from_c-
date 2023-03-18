using System.Text;

internal class Program
{
    static int count = 1;
    private static void Main(string[] args)
    {
        StreamReader reader = new StreamReader(@"D:\files\4.txt");
        FileStream f = new FileStream(@"D:\files\result.txt", FileMode.Create);
        StreamWriter writer = new StreamWriter(f);
        string? str;
        try
        {
            while ((str = reader.ReadLine()) != null)
            {
                if (!str.Equals("4"))
                {
                    throw new Exception("not a 4");
                }
                count++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            writer.WriteLine(ex.Message);
            writer.Flush();


        }
        writer.Close();
        f.Close();
        Console.WriteLine();
    }
}