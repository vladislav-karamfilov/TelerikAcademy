using System;
using System.Text;

class Article : IComparable<Article>
{
    public Article(string barcode, string vendor, string title, double price)
    {
        this.Barcode = barcode;
        this.Vendor = vendor;
        this.Title = title;
        this.Price = price;
    }

    public string Barcode { get; private set; }

    public string Vendor { get; private set; }

    public string Title { get; private set; }

    public double Price { get; private set; }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();
        output.Append('[');
        output.AppendFormat("Barcode: {0}; ", this.Barcode);
        output.AppendFormat("Vendor: {0}; ", this.Vendor);
        output.AppendFormat("Title: {0}; ", this.Title);
        output.AppendFormat("Price: {0:C}", this.Price);
        output.Append(']');
        return output.ToString();
    }

    public int CompareTo(Article other)
    {
        if (this == null ^ other == null)
        {
            return this == null ? -1 : 1;
        }

        if (this == null && other == null)
        {
            return 0;
        }

        return this.Barcode.CompareTo(other.Barcode);
    }
}
