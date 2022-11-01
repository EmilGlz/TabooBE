using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TabooBE.Models.DBModels
{
    public class WordDBModel
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string MainWord { get; set; }
        public List<string> HelperWords { get; set; }
    }
}
