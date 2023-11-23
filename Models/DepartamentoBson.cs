using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace API_CRUDMONGO.Models
{
    public class DepartamentoBson
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id {  get; set; } = string.Empty;

        [BsonElement("descripcion")]
        [Required(ErrorMessage = "* Obligatorio")]
        public string descripcion { get; set;} = string.Empty;

    }
}
