using System;
using BankSystem.Common;
using System.Collections.Generic;

namespace BankSystem.UI
{
    class BankSystemDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Calculating interest amount for different kinds of bank accounts***");
            Console.Write(decorationLine);

            // Creating some customers
            IndividualCustomer customer1 = new IndividualCustomer("Ivan", "Ivanov", 11223344);
            CompanyCustomer customer2 = new CompanyCustomer("Company 0101", 99887766);
            CompanyCustomer customer3 = new CompanyCustomer("Company 123", 22334455);

            // Creating different kinds of accounts
            DepositAccount account1 = new DepositAccount(customer1, 10000m, 5.6m);
            LoanAccount account2 = new LoanAccount(customer2, 5000m, 4.8m);
            DepositAccount account3 = new DepositAccount(customer3, 3400m, 6.4m);

            // Creating the bank with the accounts
            List<Account> accounts = new List<Account>() { account1, account2, account3 };
            Bank fakeBank = new Bank("Fake Bank", accounts);

            // Adding account to the bank
            IndividualCustomer customer4 = new IndividualCustomer("Georgi", "Georgiev", 66778800);
            MortgageAccount account4 = new MortgageAccount(customer4, 2000m, 4.1m);
            fakeBank.AddAccount(account4);

            // Printing all the information about the bank and its clients on the console
            Console.WriteLine(fakeBank);

            // Depositting and withdrawing money to account1
            account1.DepositMoney(100m);
            account1.WithdrawMoney(2000m);
            Console.WriteLine("After depositting and withdrawing money from {0} {1}'s account the balance is: {2:C2}",
                customer1.FirstName, customer1.LastName, account1.Balance);
            Console.WriteLine();

            // Calculating the interest amount for all the accounts in the bank
            Console.WriteLine("Deposit account interest amount after 5 months: {0:C2}", account1.CalculateInterestAmount(5));
            account3.WithdrawMoney(2600m);
            Console.WriteLine("Deposit account interest amount after 2 months: {0:C2}", account3.CalculateInterestAmount(2));
            Console.WriteLine("Loan account interest amount after 10 months: {0:C2}", account2.CalculateInterestAmount(10));
            Console.WriteLine("Mortgage account interest amount after 1 year: {0:C2}", account4.CalculateInterestAmount(12));
        }
    }
}
