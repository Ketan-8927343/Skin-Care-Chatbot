using System;

class Program
{
    static void Main(string[] args)
    {
        int N;
        double fMin = double.MaxValue;
        double fMax = double.MinValue;
        int negativeCount = 0;
        int zeroCount = 0;
        int positiveCount = 0;

        Console.WriteLine("Please enter the value of N:");
        N = int.Parse(Console.ReadLine());

        double[] xValues = new double[N];
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine($"Enter the value of x{i + 1}:");
            xValues[i] = double.Parse(Console.ReadLine());

            double f = CalculateF(xValues[i]);
            Console.WriteLine($"f({xValues[i]}) = {f}");

            if (f < fMin)
                fMin = f;
            if (f > fMax)
                fMax = f;

            if (f < 0)
                negativeCount++;
            else if (f == 0)
                zeroCount++;
            else
                positiveCount++;
        }

        Console.WriteLine("Minimum value of f: " + fMin);
        Console.WriteLine("Maximum value of f: " + fMax);
        Console.WriteLine("Negative results: " + negativeCount);
        Console.WriteLine("Zero results: " + zeroCount);
        Console.WriteLine("Positive results: " + positiveCount);

        Console.ReadLine();
    }

    static double CalculateF(double x)
    {
        // Calculate the value of f based on the given formula
        // Modify this function according to your specific formula
        return x * x - 2 * x + 1;
    }
}