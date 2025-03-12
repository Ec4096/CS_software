using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Project1;


namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> intlist = new GenericList<int>();
            Random random = new Random();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(random.Next(1, 101)); // 添加随机的数字
            }
            //打印
            intlist.ForEach(x => Console.WriteLine(x));
            //求和
            int sum = 0;
            intlist.ForEach(x => { sum += x; });
            //求最大值
            int max = int.MinValue;
            intlist.ForEach(x => { max = Math.Max(max, x); });
            //求最小值
            int min = int.MaxValue;
            intlist.ForEach(x => { min = Math.Min(min, x); });
            Console.WriteLine($"Sum:{sum},Max:{max},Min:{min}");

        }
    }
}
