using System;

class ShipDamage
{
    static void Main()
    {
        // Ship coordinates on the next 4 lines
        int sx1 = int.Parse(Console.ReadLine());
        int sy1 = int.Parse(Console.ReadLine());
        int sx2 = int.Parse(Console.ReadLine());
        int sy2 = int.Parse(Console.ReadLine());
        // Horizon coordinate (it's only on Y-axis)
        int h = int.Parse(Console.ReadLine());
        // Coordinates of the three catapults on the next 6 lines
        int cx1 = int.Parse(Console.ReadLine());
        int cy1 = int.Parse(Console.ReadLine());
        int cx2 = int.Parse(Console.ReadLine());
        int cy2 = int.Parse(Console.ReadLine());
        int cx3 = int.Parse(Console.ReadLine());
        int cy3 = int.Parse(Console.ReadLine());
        // Where the catapults hit
        cy1 = 2 * h - cy1;
        cy2 = 2 * h - cy2;
        cy3 = 2 * h - cy3;
        // Finding the boundaries of the ship
        int minX = Math.Min(sx1, sx2);
        int maxX = Math.Max(sx1, sx2);
        int minY = Math.Min(sy1, sy2);
        int maxY = Math.Max(sy1, sy2);
        // Checking if the hit is at a corner
        int damage = 0;
        if ((cx1 == minX || cx1 == maxX) && (cy1 == minY || cy1 == maxY))
        {
            damage += 25;
        }
        if ((cx2 == minX || cx2 == maxX) && (cy2 == minY || cy2 == maxY))
        {
            damage += 25;
        } 
        if ((cx3 == minX || cx3 == maxX) && (cy3 == minY || cy3 == maxY))
        {
            damage += 25;
        }
        // Checking if the hit is at a border
        if ((cx1 == minX || cx1 == maxX) && (cy1 > minY && cy1 < maxY) || 
            (cy1 == minY || cy1 == maxY) && (cx1 > minX && cx1 < maxX))
        {
            damage += 50;
        }
        if ((cx2 == minX || cx2 == maxX) && (cy2 > minY && cy2 < maxY) ||
            (cy2 == minY || cy2 == maxY) && (cx2 > minX && cx2 < maxX))
        {
            damage += 50;
        }
        if ((cx3 == minX || cx3 == maxX) && (cy3 > minY && cy3 < maxY) ||
            (cy3 == minY || cy3 == maxY) && (cx3 > minX && cx3 < maxX))
        {
            damage += 50;
        }
        // Checking if the hit is inside the ship
        if (cx1 < maxX && cx1 > minX && cy1 < maxY && cy1 > minY)
        {
            damage += 100;
        }
        if (cx2 < maxX && cx2 > minX && cy2 < maxY && cy2 > minY)
        {
            damage += 100;
        }
        if (cx3 < maxX && cx3 > minX && cy3 < maxY && cy3 > minY)
        {
            damage += 100;
        }
        Console.WriteLine(damage + "%");
    }
}
