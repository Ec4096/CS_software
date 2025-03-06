using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//查看是否为托普利兹矩阵
namespace Project2_4
{
    class Program
    {
        public static void check(int m, int n, int[,] arr, out bool flag)
        {
            if(arr == null || arr.Length == 0)
            {
                throw new Exception("数组为空");
            }

            flag = true;
            int[] flatArr = arr.Cast<int>().ToArray();
            int core_num = n + 1;
            for (int i = 0; i < m - 1; i++)
            {
                int temp = i + core_num;
                while (temp <= m * n - 1)
                {
                    if (flatArr[i] != flatArr[temp])
                    {
                        flag = false;
                        break;
                    }
                    temp += core_num;
                }
            }

            for (int i = m*n-1; i> (m-1)*n; i--)
            {
                int temp = i - core_num;
                while (temp >= 0)
                {
                    if (flatArr[i] != flatArr[temp])
                    {
                        flag = false;
                        break;
                    }
                    temp -= core_num;
                }
            }




        }
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Input the m and n");
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[m, n];
            Console.WriteLine(
                "Input the elements");
            for (int i = 0; i < m; i++)
            {
                string[] row = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = int.Parse(row[j]);
                }
            }
            check(m, n, arr, out bool flag);
            if (flag)
            {
                Console.WriteLine("是托普利茨矩阵");
            }
            else
            {
                Console.WriteLine("不是托普利茨矩阵");

            }
        }
    }
}
