using System;

class FighterAttack
{
    static void Main()
    {
        int px1 = int.Parse(Console.ReadLine());
        int py1 = int.Parse(Console.ReadLine());
        int px2 = int.Parse(Console.ReadLine());
        int py2 = int.Parse(Console.ReadLine());
        int fx = int.Parse(Console.ReadLine());
        int fy = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        // Where the missle hits
        fx += d;
        // Finding the boundaries of the plant
        int minX = Math.Min(px1, px2);
        int maxX = Math.Max(px1, px2);
        int minY = Math.Min(py1, py2);
        int maxY = Math.Max(py1, py2);
        int damage = 0;
        if (px1 == px2 && py1 == py2 && fx == px1 && fy == py1)
        {
            damage = 100; // The plant is one cell and the hit is there
        }
        else if (fx >= minX && fx <= maxX && fy == minY)
        {
            damage = 150; // The hit is at the bottom border + hits the cell above
            if (fx < maxX)
            {
                damage += 75; // The front cell is also damaged
            }
        }
        else if (fx >= minX && fx <= maxX && fy == maxY)
        {
            damage = 150; // The hit is at the top border + hits the cell below
            if (fx < maxX)
            {
                damage += 75; // The front cell is also damaged
            }
        }
        else if (fx == minX && fy >= minY && fy <= maxY)
        {
            damage = 225; // The hit is at the left border + hits the front cell + hits the cell above/below
            if (fy > minY && fy < maxY) 
            {
                damage += 50; // Hits the cell below/above
            }
        }
        else if (fx == maxX && fy >= minY && fy <= maxY)
        {
            damage = 150; // The hit is at the right border + hits the cell above/below
            if (fy > minY && fy < maxY)
            {
                damage += 50; // Hits the cell below/above
            }
        }
        else if (fx > minX && fx < maxX && fy > minY && fy < maxY)
        {
            damage = 275; // The hit is inside the plane -> max damage
        }
        else if (fx == minX - 1 && fy >= minY && fy <= maxY)
        {
            damage = 75; // Only the front cell is damaged
        }
        else if ((fy == minY - 1 || fy == maxY + 1) && (fx >= minX && fx <= maxX))
        {
            damage = 50; // Only the above/below cell is damaged
        }
        Console.WriteLine(damage + "%");
    }
}
