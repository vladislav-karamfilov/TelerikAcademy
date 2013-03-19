using System;
using GenericList.Data;

namespace GenericList.Test
{
    class GenericListTest
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Creating and clearing lists of some type. Adding, removing, accessing, finding, inserting elements.***");
            Console.Write(decorationLine);

            Console.WriteLine("---Creating an empty list of strings---");
            GenericList<string> list = new GenericList<string>();
            Console.WriteLine("Empty list count: " + list.Count);
            Console.WriteLine("Empty list capacity: " + list.Capacity);

            Console.WriteLine("\n---Adding some elements to the list---");
            for (int count = 0; count < 16; count++)
            {
                list.Add("element " + (count + 1));
            }
            Console.WriteLine("The elements of the list are: " + list.ToString());
            Console.WriteLine("After adding some elements list count: " + list.Count);
            Console.WriteLine("After adding some elements list capacity: " + list.Capacity);

            Console.WriteLine("\n---Printing elements at specific indexes---");
            Console.WriteLine("Printing element with index 5: " + list[5]);
            Console.WriteLine("Printing element with index 0: " + list[0]);

            Console.WriteLine("\n---Removing some elements from the list---");
            list.RemoveAt(5);
            list.RemoveAt(0);
            list.RemoveAt(12);
            Console.WriteLine("After removing elements from the list: " + list.ToString());
            Console.WriteLine("Current list count: " + list.Count);

            Console.WriteLine("\n---Inserting some elements to the list---");
            list.InsertAt("string 5", 5);
            list.InsertAt("appear", list.Count - 1);
            list.InsertAt("string11", list.Count);
            Console.WriteLine("The new list is: " + list.ToString());
            Console.WriteLine("The new list count is: " + list.Count);

            Console.WriteLine("\n---Finding specific elements from the list---");
            Console.WriteLine("The index of 'element 9' is: " + list.Find("element 9"));
            Console.WriteLine("The index of 'element 111' is: " + list.Find("element 111"));

            Console.WriteLine("\n---Finding the maximal and the minimal element in the list---");
            Console.WriteLine("The minimal element in the list is: " + list.Min());
            Console.WriteLine("The maximal element in the list is: " + list.Max());

            Console.WriteLine("\n---Clearing the list---");
            list.Clear();
            Console.WriteLine("List count after clearing the list: " + list.Count);
            Console.WriteLine("List capacity after clearing the list: " + list.Capacity);
            
            // We cannot use Min() and Max() on "test" because it doesn't implement IComparable<>
            GenericList<Point2D> test = new GenericList<Point2D>();
            test.Add(new Point2D(5, 6));
            test.Add(new Point2D(-2, 1));
            test.Add(new Point2D(-12, -11));
            //test.Min();
            //test.Max()
        }
    }
}
 