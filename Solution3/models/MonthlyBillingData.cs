namespace Solution3.models;

public class MonthlyBillingData
{
    public int Year { get; set; }
    public int Month { get; set; } 
    public List<DailyBilling>? DailyBillings { get; set; }
}