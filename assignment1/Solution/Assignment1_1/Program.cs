//using System;

//namespace Assignment1_1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("请输入第一个数字:");
//            double num1 = Convert.ToDouble(Console.ReadLine());

//            Console.WriteLine("请输入运算符 (+, -, *, /):");
//            char operation = Console.ReadLine()[0];

//            Console.WriteLine("请输入第二个数字:");
//            double num2 = Convert.ToDouble(Console.ReadLine());

//            double result = 0;

//            switch (operation)
//            {
//                case '+':
//                    result = num1 + num2;
//                    break;
//                case '-':
//                    result = num1 - num2;
//                    break;
//                case '*':
//                    result = num1 * num2;
//                    break;
//                case '/':
//                    if (num2 != 0)
//                    {
//                        result = num1 / num2;
//                    }
//                    else
//                    {
//                        Console.WriteLine("除数不能为零。");
//                        return;
//                    }
//                    break;
//                default:
//                    Console.WriteLine("无效的运算符。");
//                    return;
//            }

//            Console.WriteLine($"结果: {num1} {operation} {num2} = {result}");
//        }
//    }
//}


using System;
using System.Collections.Generic;

namespace Assignment1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个数字:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入运算符 (+, -, *, /):");
            char operation = Console.ReadLine()[0];

            Console.WriteLine("请输入第二个数字:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            var operations = new Dictionary<char, Func<double, double, double>>
            {
                { '+', (a, b) => a + b },
                { '-', (a, b) => a - b },
                { '*', (a, b) => a * b },
                { '/', (a, b) => b != 0 ? a / b : throw new DivideByZeroException() }
            };

            try
            {
                if (operations.ContainsKey(operation))
                {
                    double result = operations[operation](num1, num2);
                    Console.WriteLine($"result: {num1} {operation} {num2} = {result}");
                }
                else
                {
                    Console.WriteLine("无效的运算符。");
                }
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("除数不能为零。");
            }
        }
    }
}
