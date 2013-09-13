namespace Supermarket.Model.Mongo
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Expense
    {
        [BsonConstructor]
        public Expense(string vendor, decimal value, DateTime month)
        {
            this.Value = value;
            this.Month = month;
            this.Vendor = vendor;
        }

        [BsonId]
        public ObjectId ID { get; set; }

        [BsonRequired]
        public decimal Value { get; set; }

        [BsonRequired]
        public DateTime Month { get; set; }

        [BsonRequired]
        public string Vendor { get; set; }
    }
}
