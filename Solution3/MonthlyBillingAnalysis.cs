using System.Diagnostics;
using Newtonsoft.Json;
using Solution3.models;

namespace Solution3;

public class MonthlyBillingAnalysis
{
    private readonly MonthlyBillingData _monthlyBillingData;
    private readonly int _daysGreaterThanAverage;
    private readonly DailyBilling _lowestBillingDailyValue;
    private readonly DailyBilling _highestDailyBillingValue;
    
    public MonthlyBillingAnalysis(string jsonRawData)
    {
        _monthlyBillingData = JsonConvert.DeserializeObject<MonthlyBillingData>(jsonRawData);
        
        if (_monthlyBillingData?.DailyBillings == null || _monthlyBillingData.DailyBillings.Count == 0)
        {
            throw new ArgumentException("Json data invalid.");
        }
        
        var validBillingDays = _monthlyBillingData.DailyBillings.Where(b => b.Value is > 0).ToList();
        
        _lowestBillingDailyValue = validBillingDays.OrderBy(d => d.Value).First();
        _highestDailyBillingValue = validBillingDays.OrderByDescending(d => d.Value).First();
        
        var averageDailyBillingValue = validBillingDays.Average(d => d.Value);
        
        _daysGreaterThanAverage = validBillingDays.Count(d => d.Value > averageDailyBillingValue);
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

    public int GetMonthDate()
    {
        return _monthlyBillingData.Month;
    }

    public int GetYearDate()
    {
        return _monthlyBillingData.Year;
    }
}
