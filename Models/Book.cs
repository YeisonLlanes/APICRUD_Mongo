using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;


namespace API_CRUDMONGO.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        [BsonElement("Name")]
        [Required(ErrorMessage = "* Obligatorio")]
        public string BookName { get; set; } = null;

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; } = null;

        [BsonElement("Author")]
        public string Author { get; set; } = null;

    }
}
