using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            int px1 = int.Parse(Console.ReadLine());
            int py1 = int.Parse(Console.ReadLine());
            int px2 = int.Parse(Console.ReadLine());
            int py2 = int.Parse(Console.ReadLine());
            int fx = int.Parse(Console.ReadLine());
            int fy = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int minX = Math.Min(px1, px2);
            int maxX = Math.Max(px1, px2);
            int minY = Math.Min(py1, py2);
            int maxY = Math.Max(py1, py2);
            // Hit points
            int hitX = fx + d;
            int hitY = fy;
            int hitUpX = hitX;
            int hitUpY = hitY + 1;
            int hitDownX = hitX;
            int hitDownY = hitY - 1;
            int hitRightX = hitX + 1;
            int hitRightY = hitY;
            int damage = 0;
            if (hitRightX >= minX && hitRightX <= maxX && hitRightY >= minY && hitRightY <= maxY)
            {
                damage += 75;
            }
            if (hitX >= minX && hitX <= maxX && hitY >= minY && hitY <= maxY)
            {
                damage += 100;
            }
            if (hitDownX >= minX && hitDownX <= maxX && hitDownY >= minY && hitDownY <= maxY)
            {
                damage += 50;
            }
            if (hitUpX >= minX && hitUpX <= maxX && hitUpY >= minY && hitUpY <= maxY)
            {
                damage += 50;
            }
            Console.WriteLine(damage + "%");
        }
    }
}
