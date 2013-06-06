using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectDataMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter correct data: ");
            double number = GetData();
        }
        static double GetData()
        {
            double number;
            while (!double.TryParse(Console.ReadLine().Replace(',','.'), out number))
            {
                Console.WriteLine("Invalid input! Try again...");
                Console.Write("Enter correct data: ");
            }
            return number;
        }
    }
}
