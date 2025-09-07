namespace WebApiLearning.Domain.Entities;

public record Shop(string Name, string Location) : IHasGuid
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = Name;
    public string Location { get; set; } = Location;
}
