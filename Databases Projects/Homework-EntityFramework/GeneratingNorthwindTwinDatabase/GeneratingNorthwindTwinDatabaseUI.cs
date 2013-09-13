namespace GeneratingNorthwindTwinDatabase
{
    using System;
    using System.Data.SqlClient;
    using System.Data.Entity.Infrastructure;
    using Northwind.Data;

    class GeneratingNorthwindTwinDatabaseUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Generating 'NorthwindTwin' database using the Northwind database context***");
            Console.Write(decorationLine);

            string createNorthwindCloneDBCommand = @"CREATE DATABASE NorthwindTwin ON PRIMARY 
(NAME = NorthwindTwin, FILENAME = 'D:\NorthwindTwin.mdf', SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) 
LOG ON (NAME = NorthwindTwinLog, FILENAME = 'D:\NorthwindTwin.ldf', SIZE = 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)";
            SqlConnection dbConnectionForCreatingDB = 
                new SqlConnection(Settings.Default.ConnectionStringForCreatingTwinDB);
            dbConnectionForCreatingDB.Open();
            using (dbConnectionForCreatingDB)
            {
                SqlCommand createDBCommand =
                    new SqlCommand(createNorthwindCloneDBCommand, dbConnectionForCreatingDB);
                createDBCommand.ExecuteNonQuery();
            }

            IObjectContextAdapter northwindContext = new NorthwindEntities();
            string cloneNorthwindScript = northwindContext.ObjectContext.CreateDatabaseScript();
            SqlConnection dbConnectionForCloningDB = new SqlConnection(Settings.Default.ConnectionStringForCloningDB);
            dbConnectionForCloningDB.Open();
            using (dbConnectionForCloningDB)
            {
                SqlCommand cloneDBCommand = new SqlCommand(cloneNorthwindScript, dbConnectionForCloningDB);
                cloneDBCommand.ExecuteNonQuery();
            }
        }
    }
}
