using System.Collections.Generic;

class StudentsComparer : IComparer<Student>
{

    public int Compare(Student first, Student second)
    {
        if (first == null ^ second == null)
        {
            return (first == null) ? -1 : 1;
        }

        if (first == null && second == null)
        {
            return 0;
        }

        int lastNamesComparison = first.LastName.CompareTo(second.LastName);
        if (lastNamesComparison == 0)
        {
            return first.FirstName.CompareTo(second.FirstName);
        }

        return lastNamesComparison;
    }
}
