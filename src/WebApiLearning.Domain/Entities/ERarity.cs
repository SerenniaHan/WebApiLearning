using System.Text.Json.Serialization;

namespace WebApiLearning.Domain.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ERarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Mythic,
}
