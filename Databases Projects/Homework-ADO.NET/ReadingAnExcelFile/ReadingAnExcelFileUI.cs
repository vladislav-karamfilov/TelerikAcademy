using System;
using System.Data;
using System.Data.OleDb;

namespace ReadingAnExcelFile
{
    class ReadingAnExcelFileUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Reading an Excel file and displaying its content***");
            Console.Write(decorationLine);

            OleDbConnection dbConnection = new OleDbConnection(Settings.Default.ExcelConnectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                OleDbCommand getTableContentCommand = 
                    new OleDbCommand("SELECT * FROM [Sheet1$]", dbConnection);

                OleDbDataReader excelContent = getTableContentCommand.ExecuteReader();
                using (excelContent)
                {
                    while (excelContent.Read())
                    {
                        Console.WriteLine("{0} -> {1} points", 
                            excelContent["Name"], excelContent["Score"]);
                    }
                }
            }
        }
    }
}