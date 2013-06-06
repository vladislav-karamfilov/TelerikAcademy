using System;

class SurfaceOfATriangle
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the surface of a triangle by some of its elements***");
        Console.Write(decorationLine);
        string choice = null;
        do
        {
            Console.WriteLine(".:Menu:.");
            Console.WriteLine("1. Calculating the surface by a side and the altitude to it");
            Console.WriteLine("2. Calculating the surface by the three sides");
            Console.WriteLine("3. Calculating the surface by two sides and the angle between them");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter a side: ");
                    double side = double.Parse(Console.ReadLine());
                    if (!ValidateSide(side))
                    {
                        Console.WriteLine("The side must be positive number!");
                        break;
                    }
                    Console.Write("Enter the altitude to it: ");
                    double altitude = double.Parse(Console.ReadLine());
                    if (!ValidateSide(altitude))
                    {
                        Console.WriteLine("The altitude must be positive number!");
                        break;
                    }
                    Console.WriteLine("The surface of the triangle is {0}.", SurfaceBySideAndAltitude(side, altitude));
                    break;
                case "2":
                    Console.Write("Enter the first side: ");
                    double firstSide = double.Parse(Console.ReadLine());
                    if (!ValidateSide(firstSide))
                    {
                        Console.WriteLine("The side must be positive number!");
                        break;
                    }
                    Console.Write("Enter the second side: ");
                    double secondSide = double.Parse(Console.ReadLine());
                    if (!ValidateSide(secondSide))
                    {
                        Console.WriteLine("The side must be positive number!");
                        break;
                    }
                    Console.Write("Enter the third side: ");
                    double thirdSide = double.Parse(Console.ReadLine());
                    if (!ValidateSide(thirdSide))
                    {
                        Console.WriteLine("The side must be positive number!");
                        break;
                    }
                    if (!ValidateTriangle(firstSide, secondSide, thirdSide))
                    {
                        Console.WriteLine("Triangle with these sides cannot exist!");
                        break;
                    }
                    Console.WriteLine("The surface of the triangle is {0}.", SurfaceByThreeSides(firstSide, secondSide, thirdSide));
                    break;
                case "3":
                    Console.Write("Enter the first side: ");
                    double side1 = double.Parse(Console.ReadLine());
                    if (!ValidateSide(side1))
                    {
                        Console.WriteLine("The side must be positive number!");
                        break;
                    }
                    Console.Write("Enter the second side: ");
                    double side2 = double.Parse(Console.ReadLine());
                    if (!ValidateSide(side2))
                    {
                        Console.WriteLine("The side must be positive number!");
                        break;
                    }
                    Console.Write("Enter the angle between them in degrees: ");
                    double angle = double.Parse(Console.ReadLine());
                    if (!ValidateAngle(angle))
                    {
                        Console.WriteLine("The angle must be between 0 and 180 degrees exclusively!");
                        break;
                    }
                    Console.WriteLine("The surface of the triangle is {0}.", SurfaceByTwoSidesAndAngle(side1, side2, angle));
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        } while (choice != "4");
    }

    static double SurfaceByTwoSidesAndAngle(double firstSide, double secondSide, double angle)
    {
        double angleInRadians = angle * Math.PI / 180;
        double surface = firstSide * secondSide * Math.Sin(angleInRadians) / 2;
        return surface;
    }

    static double SurfaceByThreeSides(double firstSide, double secondSide, double thirdSide)
    {
        double semiPerimeter = (firstSide + secondSide + thirdSide) / 2;
        double surface = Math.Sqrt(semiPerimeter * (semiPerimeter - firstSide) * (semiPerimeter - secondSide) * (semiPerimeter - thirdSide));
        return surface;
    }

    static double SurfaceBySideAndAltitude(double side, double altitude)
    {
        return (side * altitude) / 2;
    }

    static bool ValidateSide(double side)
    {
        if (side > 0)
        {
            return true;
        }
        return false;
    }

    static bool ValidateTriangle(double firstSide, double secondSide, double thirdSide)
    {
        if (firstSide + secondSide <= thirdSide || firstSide + thirdSide <= secondSide || secondSide + thirdSide <= firstSide)
        {
            return false;
        }
        return true;
    }

    static bool ValidateAngle(double angle)
    {
        if (angle <= 0 || angle >= 180)
        {
            return false;
        }
        return true;
    }
}
