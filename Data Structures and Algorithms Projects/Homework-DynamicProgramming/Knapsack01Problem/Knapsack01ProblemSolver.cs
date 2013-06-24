using System;
using System.Collections.Generic;

class Knapsack01ProblemSolver
{
    const int NotCalculated = -1;

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

        int[] calculatedOptimals = new int[knapsackWeightLimit + 1];
        for (int i = 0; i < calculatedOptimals.Length; i++)
        {
            calculatedOptimals[i] = NotCalculated;
        }

        int[] costs = new int[products.Count + 1];
        for (int i = 1; i < costs.Length; i++)
        {
            costs[i] = products[i - 1].Cost;
        }

        int[] weights = new int[products.Count + 1];
        for (int i = 1; i < weights.Length; i++)
        {
            weights[i] = products[i - 1].Weight;
        }

        bool[,] optimalProductsIndicators = new bool[knapsackWeightLimit + 1, products.Count + 1];
        
        FindOptimum(costs, weights, calculatedOptimals, optimalProductsIndicators, knapsackWeightLimit);

        List<Product> optimalProducts = new List<Product>();
        for (int i = 1; i < optimalProductsIndicators.GetLength(1); i++)
        {
            if (optimalProductsIndicators[knapsackWeightLimit, i])
            {
                optimalProducts.Add(products[i - 1]);
            }
        }

        return optimalProducts;
    }

    static void FindOptimum(
        int[] costs, 
        int[] weights, 
        int[] calculatedOptimals, 
        bool[,] optimalProductsIndicators,
        int currentWeightLimit)
    {
        int bestProductIndex = 0;
        int optimum = 0;
        int currentOptimum = -1;
        for (int i = 1; i < weights.Length; i++)
        {
            if (currentWeightLimit >= weights[i])
            {
                int newWeightLimit = currentWeightLimit - weights[i];
                if (calculatedOptimals[newWeightLimit] == NotCalculated)
                {
                    FindOptimum(costs, weights, calculatedOptimals, optimalProductsIndicators, newWeightLimit);
                }

                if (!optimalProductsIndicators[newWeightLimit, i])
                {
                    currentOptimum = costs[i] + calculatedOptimals[newWeightLimit];
                }
                else
                {
                    currentOptimum = 0;
                }

                if (currentOptimum > optimum)
                {
                    bestProductIndex = i;
                    optimum = currentOptimum;
                }
            }
        }

        calculatedOptimals[currentWeightLimit] = optimum;
        if (bestProductIndex > 0)
        {
            for (int i = 0; i < optimalProductsIndicators.GetLength(1); i++)
			{
                optimalProductsIndicators[currentWeightLimit, i] = 
                    optimalProductsIndicators[currentWeightLimit - weights[bestProductIndex], i];
			}

            optimalProductsIndicators[currentWeightLimit, bestProductIndex] = true; 
        }
    }

    static List<Product> GetProducts()
    {
        List<Product> products = new List<Product>() 
        {
            new Product("Beer", 3, 2),
            new Product("Chips", 15, 3),
            new Product("Rakia", 5, 9),
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