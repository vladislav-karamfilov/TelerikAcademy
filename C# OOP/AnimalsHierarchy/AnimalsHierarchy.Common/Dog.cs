using System;

namespace AnimalsHierarchy.Common
{
    public class Dog : Animal, ISound
    {
        public Dog(string name, int age, bool isMale)
            : base(name, age, isMale)
        {
        }

        public string GetSound()
        {
            return string.Format("Dog '{0}': \"Woof, woof\"", this.Name);
        }
    }
}
