using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Введіть N: ");
            int N = int.Parse(Console.ReadLine());
            double[] arr = new double[N];
            Random rnd = new Random();
            double e = 1E-2, rez = 1, rez1 = 0, rez2 = 0, rez3 = 1, min = 100, min1 = 100, max = -100;
            int k = 0, n = 0, a = 0, m = 0, b = 0, l = 0, g = 0, firstZero = -1, lastZero = -1;
            Console.WriteLine("Array: ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-10,11)/10.0;
                Console.Write(arr[i] + (i == N - 1 ? "\n" : ", "));
                if (Math.Abs(arr[i]) < min1) { min1 = Math.Abs(arr[i]); l = i; }
                if (Math.Abs(arr[i]) > max) { max = Math.Abs(arr[i]); g = i; } 
                if (arr[i] < min) { min = arr[i]; k = i; }
            }           
            if (k == N - 1) Console.WriteLine("Добуток елементів, що розташовані після мінімального елементу " + arr[k] + ": 0");
                    else 
            {
                for (int i = k + 1; i < arr.Length; i++) { rez *= arr[i]; }
                        Console.WriteLine("Добуток елементів, що розташовані після мінімального елементу " + arr[k] + ": " + rez);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0) n++;
                if (n == 1) a = i;
                if (arr[i] > 0) m++;
                if (m == 2) b = i;
            }
            for (int i = 0; i < arr.Length; i++)
                if (Math.Abs(arr[i]) < e)
                {
                    firstZero = i;
                    break;
                }
            if (firstZero != -1)
            {
                for (int i = arr.Length; i > firstZero; i--)
                {
                    if (Math.Abs(arr[i]) < e)
                    {
                        lastZero = i;
                        break;
                    }
                }
            }
            if (firstZero == -1) Console.WriteLine("0 немає.");
            else if (lastZero == -1) Console.WriteLine("Є тільки один 0.");
            else
            {
                for (int i = firstZero; i < lastZero; i++) rez2 += arr[i];            
            }
                if (a > b) b++; { for (; b < a; b++) { rez1 += arr[b]; } }
            if (b > a) { for (; a < b; a++) {rez1 += arr[a];} }
            if (l > g) for (g = g + 1; g < l; g++) { rez3 *= arr[g]; }
            if (l < g) for (l = l + 1; g > l; l++) { rez3 *= arr[l]; }
            if (rez2 != 0)
            Console.WriteLine("Cума елементів масиву, що розташовані між першим останнім нульовими елементами: " + rez2);    
            Console.WriteLine("Cума елементів масиву, що розташовані між першим від'ємним та другим додатним елементами: " + rez1);
            Console.WriteLine("Добуток елементів масиву, що розташовані між найбільшим та найменшим за модулями елементами: " + rez3);
        }
    }
}
