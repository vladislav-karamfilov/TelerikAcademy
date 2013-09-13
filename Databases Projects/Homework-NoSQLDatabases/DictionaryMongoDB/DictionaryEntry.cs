namespace DictionaryMongoDB
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    
    public class DictionaryEntry
    {
        [BsonConstructor]
        public DictionaryEntry(string word, string translation)
        {
            this.Word = word;
            this.Translation = translation;
        }

        [BsonId]
        public ObjectId ID { get; private set; }

        [BsonRequired]
        public string Word { get; private set; }

        [BsonRequired]
        public string Translation { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} -> {1}", this.Word, this.Translation);
        }
    }
}
