namespace TelerikAcademy.Client
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using TelerikAcademy.Data;

    /// <summary>
    /// 2. Implement entity cloning using binary serialization
    /// Define a function that can clone single entity loaded from the database 
    /// (for more fame – a graph of entities, starting with from one of the nodes). 
    /// Test that all properties of the original instance have the same values as 
    /// the ones on the cloned.
    /// </summary>
    public class Serializator
    {
        public void SerializeDeserialize(string unit)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream stream = SerializeToBinaryStream(unit);//makes string as byte[] 
            stream.Seek(0, SeekOrigin.Begin);

            Employee employee = formatter.Deserialize(stream) as Employee;

            Console.WriteLine("Name: {0}", employee.FirstName);
        }

        public MemoryStream SerializeToBinaryStream(string employeeFName)//memory stream 
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();
            using (TelerikAcademyModels dbContext = new TelerikAcademyModels())
            {
                Employee customer = dbContext.Employees.Where(e => e.FirstName == employeeFName).First();

                var sentQueryToServer = customer.FirstName;

                formatter.Serialize(stream, customer);
            }

            return stream;
        }
    }
}
