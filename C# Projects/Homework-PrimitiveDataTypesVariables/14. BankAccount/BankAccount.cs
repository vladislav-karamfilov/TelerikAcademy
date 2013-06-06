using System;

class BankAccount
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Declaring variables needed to keep information about a bank account***");
        Console.Write(decorationLine);
        string holderFirstName = null;
        string holderMiddleName = null;
        string holderLastName = null;
        string holderFullName = holderFirstName + " " + holderMiddleName + " " + holderLastName;
        decimal accountBalance = 0.0M;
        string bankName = null;
        string accountIBAN = null;
        string bankBicCode = null;
        ulong creditCardNumber1 = 0UL;
        ulong creditCardNumber2 = 0UL;
        ulong creditCardNumber3 = 0UL;
    }
}