
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project3_1.Program;

namespace Project3_1
{
    class Program
    {
        public abstract class Shape
        {
            public abstract bool IsLegal();

            public abstract double Area();
            public abstract void ShowInfo();
        }

        public class Rectangle : Shape
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public Rectangle(int w, int h)
            {
                Width = w;
                Height = h;
            }
            public override double Area()
            {
                return Width * Height;
            }
            public override bool IsLegal()
            {
                return Width > 0 && Height > 0;
            }
            public override void ShowInfo()
            {
                Console.WriteLine("Rectangele: Width=" + Width + ", Height=" + Height);

            }
            public class Square : Rectangle
            {
                public int Side { get; set; }
                public Square(int s) : base(s, s)
                {
                    Side = s;
                }

                public override double Area()
                {
                    return base.Area();
                }
                public override bool IsLegal()
                {
                    return base.IsLegal();
                }
                public override void ShowInfo()
                {
                    Console.WriteLine("Square: Side=" + Side);
                }

            }

            public class Triangle : Shape
            {
                public int A { get; set; }
                public int B { get; set; }
                public int C { get; set; }
                public Triangle(int a, int b, int c)
                {
                    A = a;
                    B = b;
                    C = c;
                }
                public override double Area()
                {
                    double p = (A + B + C) / 2.0;
                    return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
                }
                public override bool IsLegal()
                {
                    return (A > 0 & B > 0 & C > 0 & A + B > C && A + C > B && B + C > A);
                }
                public override void ShowInfo()
                {
                    Console.WriteLine("Triangle: A=" + A + ", B=" + B + ", C=" + C);
                }

            }

            public static class ShapeFactory
            {
                private static Random random = new Random();

                public static Shape CreateShape()
                {
                    int choice = random.Next(1, 4);
                    switch (choice)
                    {
                        case 1:
                            return new Rectangle(random.Next(1, 100), random.Next(1, 100));
                        case 2:
                            return new Square(random.Next(1, 100));
                        case 3:
                            return new Triangle(random.Next(1, 100), random.Next(1, 100), random.Next(1, 100));
                        default:
                            throw new ArgumentException("无效的choice");
                    }
                }
            }

            static void Main(string[] args)
            {
                //用户交互：
                //Console.WriteLine("请选择图形类型：1-长方形，2-正方形，3-三角形");
                //if(!int.TryParse(Console.ReadLine(),out int choice))
                //{
                //    Console.WriteLine("无效输入，请输入数字");
                //    return;
                //}
                //Shape shape = null;

                //switch(choice)
                //{
                //    case 1:
                //        Console.WriteLine("请输入长方形的宽和高：");
                //        int width = int.Parse(Console.ReadLine());
                //        int height = int.Parse(Console.ReadLine());
                //        shape = new Rectangle(width, height);
                //        break;
                //    case 2:
                //        Console.WriteLine("请输入正方形的边长：");
                //        int side = int.Parse(Console.ReadLine());
                //        shape = new Square(side);
                //        break;
                //    case 3:
                //        Console.WriteLine("请输入三角形的三条边：");
                //        int a = int.Parse(Console.ReadLine());
                //        int b = int.Parse(Console.ReadLine());
                //        int c = int.Parse(Console.ReadLine());
                //        shape = new Triangle(a, b, c);
                //        break;
                //    default:
                //        Console.WriteLine("无效的选择");
                //        return;
                //}
                //if(shape!=null)
                //{
                //    Console.WriteLine("Area: " + shape.Area());
                //    Console.WriteLine("IsLegal: " + shape.IsLegal());
                //}

                //简单工厂设计
                List<Shape> shapes = new List<Shape>();
                for (int i = 0; i < 10; i++)
                {
                    shapes.Add(ShapeFactory.CreateShape());
                }
                foreach (var shape in shapes)
                {
                    shape.ShowInfo();
                    if (!shape.IsLegal())
                    {
                        Console.WriteLine("不合法的图形");
                        continue;
                    }
                    Console.WriteLine("Area: " + shape.Area());
                    Console.WriteLine("IsLegal: " + shape.IsLegal());
                    Console.WriteLine("----------------------------------------------");
                }

            }
        }
    }
}
