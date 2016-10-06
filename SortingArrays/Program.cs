using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingArrays
{
    class Program
    {        
        static void QuickSort(double[] AFS, int start, int end)
        {
            double a = AFS[(start + end) / 2];
            int i = start;
            int j = end;
            while (i <= j)
            {
                while (AFS[i] < a) i++;
                while (AFS[j] > a) j--;
                if (i <= j)
                {
                    if (i != j)
                    {
                        double tmp = AFS[i];
                        AFS[i] = AFS[j];
                        AFS[j] = tmp;
                    }                      
                    i++;
                    j--;
                }
            }
            if (i < end) QuickSort(AFS, i, end);
            if (j > start) QuickSort(AFS, start, j);
        }
        static void ShellSort(double[] AFS)
        {
            int j;
            int step = AFS.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (AFS.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (AFS[j] > AFS[j + step]))
                    {
                        double tmp = AFS[j];
                        AFS[j] = AFS[j + step];
                        AFS[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
            }
        }           
        static void InsertSort(double[] AFS)
        {
            int i, j; 
            for (i = 1; i < AFS.Length; i++)
            {
                double a = AFS[i];
                for (j = i - 1; j >= 0 && AFS[j] > a; j--)
                    AFS[j + 1] = AFS[j];
                AFS[j + 1] = a;
            }
        }
        static void ChoiceSort(double[] AFS)
        {
            int min;
            double a;
            for (int i = 0; i < AFS.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < AFS.Length; j++)
                    if (AFS[j] < AFS[min]) min = j;
                a = AFS[i];
                AFS[i] = AFS[min];
                AFS[min] = a;
            }
        }
        static void BubbleSort(double[] AFS)
        {
            int i;
            double tmp;
            bool flag;
            do
            {
                flag = false;
                for (i = 0; i < AFS.Length - 1; i++)
                    if (AFS[i] > AFS[i + 1])
                    {

                        tmp = AFS[i];
                        AFS[i] = AFS[i + 1];
                        AFS[i + 1] = tmp;
                        flag = true;
                    }
            } while (flag);
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
            Stopwatch watch = new Stopwatch();
            Console.Write("Count = ");
            count = int.Parse(Console.ReadLine());
            Console.Write("MinValue = ");
            min = int.Parse(Console.ReadLine());
            Console.Write("MaxValue = ");
            max = int.Parse(Console.ReadLine());
            Console.Write("Precision = ");
            prec = int.Parse(Console.ReadLine());
            double[] arr, AFS;
            arr = GenerateArray(count, min, max, prec);
            /*Console.WriteLine("Array:");
            WriteArray(arr);
            Console.WriteLine("Sorted Array:");*/           
            AFS = (double[])arr.Clone();            
            watch.Start();
            ShellSort(AFS);
            watch.Stop();            
            Console.WriteLine("Shell's Sorting Time: {0}", watch.Elapsed);
            watch.Reset();
            AFS = (double[])arr.Clone();
            watch.Start();
            QuickSort(AFS, 0, AFS.Length - 1);
            watch.Stop();
            Console.WriteLine("Quick Sorting Time: {0}", watch.Elapsed);
            watch.Reset();
            AFS = (double[])arr.Clone();
            watch.Start();
            InsertSort(AFS);
            watch.Stop();
            Console.WriteLine("Sorting by Insert Time: {0}", watch.Elapsed);
            watch.Reset();
            AFS = (double[])arr.Clone();
            watch.Start();
            ChoiceSort(AFS);
            watch.Stop();
            Console.WriteLine("Sorting by choice Time: {0}", watch.Elapsed);
            watch.Reset();
            AFS = (double[])arr.Clone();
            watch.Start();
            BubbleSort(AFS);
            watch.Stop();
            Console.WriteLine("Bubble Sorting Time: {0}", watch.Elapsed);
            watch.Reset();
            AFS = (double[])arr.Clone();
            watch.Start();
            Array.Sort(AFS);
            watch.Stop();
            Console.WriteLine(".NET Sorting Time: {0}", watch.Elapsed);
        }
    }
}
