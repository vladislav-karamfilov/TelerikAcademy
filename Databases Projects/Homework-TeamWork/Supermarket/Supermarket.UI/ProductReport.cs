namespace Supermarket.UI
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    internal class ProductReport
    {
        [BsonConstructor]
        public ProductReport()
        {            
        }

        [BsonId]
        public ObjectId ID { get; set; }

        [BsonRequired, BsonElement("product-id")]
        public int ProductID { get; set; }

        [BsonRequired, BsonElement("product-name")]
        public string ProductName { get; set; }
       
        [BsonRequired, BsonElement("vendor-name")]
        public string VendorName { get; set; }

        [BsonRequired, BsonElement("total-quantity-sold")]
        public int TotalQuantitySold { get; set; }

        [BsonRequired, BsonElement("total-incomes")] 
        public decimal TotalIncomes { get; set; }
    }
}
