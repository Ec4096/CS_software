using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//求一个整数数组的最大值、最小值、平均值和所有数组元素的和
namespace Project2_2
{
    class Program
    {
        public static void Sort(ref int[]arr)
        {
            for(int i = 0;i<arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Input the number of the array");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            Console.WriteLine(
                "Input the elements");
            for(int i = 0;i<arr.Length;i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Sort(ref arr);
            Console.WriteLine("Min:" + arr[0]);
            Console.WriteLine("Max:" + arr[arr.Length - 1]);
            Console.WriteLine("Average:" + arr.Average());
            Console.WriteLine("Sum:" + arr.Sum());
        }
    }
}
