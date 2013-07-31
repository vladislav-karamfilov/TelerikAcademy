using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

class ShoppingCenterDemo
{
    static void Main()
    {
        ShoppingCenter shoppingCenter = new ShoppingCenter();
        CommandExecutor commandExecutor = new CommandExecutor(shoppingCenter);
        StringBuilder output = new StringBuilder();
        int commandsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < commandsCount; i++)
        {
            Command command = Command.Parse(Console.ReadLine());
            output.Append(commandExecutor.Execute(command));
        }

        Console.Write(output);
    }
}

class CommandExecutor
{
    private const string AddCommand = "AddProduct";
    private const string DeleteCommand = "DeleteProducts";
    private const string FindByNameCommand = "FindProductsByName";
    private const string FindInPriceRangeCommand = "FindProductsByPriceRange";
    private const string FindByProducerCommand = "FindProductsByProducer";
    private const string ProductAdded = "Product added";
    private const string ProductsDeleted = "products deleted";
    private const string NoProductsFound = "No products found";

    private readonly ShoppingCenter shoppingCenter;

    public CommandExecutor(ShoppingCenter shoppingCenter)
    {
        this.shoppingCenter = shoppingCenter;
    }

    public StringBuilder Execute(Command command)
    {
        switch (command.Name)
        {
            case AddCommand:
                return ExecuteAddCommand(command.Arguments);
            case DeleteCommand:
                return ExecuteDeleteCommand(command.Arguments);
            case FindByNameCommand:
                return ExecuteFindByNameCommand(command.Arguments[0]);
            case FindInPriceRangeCommand:
                return ExecuteFindInPriceRangeCommand(command.Arguments);
            case FindByProducerCommand:
                return ExecuteFindByProducerCommand(command.Arguments[0]);
            default:
                throw new ArgumentException("Invalid command!");
        }
    }

    private StringBuilder ExecuteAddCommand(string[] arguments)
    {
        double productPrice = double.Parse(arguments[1]);
        this.shoppingCenter.AddProduct(new Product(arguments[0], productPrice, arguments[2]));
        return new StringBuilder().AppendLine(ProductAdded);
    }

    private StringBuilder ExecuteDeleteCommand(string[] arguments)
    {
        int deletedProductsCount = 0;
        if (arguments.Length == 1)
        {
            deletedProductsCount = this.shoppingCenter.DeleteProducts(arguments[0]);
        }
        else
        {
            deletedProductsCount = this.shoppingCenter.DeleteProducts(arguments[0], arguments[1]);
        }

        StringBuilder output = new StringBuilder();
        if (deletedProductsCount != 0)
        {
            return output.AppendFormat("{0} {1}\n", deletedProductsCount, ProductsDeleted);
        }

        return output.AppendLine(NoProductsFound);
    }

    private StringBuilder ExecuteFindByNameCommand(string name)
    {
        StringBuilder output = new StringBuilder();
        ICollection<Product> foundProducts = this.shoppingCenter.FindProductsByName(name);
        if (foundProducts.Count == 0)
        {
            output.AppendLine(NoProductsFound);
        }
        else
        {
            foreach (var product in foundProducts)
            {
                output.Append("{");
                output.Append(product.ToString());
                output.AppendLine("}");
            }
        }

        return output;
    }

    private StringBuilder ExecuteFindByProducerCommand(string producer)
    {
        StringBuilder output = new StringBuilder();
        ICollection<Product> foundProducts = this.shoppingCenter.FindProductsByProducer(producer);
        if (foundProducts.Count() == 0)
        {
            output.AppendLine(NoProductsFound);
        }
        else
        {
            foreach (var product in foundProducts)
            {
                output.Append("{");
                output.Append(product.ToString());
                output.AppendLine("}");
            }
        }

        return output;
    }

