namespace TelerikAcademy.Client
{
    using TelerikAcademy.Data;
    using Telerik.OpenAccess;

    /// <summary>
    /// 3. Compare Bulk Delete with normal delete operation
    /// Insert 100 000 entities in single table. Delete each row that has ID where ID mod 7 == 1
    /// Once delete the entities using OpenAccessContext.Remove() method. 
    /// Then delete the entities using DeleteAll() bulk operation. 
    /// Both times track the SQL statements that are sent to the server.
    /// Both times measure the time required to complete the operation(s). 
    /// For bonus points measure the memory consumption in addition to the time. 
    /// Output the measurements in text file including timestamp and machine name
    /// </summary>
    /// 
    public class DeleteComparer
    {
        public void Insert100000EntitiesInDB()
        {
            using (var context = new TelerikAcademyModels())
            {
                ulong id = 1;
                int counter = 0;
                while (counter < 100000)
                {
                    id += 7;
                    var row = new OpenAccessDemoEntity()
                    {
                        Name = id + "Demo"
                    };

                    context.Add(row);

                    counter += 1;
                    context.SaveChanges();
                }
            }
        }

        public void BulkDelete()
        {
            using (var context = new TelerikAcademyModels())
            {
                context.OpenAccessDemoEntities.DeleteAll();
            }
        }

        public void NormalDelete()
        {
            using (var context = new TelerikAcademyModels())
            {
                foreach (var item in context.OpenAccessDemoEntities)
                {
                    context.Delete(item);
                }

                context.SaveChanges();
            }
        }
    }
}
