using System;

namespace AnimalsHierarchy.Common
{
    public abstract class Cat : Animal
    {
        protected Cat(string name, int age, bool isMale)
            : base(name, age, isMale)
        {
        }
    }
}
