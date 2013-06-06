using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Common
{
    public class Bank
    {
        private List<Account> accounts;
        private string name;

        public List<Account> Accounts
        {
            get { return this.accounts; }
            set
            {
                this.accounts = new List<Account>();
                foreach (Account newAccount in value)
                {
                    AddNewAccount(newAccount);
                }
            }
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Bank name cannot be empty or null!");
                }
                this.name = value;
            }
        }

        public Bank(string name)
            : this(name, null)
        {
        }
        public Bank(string name, List<Account> accounts)
        {
            this.Name = name;
            this.Accounts = accounts;
        }

        private void AddNewAccount(Account newAccount)
        {
            foreach (Account account in this.accounts)
            {
                if (account.Customer.ID == newAccount.Customer.ID)
                {
                    throw new InvalidOperationException("Cannot have two customers with the same ID!");
                }
            }
            this.accounts.Add(newAccount);
        }
        public void AddAccount(Account newAccount)
        {
            AddNewAccount(newAccount);
        }
        public void RemoveAccount(Account account)
        {
            this.accounts.Remove(account);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Bank name: " + this.Name);
            result.AppendLine();
            foreach (Account account in this.Accounts)
            {
                result.AppendLine(account.ToString());
            }
            return result.ToString();
        }
    }
}
