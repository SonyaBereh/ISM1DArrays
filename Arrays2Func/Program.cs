using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2Func
{
    class Program
    {
        static double BetweenZeros(double[] arr)
        {
            int firstZero = -1, lastZero = -1;
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
                if (Math.Abs(arr[i]) < 0)
                {
                    firstZero = i;
                    break;
                }
            if (firstZero != -1)
            {
                for (int i = arr.Length; i > firstZero; i--)
                {
                    if (Math.Abs(arr[i]) < 0)
                    {
                        lastZero = i;
                        break;
                    }
                }
            }
            if (firstZero != -1 && lastZero != -1)
                for (int i = firstZero; i < lastZero; i++)
                    sum += arr[i];
            return sum;
        }
        static double BetweenMods(double[] arr)
        {
            double rez = 1;
            int a = 0, b = 0;
            double min = 1E+10, max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) > max) { max = Math.Abs(arr[i]); a = i; }
                if (Math.Abs(arr[i]) < min) { min = Math.Abs(arr[i]); b = i; }
            }
            if (a > b) 
                for (int i = b + 1; i < a; i++)
                    rez *= arr[i];
            else 
                for (int i = a + 1; i < b; i++)
                    rez *= arr[i];
            return rez;                
        }
        static double BetweenMinAndMax(double[] arr)
        {
            double sum = 0;
            int k = 0, l = 0, n = 0, d = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0) n++; 
                if (arr[i] > 0) d++;
                if (n == 1) k = i;
                if (d == 2) l = i;
            }
            if (k > l) for (int i = l + 1; i < k; i++) sum += arr[i];
            else for (int i = k + 1; i < l; i++) sum += arr[i];
            return sum;
        }
        static double AfterMin(double[] arr)
        {
            double min = 100, rez = 1;
            int ind = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    ind = i;
                }
            }
            for (int i = ind + 1; i < arr.Length; i++)
            {
                rez *= arr[i];
            }
            return rez;
        }
        static double[] GenerateArray(int size, int minValue, int maxValue, int precision)
        {
            double[] arr = new double[size];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = Math.Round(rnd.NextDouble() * (maxValue - minValue) + minValue, precision);
            return arr;
        }
        static void WriteArray(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine("arr[{0}] = {1}", i, arr[i]);
        }
        static void Main(string[] args)
        {
            int count, min, max, prec;
            Console.Write("Введите кол-во элементов массива: ");
            count = int.Parse(Console.ReadLine());
            Console.Write("MinValue = ");
            min = int.Parse(Console.ReadLine());
            Console.Write("MaxValue = ");
            max = int.Parse(Console.ReadLine());
            Console.Write("Precision = ");
            prec = int.Parse(Console.ReadLine());
            double[] arr = GenerateArray(count, min, max, prec);
            Console.WriteLine("Array:");
            WriteArray(arr);
            double rez1 = AfterMin(arr);
            if (rez1 == 1) Console.WriteLine("Нет элементов после минимального. ");
            else Console.WriteLine("Произведение элементов, находящихся после минимального: {0}", rez1);
            double sum1 = BetweenMinAndMax(arr);
            Console.WriteLine("Сума элементов, находящихся между первым отрицательным и вторым положительным элементами: {0}", sum1);
            double rez2 = BetweenMods(arr);
            if (rez2 > 1 || rez2 < 1)
                Console.WriteLine("Произведение элеметнтов, находящихся между минимальным и максимальным по модулям элементами: {0}", rez2);
            else Console.WriteLine("Нет элементов между минимальным и максимальным по модулям элементами.");
            double sum2 = BetweenZeros(arr);
            Console.WriteLine("Сумма элементов, находящихся между первым и последним нулевыми элементами: {0}", sum2);
        }
    }
}
