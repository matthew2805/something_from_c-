using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr1
{
    internal class DoubleArray
    {
        private double[,] darray;
        private int n, m;
        public DoubleArray(int n, int m)
        {
            this.n = n;
            this.m = m;
            darray = new double[n,m];
        }
       
        public  int GetCapacity
        {

            get { return m*n  ; }
            
        }
        public double NaSkalar
        {
            set
            {
                for (int i = 0; i < darray.GetLength(0); i++)
                {
                    for (int j = 0; j < darray.GetLength(1); j++)
                    {
                        darray[i, j] += value;
                    }
                }
            }
        }
        public void ShowArray()
        {
            
            for (int i = 0; i < darray.GetLength(0); i++)
            {
                for (int j = 0; j < darray.GetLength(1); j++)
                {
                    Console.Write(darray[i,j]+"\t");
                }
                Console.WriteLine();
            }


        }
        public void FillArray()
        {
            for (int i = 0; i < darray.GetLength(0); i++)
            {
                for (int j = 0; j < darray.GetLength(1); j++)
                {
                    Console.WriteLine($"введите элементы для {i+1}-строки и {j+1}-столбца"); ;
                    double val;
                    double.TryParse(Console.ReadLine(), out val);
                    darray[i, j] = val;
                }
                Console.WriteLine();
            }
        }
        public void SotrArray()
        {
            double b;

            for (int i = 0; i < darray.GetLength(0); i++)
            {
                bool sorted = false;
  
                while (!sorted)
                {
                    sorted = true;

                    for (int j = 0; j < darray.GetLength(1) - 1; j++)
                    {
                        if (darray[i,j]> darray[i, j+1])
                        {
                            sorted=false;
                            b = darray[i,j];
                            darray[i, j] = darray[i, j + 1];
                            darray[i, j + 1] = b;
                        }
                    }
                }
                    
                
            }
            
        }
        public static DoubleArray operator ++(DoubleArray ara)
        {
            double[,] ara2 = new double[ara.darray.GetLength(0), ara.darray.GetLength(1)];
           
            for (int i = 0; i < ara2.GetLength(0); i++)
            {
                for (int j = 0; j < ara2.GetLength(1); j++)
                {
                    ara2[i, j] = ara.darray[i,j]+1;
                }
            }
            ara.darray = ara2;
            return ara;
        }
        public static DoubleArray operator --(DoubleArray ara)
        {
            double[,] ara2 = new double[ara.darray.GetLength(0), ara.darray.GetLength(1)];

            for (int i = 0; i < ara2.GetLength(0); i++)
            {
                for (int j = 0; j < ara2.GetLength(1); j++)
                {
                    ara2[i, j] = ara.darray[i, j] - 1;
                }
            }
            ara.darray = ara2;
            return ara;
        }
        public static bool operator true(DoubleArray ara)
        {
            for (int i = 0; i < ara.darray.GetLength(0); i++)
            {
                for (int j = 0; j < ara.darray.GetLength(1)-1; j++)
                {
                    if (ara.darray[i, j] > ara.darray[i, j + 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator false(DoubleArray ara)
        {
            for (int i = 0; i < ara.darray.GetLength(0); i++)
            {
                for (int j = 0; j < ara.darray.GetLength(1) - 1; j++)
                {
                    if (ara.darray[i, j] > ara.darray[i, j + 1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static DoubleArray operator *(DoubleArray ara1, DoubleArray ara2)
        {
            
            double[,] arr1 = new double[ara1.darray.GetLength(0), ara1.darray.GetLength(1)];
            double[,] arr2 = new double[ara2.darray.GetLength(0), ara2.darray.GetLength(1)];

            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    arr1[i, j] = ara1.darray[i, j];
                }
            }

            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    arr2[i, j] = ara2.darray[i, j];
                }
            }

            if (arr1.GetLength(1) != arr2.GetLength(0))
            {
                throw new Exception("такие матрицы нельзя перемножить");
            }
            DoubleArray ara3 = new DoubleArray(arr1.GetLength(0), arr2.GetLength(1));
            double[,] arr3 = new double[arr1.GetLength(0), arr2.GetLength(1)];
            double temp = 0;
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    temp = 0;
                    for (int k = 0; k < arr1.GetLength(1); k++)
                    {
                        temp += arr1[i, k] * arr2[k, j];
                    }
                    arr3[i, j] = temp;
                }
            }
            ara3.darray = arr3;

            return ara3;
            
        }


    }
}
