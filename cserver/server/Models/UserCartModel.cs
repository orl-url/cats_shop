using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using server.Models;

namespace server.Models;

public class UserCart: IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public string UserId { get; set; } = null!;

    public List<string> Content { get; set; } = [];

}