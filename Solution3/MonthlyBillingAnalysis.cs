using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Solution3.models;

namespace Solution3;

public partial class MonthlyBillingAnalysis
{
    [XmlRoot("root")]
    public class Root
    {
        [XmlElement("row")]
        public List<DailyBilling> DailyBillings { get; set; }
    }
    
    private readonly int _daysGreaterThanAverage;
    private readonly DailyBilling _lowestBillingDailyValue;
    private readonly DailyBilling _highestDailyBillingValue;
    private List<DailyBilling>? _dailyBillings;
    
    public MonthlyBillingAnalysis(string dataFilePath)
    {   
        FileProcess(dataFilePath);
        
        var validBillingDays = _dailyBillings.Where(b => b.Value is > 0).ToList();
        
        _lowestBillingDailyValue = validBillingDays.OrderBy(d => d.Value).First();
        _highestDailyBillingValue = validBillingDays.OrderByDescending(d => d.Value).First();
        
        var averageDailyBillingValue = validBillingDays.Average(d => d.Value);
        
        _daysGreaterThanAverage = validBillingDays.Count(d => d.Value > averageDailyBillingValue);
    }

    private void FileProcess(string dataFilePath)
    {
        if (string.IsNullOrEmpty(dataFilePath)) throw new ArgumentException("Empty or invalid data file path.");

        if (!File.Exists(dataFilePath)) throw new ArgumentException("Data file not found.");
        
        var rawData = File.ReadAllText(dataFilePath);
        
        var dataFileExtension = Path.GetExtension(dataFilePath).ToLower();

        switch (dataFileExtension)
        {
            case ".json":
                _dailyBillings = JsonConvert.DeserializeObject<List<DailyBilling>>(rawData);
                break;
            
            case ".xml":
                var serializer = new XmlSerializer(typeof(Root));
                using (var reader = new StringReader(rawData))
                {
                    var root = (Root)serializer.Deserialize(reader)!;
                    _dailyBillings = root.DailyBillings;
                }
                break;
            
            default:
                throw new ArgumentException("Invalid data file format.");
        }
    }

    public DailyBilling LowestDailyValueData()
    {
        return _lowestBillingDailyValue;
    }

    public DailyBilling HighestDailyValueData()
    {
        return _highestDailyBillingValue;
    }

    public int DaysGreaterThanAverage()
    {
        return _daysGreaterThanAverage;
    }
}
