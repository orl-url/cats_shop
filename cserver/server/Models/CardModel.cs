using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models;

public class Card: IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public string? UserId { get; set; }
    
    // [BsonElement("Name")]
    // public string BookName { get; set; } = null!;

    public int Price { get; set; }

    public CardCharacteristics Characteristics { get; set; } = null!;
    
  

    public int ImageId { get; set; }
}
