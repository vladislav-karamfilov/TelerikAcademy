namespace CarRentalSystem.DataTransferObjects
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CarModel
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "make")]
        public string Make { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "engine")]
        public string Engine { get; set; }

        [DataMember(Name = "power")]
        public int Power { get; set; }

        [DataMember(Name = "year")]
        public int Year { get; set; }

        [DataMember(Name = "renter")]
        public string Renter { get; set; }
    }
}
