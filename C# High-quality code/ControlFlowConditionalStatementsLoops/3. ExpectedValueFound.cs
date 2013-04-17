bool expectedValueFound = false;
for (int index = 0; index < 100; index++) 
{
    if (index % 10 == 0)
    {
        if (array[index] == expectedValue) 
        {
            expectedValueFound = true;
	    }
    }

    Console.WriteLine(array[index]);
}

if (expectedValueFound)
{
    Console.WriteLine("Value Found!");
}