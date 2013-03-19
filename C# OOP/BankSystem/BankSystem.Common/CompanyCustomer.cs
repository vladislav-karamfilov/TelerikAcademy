namespace BankSystem.Common
{
    public class CompanyCustomer : Customer
    {
        public string Name
        {
            get;
            private set;
        }

        public CompanyCustomer(string name, uint id)
            : base(id)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return string.Format("Company name: {0}\nID: {1}", this.Name, this.ID);
        }
    }
}
