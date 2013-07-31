using System;
using System.Collections.Generic;

class Frames
{
    static void Main()
    {
        int framesCount = int.Parse(Console.ReadLine());
        Frame[] frames = new Frame[framesCount];
        for (int i = 0; i < framesCount; i++)
        {
            string[] frameDimensions = Console.ReadLine().Split(' ');
            frames[i] = new Frame(frameDimensions[0], frameDimensions[1]);
        }

        SortedSet<string> orderings = new SortedSet<string>();
        GetOrderings(orderings, frames, 0);

        Console.WriteLine(orderings.Count);
        foreach (string ordering in orderings)
        {
            Console.WriteLine(ordering);
        }
    }

    static void GetOrderings(SortedSet<string> orderings, Frame[] frames, int index)
    {
        if (index == frames.Length)
        {
            orderings.Add(string.Join(" | ", (object[])frames));
            return;
        }

        for (int i = index; i < frames.Length; i++)
        {
            Swap(ref frames[index], ref frames[i]);
            GetOrderings(orderings, frames, index + 1);

            if (frames[index].Width != frames[index].Height)
            {
                frames[index].Flip();
                GetOrderings(orderings, frames, index + 1);
                frames[index].Flip();
            }

            Swap(ref frames[index], ref frames[i]);
        }
    }

    static void Swap(ref Frame first, ref Frame second)
    {
        Frame swapValue = first;
        first = second;
        second = swapValue;
    }
}

class Frame : IComparable<Frame>
{
    public Frame(string width, string height)
    {
        this.Width = width;
        this.Height = height;
    }

    public string Width { get; private set; }

    public string Height { get; private set; }

    public void Flip()
    {
        string swapValue = this.Width;
        this.Width = this.Height;
        this.Height = swapValue;
    }

    public override string ToString()
    {
        return string.Format("({0}, {1})", this.Width, this.Height);
    }

    public int CompareTo(Frame other)
    {
        int result = this.Width.CompareTo(other.Width);
        if (result != 0)
        {
            return result;
        }

        return this.Height.CompareTo(other.Height);
    }
}