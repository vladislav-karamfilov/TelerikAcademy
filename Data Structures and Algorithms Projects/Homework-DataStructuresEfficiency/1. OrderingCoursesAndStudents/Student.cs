class Student
{
    public Student(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public override string ToString()
    {
        string output = string.Format("{0} {1}", this.FirstName, this.LastName);
        return output;
    }
}