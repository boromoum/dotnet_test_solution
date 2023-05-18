using System.Text.Json.Serialization;

namespace CMG.TestSolution.Api.Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum RpgEnum
  {
    Knight = 1,
    Mage = 2,
    Cleric = 3

  }
}