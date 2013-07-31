using System;
using System.Collections.Generic;

class NakovNumber
{
    static readonly SortedDictionary<string, Author> authors =
        new SortedDictionary<string, Author>();
    static readonly Dictionary<Author, HashSet<Author>> coauthors =
        new Dictionary<Author, HashSet<Author>>();

    static void Main()
    {
        ReadInput();

        CalcualteNakovNumbers();

        foreach (var item in authors)
        {
            Console.WriteLine("{0} {1}",
                item.Value.Name,
                item.Value.NakovNumber != int.MaxValue ? item.Value.NakovNumber : -1);
        }
    }

    static void CalcualteNakovNumbers()
    {
        Queue<Tuple<Author, int>> authorsToCalculate =
            new Queue<Tuple<Author, int>>();
        authors["NAKOV"].NakovNumber = 0;
        authorsToCalculate.Enqueue(new Tuple<Author, int>(authors["NAKOV"], 0));
        while (authorsToCalculate.Count > 0)
        {
            Tuple<Author, int> currentAuthor = authorsToCalculate.Dequeue();

            foreach (var coauthor in coauthors[currentAuthor.Item1])
            {
                if (coauthor.NakovNumber == int.MaxValue)
                {
                    coauthor.NakovNumber = currentAuthor.Item2 + 1;
                    authorsToCalculate.Enqueue(new Tuple<Author, int>(coauthor, currentAuthor.Item2 + 1));
                }
            }
        }
    }

    static void ReadInput()
    {
        char[] separators = new char[] { ',', '\"' };
        string[] publicationsAuthors =
            Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < publicationsAuthors.Length; i += 2)
        {
            string[] publicationAuthors = publicationsAuthors[i].Split(' ');
            for (int j = 0; j < publicationAuthors.Length; j++)
            {
                if (!authors.ContainsKey(publicationAuthors[j]))
                {
                    authors.Add(publicationAuthors[j], new Author(publicationAuthors[j], int.MaxValue));
                    coauthors.Add(authors[publicationAuthors[j]], new HashSet<Author>());
                }

                for (int k = j + 1; k < publicationAuthors.Length; k++)
                {
                    if (!authors.ContainsKey(publicationAuthors[k]))
                    {
                        authors.Add(publicationAuthors[k], new Author(publicationAuthors[k], int.MaxValue));
                        coauthors.Add(authors[publicationAuthors[k]], new HashSet<Author>());
                    }

                    if (!coauthors[authors[publicationAuthors[k]]].Contains(authors[publicationAuthors[j]]))
                    {
                        coauthors[authors[publicationAuthors[k]]].Add(authors[publicationAuthors[j]]);
                    }

                    if (!coauthors[authors[publicationAuthors[j]]].Contains(authors[publicationAuthors[k]]))
                    {
                        coauthors[authors[publicationAuthors[j]]].Add(authors[publicationAuthors[k]]);
                    }
                }
            }
        }
    }
}

class Author
{
    public Author(string name, int nakovNumber)
    {
        this.Name = name;
        this.NakovNumber = nakovNumber;
    }

    public string Name { get; private set; }

    public int NakovNumber { get; set; }

    public override bool Equals(object obj)
    {
        return this.Name.Equals((obj as Author).Name);
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode();
    }
}