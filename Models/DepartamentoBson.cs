using MongoDB.Bson.Serialization.Attributes;

namespace API_CRUDMONGO.Models
{
    public class DepartamentoBson
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id {  get; set; } = string.Empty;

        [BsonElement("descripcion")] 
        public string descripcion { get; set;} = string.Empty;

    }
}
