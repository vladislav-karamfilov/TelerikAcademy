namespace BankSystem.Common
{
    public abstract class Customer
    {
        public uint ID
        {
            get;
            protected set;
        }

        protected Customer(uint id)
        {
            this.ID = id;
        }
    }
}
