using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays1Func
{
    class Program
    {
        static double NegativeSumm(double[] arr)
        {
        double negSum = 0;
        for (int i = 0; i < arr.Length; i++) 
            if(arr[i] < 0) 
                negSum += arr[i];
            return negSum;
        }
        static double MaxModule(double[] arr)
        {
            int a = 0;            
            double maxMod = 0;
            for (int i = 0; i < arr.Length; i++)
                if (Math.Abs(arr[i]) > maxMod)
                {
                    maxMod = Math.Abs(arr[i]);
                    a = i;
                }
            maxMod = arr[a];
            return maxMod;
        }
        static double MaxEl(double[] arr)
        {
            double maxEl = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > maxEl)
                    maxEl = arr[i];
            return maxEl;
        }
        static double IndMaxEl(double[] arr)
        {
            double maxEl = 0;
            double ind = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > maxEl)
                {
                    maxEl = arr[i];
                    ind = i;
                }
            return ind;
        }
        static double PositiveSumm(double[] arr)
        {
            double posSum = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > 0)
                    posSum += arr[i];
            return posSum;
        }
        static double CountInt(double[] arr)
        {
            double Count = 0, e = 1E-2;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] - Math.Truncate(arr[i])*100 == 0)                
                    Count++;
            Count = Math.Round(Count, 0);
            return Count;
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
            double negSum = NegativeSumm(arr);
            Console.WriteLine("Сумма отрицательных элементов массива: {0}", negSum);
            double maxMod = MaxModule(arr);
            Console.WriteLine("Максимальное по модулю число: {0}", maxMod);
            double maxEl = MaxEl(arr);
            Console.WriteLine("Максимальный элемент: {0}", maxEl);
            double ind = IndMaxEl(arr);
            Console.WriteLine("Индекс максимального элемента: {0}", ind);
            double posSum = PositiveSumm(arr);
            Console.WriteLine("Сумма положительных элементов: {0}", posSum);
            double Count = CountInt(arr);
            Console.WriteLine("Кол-во целых элементов: {0}", Count);
        }
    }
}
