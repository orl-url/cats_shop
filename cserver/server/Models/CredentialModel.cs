using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models;

public class Credential
{
  [Required]
  public string Name { get; set; } = string.Empty;

  [Required]
  public string Password { get; set; } = string.Empty;
}