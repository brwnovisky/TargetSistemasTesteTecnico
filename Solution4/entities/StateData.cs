namespace Solution4.entities;

public class StateData(string stateId, double stateBilling)
{
    private string _stateId = stateId;
    private double _stateBilling = stateBilling;

    public string GetStateId()
    {
        return _stateId;
    }

    public double GetStateBilling()
    {
        return _stateBilling;
    }
}