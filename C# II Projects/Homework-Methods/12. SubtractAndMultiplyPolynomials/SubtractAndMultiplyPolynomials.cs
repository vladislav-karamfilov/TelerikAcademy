using System;

class SubtractAndMultiplyPolynomials
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating subtraction and multiplication of two polynomials***");
        Console.Write(decorationLine);
        Console.Write("Enter the degree of the first polynomial: ");
        int degree1 = int.Parse(Console.ReadLine());
        double[] polynomialCoefficients1 = TakeCoefficients(degree1 + 1); // + 1 because of the 0 degree
        Console.Write("Enter the degree of the second polynomial: ");
        int degree2 = int.Parse(Console.ReadLine());
        double[] polynomialCoefficients2 = TakeCoefficients(degree2 + 1);
        // Subtracting the polynomials
        int resultDegree = Math.Max(polynomialCoefficients1.Length, polynomialCoefficients2.Length);
        double[] subtraction = SubtractPolynomials(polynomialCoefficients1, polynomialCoefficients2, resultDegree);
        // Removing the 0 coefficients if there are such in front of the largest degree
        resultDegree = RemoveZeroesAtBeginning(resultDegree, subtraction);
        Console.WriteLine("\nAfter subtraction we have a polynomial with degree {0} and coefficients: ", resultDegree - 1);
        PrintCoefficients(resultDegree, subtraction);
        // Multiplying the polynomials
        int resultDegree1 = polynomialCoefficients1.Length + polynomialCoefficients2.Length;
        double[] multiplication = MultiplyPolynomials(polynomialCoefficients1, polynomialCoefficients2, resultDegree1);
        resultDegree1 = RemoveZeroesAtBeginning(resultDegree1, multiplication);
        Console.WriteLine("\nAfter multiplication we have a polynomial with degree {0} and coefficients: ", resultDegree1 - 1);
        PrintCoefficients(resultDegree1, multiplication);
    }

    static int RemoveZeroesAtBeginning(int resultDegree, double[] resultFromOperation)
    {
        while (resultDegree > 1 && resultFromOperation[resultDegree - 1] == 0)
        {
            resultDegree--;
        }
        return resultDegree;
    }

    static double[] MultiplyPolynomials(double[] polynomialCoefficients1, double[] polynomialCoefficients2, int resultDegree1)
    {
        double[] result = new double[resultDegree1];
        // Swapping so the first polynomial has greater degree
        if (polynomialCoefficients1.Length < polynomialCoefficients2.Length)
        {
            double[] temp = polynomialCoefficients1;
            polynomialCoefficients1 = polynomialCoefficients2;
            polynomialCoefficients2 = temp;
        }
        for (int degree1 = 0; degree1 < polynomialCoefficients1.Length; degree1++)
        {
            for (int degree2 = 0; degree2 < polynomialCoefficients2.Length; degree2++)
            {
                result[degree1 + degree2] += polynomialCoefficients1[degree1] * polynomialCoefficients2[degree2];
            }
        }
        return result;
    }

    static double[] SubtractPolynomials(double[] polynomialCoefficients1, double[] polynomialCoefficients2, int resultDegree)
    {
        double[] subtraction = new double[resultDegree];
        for (int index = 0; index < resultDegree; index++)
        {
            double resultCoeff = 0;
            if (index < polynomialCoefficients1.Length)
            {
                resultCoeff = polynomialCoefficients1[index];
            }
            if (index < polynomialCoefficients2.Length)
            {
                resultCoeff -= polynomialCoefficients2[index];
            }
            subtraction[index] = resultCoeff;
        }
        return subtraction;
    }

    static void PrintCoefficients(int resultDegree, double[] resultFromOperation)
    {
        for (int degree = resultDegree - 1; degree >= 0; degree--)
        {
            if (resultFromOperation[degree] != 0)
            {
                Console.WriteLine("{0} before degree {1} of x", resultFromOperation[degree], degree);
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
}
