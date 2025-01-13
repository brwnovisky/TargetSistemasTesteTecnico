using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Solution3.models;

public class DailyBilling
{
    [JsonProperty("dia")]
    [XmlElement("dia")]
    public int Day { get; set; }
    [JsonProperty("valor")]
    [XmlElement("valor")]
    public double? Value { get; set; }
}