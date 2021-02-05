using System;

namespace Jopa1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            double c = Convert.ToDouble(Console.ReadLine());
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            if ((a == b) && (a == c))
            {
                if (a + b > c && b + c > a && a + c > b)
                {

                    Console.WriteLine("Треугольник Равносторонний, Прямоугольный");
                    Console.WriteLine($"Площадь равна = {s}");


                }
                else
                {
                    Console.WriteLine("Сумма двух сторон должна быть больше третьей");
                }

            }
            else if ((a == b) && (a != c) || (a == c) && (a != b) || (c == b) && (c != a))
            {
                if (a + b > c && b + c > a && a + c > b)
                {
                    Console.WriteLine("Треугольник Равнобедренный");
                    Console.WriteLine($"Площадь равна = {s}");
                }
                else
                {
                    Console.WriteLine("Сумма двух сторон должна быть больше третьей");
                }

            }
            else if (a != c && b != c && c != a)
            {
                if (a + b > c && b + c > a && a + c > b)
                {
                    if (Math.Pow(a, 2) == Math.Pow(b, 2) + Math.Pow(c, 2))
                    {
                        Console.WriteLine("Треугольник разносторонний, прямоугольный");
                        Console.WriteLine($"Площадь равна = {s}");
                    }
                    else if (Math.Pow(b, 2) == Math.Pow(a, 2) + Math.Pow(c, 2))
                    {
                        Console.WriteLine("Треугольник разносторонний, прямоугольный");
                        Console.WriteLine($"Площадь равна = {s}");
                    }
                    else if (Math.Pow(c, 2) == Math.Pow(b, 2) + Math.Pow(a, 2))
                    {
                        Console.WriteLine("Треугольник разносторонний, прямоугольный");
                        Console.WriteLine($"Площадь равна = {s}");

                    }
                    else if (Math.Pow(a, 2) > Math.Pow(b, 2) + Math.Pow(c, 2))
                    {
                        Console.WriteLine("Треугольник разносторонний, тупоугольный");
                        Console.WriteLine($"Площадь равна = {s}");
                    }
                    else if (Math.Pow(b, 2) > Math.Pow(a, 2) + Math.Pow(c, 2))
                    {
                        Console.WriteLine("Треугольник разносторонний, тупоугольный");
                        Console.WriteLine($"Площадь равна = {s}");
                    }
                    else if (Math.Pow(c, 2) > Math.Pow(b, 2) + Math.Pow(a, 2))
                    {
                        Console.WriteLine("Треугольник разносторонний, тупоугольный");
                        Console.WriteLine($"Площадь равна = {s}");
                    }
                    else
                    {
                        Console.WriteLine("Треугольник разносторонний, Остроугольный");
                        Console.WriteLine($"Площадь равна = {s}");
                    }


                }
                else
                {
                    Console.WriteLine("Сумма двух сторон должна быть больше третьей");
                }

            }



        }
    }
}

