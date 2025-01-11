using Solution3;

MonthlyBillingAnalysis monthAnalysis;

try
{
    var jsonRawData = File.ReadAllText(args.ElementAt(0));
    monthAnalysis = new MonthlyBillingAnalysis(jsonRawData);
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex.Message);
    return;
}

var currentDataYear = monthAnalysis.GetYearDate();
var currentDataMonth = monthAnalysis.GetMonthDate();
var lowestDailyValueData = monthAnalysis.LowestDailyValueData();
var highestDailyValueData = monthAnalysis.HighestDailyValueData();
var daysGreaterThanAverage = monthAnalysis.DaysGreaterThanAverage();

var monthZero = currentDataMonth < 10 ? "0" : "";
var dayZero = lowestDailyValueData.Day < 10 ? "0" : "";
var dateString = $"{currentDataYear}-{monthZero}{currentDataMonth}-{dayZero}{lowestDailyValueData.Day}";

Console.WriteLine($"The lowest monthly billing value is R${lowestDailyValueData.Value} in {dateString}.");

dayZero = highestDailyValueData.Day < 10 ? "0" : "";
dateString = $"{currentDataYear}-{monthZero}{currentDataMonth}-{dayZero}{highestDailyValueData.Day}";

Console.WriteLine($"The highest monthly billing value is R${highestDailyValueData.Value} in {dateString}.");

dateString = $"{currentDataYear}/{monthZero}{currentDataMonth}";

Console.WriteLine($"The number of days whose value are above the average is {daysGreaterThanAverage} in {dateString}.");