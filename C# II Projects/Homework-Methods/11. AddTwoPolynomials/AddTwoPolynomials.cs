using System;

class AddTwoPolynomials
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the addition of two polynomials***");
        Console.Write(decorationLine);
        Console.Write("Enter the degree of the first polynomial: ");
        int degree1 = int.Parse(Console.ReadLine());
        double[] polynomialCoefficients1 = TakeCoefficients(degree1 + 1); // + 1 because of the 0 degree
        Console.Write("Enter the degree of the second polynomial: ");
        int degree2 = int.Parse(Console.ReadLine());
        double[] polynomialCoefficients2 = TakeCoefficients(degree2 + 1);
        int resultDegree = Math.Max(polynomialCoefficients1.Length, polynomialCoefficients2.Length); // Degree of the polynomial after addition
        double[] addition = AddPolynomials(polynomialCoefficients1, polynomialCoefficients2, resultDegree);
        // Removing the 0 coefficients if there are such in front of the largest degree
        while (addition[resultDegree - 1] == 0)
        {
            resultDegree--;
        }
        Console.WriteLine("The result polynomial has degree {0} and the coefficients are: ", resultDegree - 1);
        PrintCoefficients(resultDegree, addition);
    }

    static void PrintCoefficients(int resultDegree, double[] addition)
    {
        for (int degree = resultDegree - 1; degree >= 0; degree--)
        {
            if (addition[degree] != 0)
            {
                Console.WriteLine("{0} before degree {1} of x", addition[degree], degree);
            }
        }
    }

    static double[] TakeCoefficients(int degree)
    {
        double[] coefficients = new double[degree];
        for (int index = degree - 1; index >= 0; index--)
        {
            Console.Write("Enter the coefficient before degree {0} of x: ", index);
            coefficients[index] = double.Parse(Console.ReadLine());
        }
        return coefficients;
    }

    static double[] AddPolynomials(double[] polynomialCoefficients1, double[] polynomialCoefficients2, int resultDegree)
    {
        double[] addition = new double[resultDegree];
        for (int index = 0; index < resultDegree; index++)
        {
            double resultCoeff = 0;
            if (index < polynomialCoefficients1.Length)
            {
                resultCoeff += polynomialCoefficients1[index];
            }
            if (index < polynomialCoefficients2.Length)
            {
                resultCoeff += polynomialCoefficients2[index];
            }
            addition[index] = resultCoeff;
        }
        return addition;
    }
}
