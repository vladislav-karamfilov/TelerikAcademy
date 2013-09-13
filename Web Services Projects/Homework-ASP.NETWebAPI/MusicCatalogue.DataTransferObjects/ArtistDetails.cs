namespace MusicCatalogue.DataTransferObjects
{
    using System;

    public class ArtistDetails
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
