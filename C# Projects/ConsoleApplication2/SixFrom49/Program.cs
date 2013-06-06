using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixFrom49
{
    class Program
    {
        static void Main()
        {
            int i1, i2, i3, i4, i5, i6;
            int counter = 0;
            for (i1 = 1; i1 <= 44; i1++)
                for (i2 = i1 + 1; i2 <= 45; i2++)
                    for (i3 = i2 + 1; i3 <= 46; i3++)
                        for (i4 = i3 + 1; i4 <= 47; i4++)
                            for (i5 = i4 + 1; i5 <= 48; i5++)
                                for (i6 = i5 + 1; i6 <= 49; i6++)
                                    //Console.WriteLine("{0} {1} {2} {3} {4} {5}",
                                      //i1, i2, i3, i4, i5, i6);
                                            counter++;
            Console.WriteLine(counter);
        }	
    }
}
