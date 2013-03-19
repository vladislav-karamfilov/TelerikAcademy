using System;

namespace AnimalsHierarchy.Common
{
    public class Kitten : Cat, ISound
    {
        public Kitten(string name, int age)
            : base(name, age, false)
        {
        }

        public string GetSound()
        {
            return string.Format("Kitten '{0}': \"Meooow\"", this.Name);
        }
    }
}
