using System;

    class Program
    {
        static void Main(string[] args)
        {
            double f = 0, N, x, x1, x2, x3;
            double minimum = 0, maximum = 0;
            int i, positive = 0, negative = 0, zero = 0;
            Console.Write("\nEnter Value of N: ");
            N = double.Parse(Console.ReadLine());

            for (i = 1; i <= N; i++)
            {
                Console.WriteLine("\nTest case " + i);              
                Console.Write("Enter Value for X: ");
                x = double.Parse(Console.ReadLine());
                Console.Write("Enter Value for X1: ");
                x1 = double.Parse(Console.ReadLine());
                Console.Write("Enter Value for X2: ");
                x2 = double.Parse(Console.ReadLine());
                Console.Write("Enter Value for X3: ");
                x3 = double.Parse(Console.ReadLine());

                if (x1 <= x && x <= x2)
                {
                    f = ((x - x1) / (x2 - x1)) * (x3 - x1);
                }
                else if (x2 < x && x <= x3)
                {
                    f = ((x - x2) / (x3 - x2)) * (x2 - x1);
                }
                else if (x > x3)
                {
                    f = x3;
                }
                Console.WriteLine("\nValue of f: " + f);

                if (i == 1)
                {
                    minimum = f;
                    maximum = f;
                }
                else
                {
                    if (f > maximum)
                    {
                        maximum = f;
                    }
                    if (f < minimum)
                    {
                        minimum = f;
                    }

                }

                if (f > 0)
                    positive++;
                else if (f < 0)
                    negative++;
                else
                    zero++;
            }
                       
            Console.WriteLine("\nMaximum Value: " + maximum);
            Console.WriteLine("Minimum Value: " + minimum);
            Console.WriteLine("Negative count: " + negative);
            Console.WriteLine("zero count: " + zero);
            Console.WriteLine("Positive count: " + positive);
            Console.ReadKey();
        }
    }
