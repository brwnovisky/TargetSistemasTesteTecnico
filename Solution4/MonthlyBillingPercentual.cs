using Solution4.entities;

namespace Solution4;

public class MonthlyBillingPercentual
{
    private double _billingMonthlyTotal;
    private double _billingMonthlyResidual;
    private readonly List<StateData> _stateDataList = [];
    
    public void AddStateData(StateData stateData)
    {
        if (_stateDataList.Contains(stateData)) return;
        
        _stateDataList.Add(stateData);

        _billingMonthlyTotal += stateData.GetStateBilling();
    }

    public void RemoveStateData(StateData stateData)
    {
        _stateDataList.Remove(stateData);
        
        _billingMonthlyTotal -= stateData.GetStateBilling();
    }

    public void SetBillingResidual(double residual)
    {
        _billingMonthlyTotal -= _billingMonthlyResidual;
        
        _billingMonthlyResidual = residual;
        
        _billingMonthlyTotal += residual;
        
    }

    public double GetBillingResidual()
    {
        return _billingMonthlyTotal;
    }

    public Dictionary<StateData, double> GetStateBillingPercentual(out double residualPercentual)
    {
        var stateBillingPercentualMap = new Dictionary<StateData, double>();

        foreach (var stateData in _stateDataList)
        {
            var stateBillingPercentual = stateData.GetStateBilling() / _billingMonthlyTotal * 100;
            
            stateBillingPercentualMap.Add(stateData, stateBillingPercentual);
        }
        
        residualPercentual = _billingMonthlyResidual / _billingMonthlyTotal * 100;
        
        return stateBillingPercentualMap;
    }
}
