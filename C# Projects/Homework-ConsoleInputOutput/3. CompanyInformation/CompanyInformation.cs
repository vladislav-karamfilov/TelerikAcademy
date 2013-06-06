using System;

class CompanyInformation
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Entering information about a company and its manager and printing it***");
        Console.Write(decorationLine);
        //Gathering information for the company
        Console.WriteLine("---Enter information about the company---");
        Console.Write("Enter company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Enter company's address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Enter company's phone number: ");
        string companyPhoneNumber = Console.ReadLine();
        Console.Write("Enter company's fax number: ");
        string companyFaxNumber = Console.ReadLine();
        Console.Write("Enter company's web site: ");
        string companyWebSite = Console.ReadLine();
        //Gathering information for the company's manager
        Console.WriteLine("---Now enter information about the company's manager---");
        Console.Write("Enter manager's first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Enter manager's last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("Enter manager's age: ");
        byte managerAge = byte.Parse(Console.ReadLine());
        Console.Write("Enter manager's phone number: ");
        string managerPhoneNumber = Console.ReadLine();
        //Printing the information on the console
        Console.WriteLine("\n!!!Company information!!!");
        Console.WriteLine("Name: {0}\nAddress: {1}\nPhone number: {2}\nFax number: {3}\nWeb site: {4}", 
            companyName, companyAddress, companyPhoneNumber, companyFaxNumber, companyWebSite);
        Console.WriteLine("!!!Information about the company's manager!!!");
        Console.WriteLine("First name: {0}\nLast name: {1}\nAge: {2}\nPhone number: {3}", 
            managerFirstName, managerLastName, managerAge, managerPhoneNumber);
    }
}
