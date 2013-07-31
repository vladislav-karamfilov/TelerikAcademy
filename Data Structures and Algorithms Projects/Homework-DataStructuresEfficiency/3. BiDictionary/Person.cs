public class Person
{
    public Person(string firstName, string lastName, int age)
    { 
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public int Age { get; private set; }

    public override string ToString()
    {
        return string.Format(
            "[First name: {0}; Last name: {1}; Age: {2}]", 
            this.FirstName, 
            this.LastName, 
            this.Age);
    }
}
