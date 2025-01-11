using Solution4;
using Solution4.entities;

const double billingResidual = 19849.53;
var saoPaulo = new StateData("SP", 67836.43);
var rioDeJaneiro = new StateData("RJ", 36678.66);
var minasGerais = new StateData("MG", 29229.88);
var espiritoSanto = new StateData("ES", 27165.48);
var monthlyBillingPercentual = new MonthlyBillingPercentual();

monthlyBillingPercentual.AddStateData(saoPaulo);
monthlyBillingPercentual.AddStateData(rioDeJaneiro);
monthlyBillingPercentual.AddStateData(minasGerais);
monthlyBillingPercentual.AddStateData(espiritoSanto);
monthlyBillingPercentual.SetBillingResidual(billingResidual);

var percentages = monthlyBillingPercentual.GetStateBillingPercentual(out var residualPercentual);

Console.WriteLine("The monthly Billing Percentual list by state:");

foreach (var stateDataPercentage in percentages)
{
    Console.WriteLine($"{stateDataPercentage.Key.GetStateId()}: {stateDataPercentage.Value:F2} %");
}

Console.WriteLine($"Other States: {residualPercentual:F2} %");
