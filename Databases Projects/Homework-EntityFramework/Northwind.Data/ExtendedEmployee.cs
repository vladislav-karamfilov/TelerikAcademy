namespace Northwind.Data
{
    using System.Data.Linq;
    using System.Linq;

    public partial class Employee
    {
        private EntitySet<Territory> entityTerritories;

        public EntitySet<Territory> EntityTerritories
        {
            get
            {
                var employeeTerritories = this.Territories;
                EntitySet<Territory> entityTerritories = new EntitySet<Territory>();
                entityTerritories.AddRange(employeeTerritories);
                return entityTerritories;
            }
        }
    }
}
