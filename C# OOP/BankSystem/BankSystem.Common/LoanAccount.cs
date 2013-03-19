using System;

namespace BankSystem.Common
{
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestAmount(int periodInMonths)
        {
            if (periodInMonths < 0)
            {
                throw new ArgumentOutOfRangeException("Interest period cannot be negative!");
            }
            decimal interestAmount = 0.0m;
            if (this.Customer is IndividualCustomer)
            {
                if (periodInMonths > 3)
                {
                    interestAmount = this.Balance * (this.InterestRate / 100) * (periodInMonths - 3);
                }
            }
            else if (this.Customer is CompanyCustomer)
            {
                if (periodInMonths > 2)
                {
                    interestAmount = this.Balance * (this.InterestRate / 100) * (periodInMonths - 2);
                }
            }
            return interestAmount;
        }

        public void DepositMoney(decimal amount)
        {
            if (amount < 0.0m)
            {
                throw new ArgumentOutOfRangeException("Cannot deposit negative amount of money!");
            }
            this.Balance += amount;
        }
    }
}
