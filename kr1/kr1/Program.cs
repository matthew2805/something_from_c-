namespace kr1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                DoubleArray da1 = new DoubleArray(3, 2);
                da1.FillArray();

                da1.ShowArray();

                DoubleArray da2 = new DoubleArray(2, 3);
                da2.FillArray();


                da2.ShowArray();

                DoubleArray da3 = da1 * da2;
                Console.WriteLine("новый эррей");
                da3.ShowArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            //da1.NaSkalar = 5;
            //da1.ShowArray();
            //da1.SotrArray();
            //da1++;
            //da1.ShowArray();


            //double[,] a = new double[,] { { 1.9, 2, }, { 3, 4.2 }, { 5.1, 6.1 } };
            //for (int i = 0; i < a.GetLength(0); i++)
            //{
            //    for (int j = 0; j < a.GetLength(1); j++)
            //    {
            //        a[i, j] += 1;
            //    }
            //}
        }

    }
}