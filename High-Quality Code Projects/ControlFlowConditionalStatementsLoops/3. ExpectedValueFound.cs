bool expectedValueFound = false;
for (int index = 0; index < 100; index++) 
{
    Console.WriteLine(array[index]);
    
    if (index % 10 == 0)
    {
        if (array[index] == expectedValue) 
        {
            expectedValueFound = true;
            break;
	    }
    }
}

if (expectedValueFound)
{
    Console.WriteLine("Value Found!");
}