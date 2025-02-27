using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//编写程序输入指定数据的所有素数因子
namespace Assignment2
{
    class Program
    {
        public static void PrimeFacter(int n ,out Queue<int>Prime)
        {
            Prime = new Queue<int>();
            if (n<0)
            {
                n = -n;
            }
            for (int i = 2; i <= n; i++)
            {
                while (n % i == 0)
                {
                    Prime.Enqueue(i);
                    while (n % i == 0)n = n / i;
                }
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Input a number");
            int n = int.Parse(Console.ReadLine());
            if ((n <= 1) & (n >= -1))
            {
                Console.WriteLine("Not existing PrimeFacters");
                return;
            }
            Console.WriteLine("The PrimeFacters is :");
            PrimeFacter(n, out Queue<int>Prime);
            foreach(int i in Prime)
            {
                Console.Write(i+" ");
            }




        }
    }
}
