using System;

namespace AnimalsHierarchy.Common
{
    public class Tomcat : Cat, ISound
    {
        public Tomcat(string name, int age)
            : base(name, age, true)
        {
        }

        public string GetSound()
        {
            return string.Format("Tomcat '{0}': \"Puuurrr\"", this.Name);
        }
    }
}