    private StringBuilder ExecuteFindInPriceRangeCommand(string[] arguments)
    {
        StringBuilder output = new StringBuilder();
        double fromPrice = double.Parse(arguments[0]);
        double toPrice = double.Parse(arguments[1]);
        var foundProducts = this.shoppingCenter.FindProductsInRange(fromPrice, toPrice);
        if (foundProducts.Count == 0)
        {
            output.AppendLine(NoProductsFound);
        }
        else
        {
            foreach (var product in foundProducts)
            {
                output.Append("{");
                output.Append(product.ToString());
                output.AppendLine("}");
            }
        }

        return output;
    }
}

class Command
{
    public string Name { get; set; }

    public string[] Arguments { get; set; }

    public static Command Parse(string line)
    {
        Command command = new Command();
        command.Name = line.Substring(0, line.IndexOf(' '));
        command.Arguments = line.Substring(line.IndexOf(' ') + 1).Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        return command;
    }
}

class Product : IComparable<Product>
{
    public Product(string name, double price, string producer)
    {
        this.Name = name;
        this.Price = price;
        this.Producer = producer;
    }

    public string Name { get; set; }

    public double Price { get; set; }

    public string Producer { get; set; }

    public override string ToString()
    {
        return string.Format("{0};{1};{2:0.00}", this.Name, this.Producer, this.Price);
    }

    public int CompareTo(Product other)
    {
        int nameComparison = string.Compare(this.Name, other.Name, StringComparison.InvariantCulture);
        if (nameComparison != 0)
        {
            return nameComparison;
        }

        int producerComparison = string.Compare(this.Producer, other.Producer, StringComparison.InvariantCulture);
        if (producerComparison != 0)
        {
            return producerComparison;
        }

        return this.Price.CompareTo(other.Price);
    }
}

class ShoppingCenter
{
    private const bool AllowDuplicates = true;

    private readonly MultiDictionary<string, Product> productsByName;
    private readonly OrderedMultiDictionary<double, Product> productsByPrices;
    private readonly MultiDictionary<string, Product> productsByProducer;

    public ShoppingCenter()
    {
        this.productsByName = new MultiDictionary<string, Product>(AllowDuplicates);
        this.productsByPrices = new OrderedMultiDictionary<double, Product>(AllowDuplicates);
        this.productsByProducer = new MultiDictionary<string, Product>(AllowDuplicates);
    }

    public void AddProduct(Product product)
    {
        this.productsByName.Add(product.Name, product);
        this.productsByPrices.Add(product.Price, product);
        this.productsByProducer.Add(product.Producer, product);
    }

    public int DeleteProducts(string name, string producer)
    {
        IEnumerable<Product> bySpecifiedNameAndProducer =
            this.productsByName[name].Where(product => product.Producer == producer);
        int removedCount = bySpecifiedNameAndProducer.Count();

        foreach (Product product in bySpecifiedNameAndProducer)
        {
            this.productsByPrices.Remove(product.Price);
        }

        this.productsByName.Remove(name);
        this.productsByProducer.Remove(producer);

        return removedCount;
    }

    public int DeleteProducts(string producer)
    {
        ICollection<Product> bySpecifiedProducer =
            this.productsByProducer[producer];
        int removedCount = bySpecifiedProducer.Count;

        foreach (Product product in bySpecifiedProducer)
        {
            this.productsByName.Remove(product.Name);
            this.productsByPrices.Remove(product.Price);
        }

        this.productsByProducer.Remove(producer);

        return removedCount;
    }

    public ICollection<Product> FindProductsByName(string name)
    {
        return new OrderedBag<Product>(this.productsByName[name]);
    }

    public ICollection<Product> FindProductsInRange(double fromPrice, double toPrice)
    {
        return new OrderedBag<Product>(this.productsByPrices.Range(fromPrice, true, toPrice, true).Values);
    }

    public ICollection<Product> FindProductsByProducer(string producer)
    {
        return new OrderedBag<Product>(this.productsByProducer[producer]);
    }
}