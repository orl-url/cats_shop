using System.Runtime.CompilerServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models;

public class User: IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? UserId { get; set; }

    public string? Id { get; } = null;
    
    [BsonElement("Name")]
    public string Name { get; set; }= null!;
    
    public string Password { get; set; }= null!;
    
}

