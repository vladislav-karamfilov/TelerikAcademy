using System;

namespace AnimalsHierarchy.Common
{
    public abstract class Animal
    {
        private int age;
        private string name;
        private bool isMale;

        public int Age
        {
            get { return this.age; }
            protected set
            {
                if (value <= 0 || value > 40)
                {
                    throw new ArgumentOutOfRangeException("Animal's age is between 1 and 40 years!");
                }
                this.age = value;
            }
        }
        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Animal's name cannot be empty or null!");
                }
                this.name = value;
            }
        }
        public bool IsMale
        {
            get { return this.isMale; }
            protected set { this.isMale = value; }
        }

        protected Animal(string name, int age, bool isMale)
        {
            this.Name = name;
            this.Age = age;
            this.IsMale = isMale;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nAge: {1}\nSex: {2}", this.Name, this.Age,
                isMale == true ? "male" : "female");
        }
    }
}
