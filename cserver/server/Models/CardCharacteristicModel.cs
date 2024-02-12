using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models;

public class CardCharacteristics
{
    public string Animal { get; set; } = null!;

    public int Age { get; set; }
    
    public string Color { get; set; } = null!;
    
    public bool Thoroughbred { get; set; }
    
    public bool Vaccinated { get; set; } 
    
    public bool HasOffspring { get; set; }
    
    public int OwnersBeforeThat { get; set; }
    
   public bool ExhibitionsParticipant { get; set; }
}