using System;
using System.Linq;
using AnimalsHierarchy.Common;

namespace AnimalsHierarchy.UI
{
    class AnimalsHierarchyDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Calculating the average age of some kinds of animals***");
            Console.Write(decorationLine);

            Kitten[] kittens = new Kitten[]
            {
                new Kitten("Beanie", 4),
                new Kitten("Bitsy", 5),
                new Kitten("Bunny", 15),
                new Kitten("Gussie", 6),
                new Kitten("Herbie", 3)
            };

            Tomcat[] tomcats = new Tomcat[]
            {
                new Tomcat("Tango", 18),
                new Tomcat("Telstar", 9),
                new Tomcat("Thunder", 5),
                new Tomcat("Taffy", 11),
                new Tomcat("Titan", 22)
            };

            Dog[] dogs = new Dog[]
            {
                new Dog("Abby", 2, false),
                new Dog("Action", 25, true),
                new Dog("Sharo", 10, true),
                new Dog("Addison", 8, false),
                new Dog("Artie", 9, true)
            };

            Frog[] frogs = new Frog[]
            {
                new Frog("Froggie", 6, true),
                new Frog("Lizzie", 2, false),
                new Frog("Fue", 5, false),
                new Frog("Pickles", 19, false),
                new Frog("Prince", 9, true)
            };

            // Using random indices from the arrays
            Console.WriteLine("---Printing all the information about one of animal of each kind---");
            Console.WriteLine(kittens[1]);
            Console.WriteLine(tomcats[4]);
            Console.WriteLine(dogs[0]);
            Console.WriteLine(frogs[3]);
            Console.WriteLine();
            
            Console.WriteLine("---Printing the typical sound that different kinds of animals produce---");
            // Using random indices from the arrays
            Console.WriteLine(kittens[2].GetSound());
            Console.WriteLine(tomcats[0].GetSound());
            Console.WriteLine(dogs[3].GetSound());
            Console.WriteLine(frogs[1].GetSound());
            Console.WriteLine();
            
            Console.WriteLine("---Printing the average age of the animals of each kind---");
            Console.WriteLine("Average age of the kittens: " + GetAverageAge(kittens));
            Console.WriteLine("Average age of the tomcats: " + GetAverageAge(tomcats));
            Console.WriteLine("Average age of the dogs: " + GetAverageAge(dogs));
            Console.WriteLine("Average age of the frogs: " + GetAverageAge(frogs));
            Console.WriteLine();
            
            // Getting the average age of all animals
            Animal[] animals = new Animal[20]
            {
                kittens[0], kittens[1], kittens[2], kittens[3], kittens[4],
                tomcats[0], tomcats[1], tomcats[2], tomcats[3], tomcats[4],
                dogs[0], dogs[1], dogs[2], dogs[3], dogs[4],  
                frogs[0], frogs[1], frogs[2], frogs[3], frogs[4]
            };
            Console.WriteLine("Average age of all animals: " + GetAverageAge(animals));
        }

        static double GetAverageAge(Animal[] animals)
        {
            return animals.Average(animal => animal.Age); // Using extension method from namespace System.Linq
        }
    }
}
