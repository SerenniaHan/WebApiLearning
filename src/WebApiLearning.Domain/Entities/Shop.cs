using MongoDB.Bson.Serialization.Attributes;

namespace WebApiLearning.Domain.Entities;

public record Shop(string Name, string Location) : IHasGuid
{
    [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = Name;

    public string Location { get; set; } = Location;
}
