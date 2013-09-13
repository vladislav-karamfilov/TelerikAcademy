//------------FOR Task 1 see Frameworks.cs and NorthWind.Data---------------------------------
//------------FOR Task 2 and Task 3 see TelerikAcademy.Client and TelerikAcademy.Data---------
//------------FOR Task 4 and Task 5 see the apropriate projects-------------------------------

namespace TelerikAcademy.Client
{
    using System;
    using System.Diagnostics;

    class ClientUI
    {
        static void Main()
        {
            DeleteComparer dc = new DeleteComparer();

            //-------first add 100 000  rows in the table
            dc.Insert100000EntitiesInDB();

            Stopwatch sw = new Stopwatch();

            sw.Start();
            dc.BulkDelete();
            sw.Stop();
            Console.WriteLine("Bulk delete time: " + sw.Elapsed);

            //----------------Bulk delete result:  
            //----------------PROFILER: 26 rows; 

            sw.Reset();

            //------ add again 100 000  rows in the table
            dc.Insert100000EntitiesInDB();

            sw.Start();
            dc.NormalDelete();
            sw.Stop();
            Console.WriteLine("Normal delete time: " + sw.Elapsed);

            //----------------Normal delete result:  
            //----------------PROFILER: 3356 rows; 

            Serializator serializator = new Serializator();
            serializator.SerializeDeserialize("Guy");
        }
    }
}
