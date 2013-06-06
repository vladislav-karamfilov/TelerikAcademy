using System;
using System.Threading;
using System.Globalization;

class QuadraticEquationSolver
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the real roots of a quadratic equation a*x^2 + b*x + c = 0***");
        Console.Write(decorationLine);
        Console.Write("Enter the coefficient a: ");
        double aCoefficient = double.Parse(Console.ReadLine().Replace(',', '.'));
        Console.Write("Enter the coefficient b: ");
        double bCoefficient = double.Parse(Console.ReadLine().Replace(',', '.'));
        Console.Write("Enter the coefficient c: ");
        double cCoefficient = double.Parse(Console.ReadLine().Replace(',', '.'));
        if (aCoefficient == 0.0)
        {
            double root = -cCoefficient / bCoefficient;
            Console.WriteLine("The quadratic equation with coefficients a = {0},\nb = {1} and c = {2} is actually linear equation and its only root is {3}.",
                aCoefficient, bCoefficient, cCoefficient, root);
        }
        else
        {
            double discriminant = bCoefficient * bCoefficient - 4 * aCoefficient * cCoefficient;
            if (discriminant < 0.0)
            {
                Console.WriteLine("The quadratic equation with coefficients a = {0},\nb = {1} and c = {2} has no real roots. It has complex roots.",
                    aCoefficient, bCoefficient, cCoefficient);
            }
            else if (discriminant == 0.0)
            {
                double root = -bCoefficient / (2 * aCoefficient);
                Console.WriteLine("The quadratic equation with coefficients a = {0},\nb = {1} and c = {2} has one root equal to {3}.",
                    aCoefficient, bCoefficient, cCoefficient, root);
            }
            else
            {
                double root1 = (-bCoefficient - Math.Sqrt(discriminant)) / (2 * aCoefficient);
                double root2 = (-bCoefficient + Math.Sqrt(discriminant)) / (2 * aCoefficient);
                Console.WriteLine("The quadratic equation with coefficients a = {0},\nb = {1} and c = {2} has roots {3} and {4}.",
                    aCoefficient, bCoefficient, cCoefficient, root1, root2);
            }
        }
    }
}
