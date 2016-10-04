using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Введите N: ");
            int N = int.Parse(Console.ReadLine());
            double[] arr = new double[N];
            Random rnd = new Random();
            double sum = 0;
            int ind2 = 0, count = 0;
            double sum1 = 0, ind = 0, max = 0, maxm = 0;     
            Console.WriteLine("Array: ");
                   
            for (int i = 0; i < N; i++)
            {
                arr[i] = rnd.Next(-10,11)/10.0;
                Console.Write(arr[i] + (i == N - 1 ? "\n" : ", "));
                if (arr[i] < 0)
                    sum += arr[i];
                if ((arr[i] - Math.Truncate(arr[i]))*10 == 0) count++;
                if (arr[i] > max)
                {
                    max = arr[i];
                    ind = i;
                }
                if (Math.Abs(arr[i]) > maxm)
                {
                    maxm = Math.Abs(arr[i]);
                    ind2 = i;
                }
                if (arr[i] > 0)
                    sum1 += i;
            }
            Console.WriteLine("max = arr["+ ind +"] = " + max);           
            Console.WriteLine("Сума від'ємних елементів дорівнює " + sum);
            Console.WriteLine("Максимальним за модулем є елемент "+ arr[ind2]);
            Console.WriteLine("Cума індексів додатніх елементів дорівнює "+ sum1);
            Console.WriteLine("Кількість цілих чисел у массиві: " + count);
            Console.ReadKey();
                   
        }

    }
}
