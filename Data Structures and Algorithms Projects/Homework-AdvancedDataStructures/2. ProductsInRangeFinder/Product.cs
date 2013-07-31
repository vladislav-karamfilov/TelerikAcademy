using System;

class Product : IComparable<Product>
{
    public Product(string name, double price)
    {
        this.Name = name;
        this.Price = price;
    }

    public string Name { get; set; }

    public double Price { get; set; }

    public int CompareTo(Product other)
    {
        if (this == null ^ other == null)
        {
            return this == null ? -1 : 1;
        }

        if (this == null && other == null)
        {
            return 0;
        }

        return this.Price.CompareTo(other.Price);
    }

    public override string ToString()
    {
        return string.Format("{0} -> {1}", this.Name, this.Price);
    }
}
