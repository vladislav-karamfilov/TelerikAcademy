using System;
using System.Collections.Generic;

class Knapsack01ProblemSolver
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding optimal subset of products with maximal cost from a set of products");
        Console.WriteLine("with weights and costs that can be stored in a knapsack with weight limit***");
        Console.Write(decorationLine);

        List<Product> products = GetProducts();
        Console.WriteLine(string.Join(Environment.NewLine, products));

        int knapsackWeightLimit = 10;
        List<Product> optimalProductsSet = GetOptimalProductsSet(products, knapsackWeightLimit);

        Console.WriteLine("Optimal set of products for knapsack with weight limit {0} is: {1}",
                knapsackWeightLimit,
                string.Join(" | ", optimalProductsSet));
    }

    static List<Product> GetOptimalProductsSet(List<Product> products, int knapsackWeightLimit)
    {
        int sumOfWeights = 0;
        foreach (Product product in products)
        {
            sumOfWeights += product.Weight;
        }

        if (sumOfWeights <= knapsackWeightLimit)
        {
            return products;
        }

        int[] costs = new int[products.Count + 1];
        for (int cost = 1; cost < costs.Length; cost++)
        {
            costs[cost] = products[cost - 1].Cost;
        }

        int[] weights = new int[products.Count + 1];
        for (int weight = 1; weight < weights.Length; weight++)
        {
            weights[weight] = products[weight - 1].Weight;
        }

        int[,] calculatedOptimals = new int[products.Count + 1, knapsackWeightLimit + 1];
        for (int row = 1; row < calculatedOptimals.GetLength(0); row++)
        {
            for (int col = 0; col < calculatedOptimals.GetLength(1); col++)
            {
                if (col >= weights[row] &&
                    calculatedOptimals[row - 1, col] < calculatedOptimals[row - 1, col - weights[row]] + costs[row])
                {
                    calculatedOptimals[row, col] = calculatedOptimals[row - 1, col - weights[row]] + costs[row];
                }
                else
                {
                    calculatedOptimals[row, col] = calculatedOptimals[row - 1, col];
                }
            }
        }

        List<Product> optimalProducts = new List<Product>();
        int i = products.Count;
        int j = knapsackWeightLimit;
        while (j != 0 && i > 0)
        {
            if (calculatedOptimals[i, j] == calculatedOptimals[i - 1, j])
            {
                i--;
            }
            else
            {
                optimalProducts.Add(products[i - 1]);
                j -= weights[i];
                i--;
            }
        }

        return optimalProducts;
    }

    static List<Product> GetProducts()
    {
        List<Product> products = new List<Product>() 
        {
            new Product("Beer", 3, 2),
            new Product("Chips", 15, 3),
            new Product("Rakia", 50, 9),
            new Product("Bread", 1, 1),
            new Product("Cheese", 4, 5),
            new Product("Nuts", 1, 4),
            new Product("Ham", 2, 3),
            new Product("Vodka", 8, 12),
            new Product("Whiskey", 8, 13),
            new Product("Tomato", 2, 6),
            new Product("Ice", 1, 2),
        };

        return products;
    }
}

struct Product
{
    public Product(string name, int weight, int cost)
        : this()
    {
        this.Name = name;
        this.Weight = weight;
        this.Cost = cost;
    }

    public string Name { get; private set; }

    public int Weight { get; private set; }

    public int Cost { get; private set; }

    public override string ToString()
    {
        return string.Format("{0} -> weight: {1}; cost: {2}", this.Name, this.Weight, this.Cost);
    }
}