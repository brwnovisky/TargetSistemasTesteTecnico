using Solution3;

MonthlyBillingAnalysis jsonDataAnalysis;
MonthlyBillingAnalysis xmlDataAnalysis;

try
{
    jsonDataAnalysis = new MonthlyBillingAnalysis(args.ElementAt(0));
    xmlDataAnalysis = new MonthlyBillingAnalysis(args.ElementAt(1));
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex.Message);
    return;
}

var jsonLowestDailyValueData = jsonDataAnalysis.LowestDailyValueData();
var jsonHighestDailyValueData = jsonDataAnalysis.HighestDailyValueData();
var jsonDaysGreaterThanAverage = jsonDataAnalysis.DaysGreaterThanAverage();

var xmlLowestDailyValueData = xmlDataAnalysis.LowestDailyValueData();
var xmlHighestDailyValueData = xmlDataAnalysis.HighestDailyValueData();
var xmlDaysGreaterThanAverage = xmlDataAnalysis.DaysGreaterThanAverage();

Console.WriteLine("* On dados.json *");
Console.WriteLine($"The lowest monthly billing value is R${jsonLowestDailyValueData.Value} on day {jsonLowestDailyValueData.Day}.");
Console.WriteLine($"The highest monthly billing value is R${jsonHighestDailyValueData.Value} on day {jsonHighestDailyValueData.Day}.");
Console.WriteLine($"The number of days whose value are above the average is {jsonDaysGreaterThanAverage}.");
Console.WriteLine();

Console.WriteLine("* On dados2.xml *");
Console.WriteLine($"The lowest monthly billing value is R${xmlLowestDailyValueData.Value} on day {xmlLowestDailyValueData.Day}.");
Console.WriteLine($"The highest monthly billing value is R${xmlHighestDailyValueData.Value} on day {xmlHighestDailyValueData.Day}.");
Console.WriteLine($"The number of days whose value are above the average is {xmlDaysGreaterThanAverage}.");
