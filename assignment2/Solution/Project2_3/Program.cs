using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//使用埃及筛，求2-100以内的素数
namespace Project2_3
{
    class Program
    {
        public static void PrimeFilter(out List<int>Prime)
        {
            Prime = new List<int>();
            for(int i = 2; i <= 100; i++)
            {
                Prime.Add(i);
            }
            //for (int i = 2; i <= 100; i++)
            //{
            //    for(int j = 2;i*j<= 100; j++)
            //    {
            //        if (Prime.Contains(i * j))
            //        {
            //            Prime.Remove(i * j);
            //        }
            //    }
            //}
            for (int i = 2; i * i <= 100; i++)
            {
                if (!Prime.Contains(i)) continue;
                for (int j = i*i ; j <= 100; j+=i)
                {
                    
                        Prime.Remove(j);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("The Prime from 2 to 100 is:");
            PrimeFilter(out List<int> Prime);
            foreach(int i in Prime)
            {
                Console.Write(i + " ");
            }

        }
    }
}
