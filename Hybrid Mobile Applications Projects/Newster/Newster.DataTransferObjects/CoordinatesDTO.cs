namespace Newster.DataTransferObjects
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CoordinatesDTO
    {
        [DataMember(Name = "longitude")]
        public double? Longitude { get; set; }

        [DataMember(Name = "latitude")]
        public double? Latitude { get; set; }
    }
}
