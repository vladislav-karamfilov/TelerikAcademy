using System;

namespace AnimalsHierarchy.Common
{
    public class Frog : Animal
    {
        public Frog(string name, int age, bool isMale)
            : base(name, age, isMale)
        {
        }

        public string GetSound()
        {
            return string.Format("Frog '{0}': \"Ribbit, ribbit\"", this.Name);
        }
    }
}
