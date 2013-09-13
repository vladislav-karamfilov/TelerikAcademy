using System;
using System.Data.OleDb;

namespace AppendingNewRowToExcelFile
{
    class AppendingNewRowToExcelFileUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Appending a new row to the 'TrainersPoints' Excel file***");
            Console.Write(decorationLine);

            OleDbConnection excelConnection = new OleDbConnection(Settings.Default.ExcelConnectionString);
            excelConnection.Open();
            using (excelConnection)
            {
                OleDbCommand insertNewRowCommand = new OleDbCommand(
                    @"INSERT INTO [Sheet1$] (Name, Score) 
                        VALUES (@name, @score)", excelConnection);
                insertNewRowCommand.Parameters.AddWithValue("@name", "Pesho Peshov");
                insertNewRowCommand.Parameters.AddWithValue("@score", 18);
                insertNewRowCommand.ExecuteNonQuery();
            }

            Console.WriteLine("The new entry successfully appended!");
        }
    }
}
