using System.Text.Json.Serialization;

namespace WebApiLearning.Blazor.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EItemRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Mythic,
}
