using System.Text.Json.Serialization;
namespace ecom.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PizzaSize
    {
        Small = 1,
        Medium = 2,
        Large = 3,
    }
}