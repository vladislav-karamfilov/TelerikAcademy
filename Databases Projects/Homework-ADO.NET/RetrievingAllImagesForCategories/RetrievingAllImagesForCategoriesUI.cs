using System;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace RetrievingAllImagesForCategories
{
    class RetrievingAllImagesForCategoriesUI
    {
        const string CategoriesImagesDestinationFolder = @"..\..\Categories Images\";
        const int HeaderLength = 78;

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Retrieving the images of all categories in the");
            Console.WriteLine("'Northwind' database as JPG files***");
            Console.Write(decorationLine);

            SqlConnection dbConnection =
                new SqlConnection(Settings.Default.DBConnectionString);
            
            GetAllCategoriesImages(dbConnection);
            Console.WriteLine("Images retrieved successfully! You can see them in folder '{0}'",
                "Categories Images");
        }

        static void GetAllCategoriesImages(SqlConnection databaseConnection)
        {
            databaseConnection.Open();
            using (databaseConnection)
            {
                SqlCommand getCategoriesImagesCommand =
                    new SqlCommand("SELECT CategoryName, Picture FROM Categories", databaseConnection);
                SqlDataReader dbInfo = getCategoriesImagesCommand.ExecuteReader();
                while (dbInfo.Read())
                {
                    byte[] rawData = dbInfo["Picture"] as byte[];
                    string fileNameAndDestination = string.Format(
                        "{0}{1}.jpg",
                        CategoriesImagesDestinationFolder,
                        ((string)(dbInfo["CategoryName"])).Replace('/', '_'));
                    int length = rawData.Length;
                    byte[] imageData = new byte[length - HeaderLength];
                    Array.Copy(rawData, HeaderLength, imageData, 0, imageData.Length);

                    MemoryStream memoryStream = new MemoryStream(imageData);
                    Image image = Image.FromStream(memoryStream);
                    image.Save(new FileStream(fileNameAndDestination, FileMode.Create), ImageFormat.Jpeg);
                }
            }
        }
    }
}
