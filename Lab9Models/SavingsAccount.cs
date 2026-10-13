namespace Lab9Models;

public class SavingsAccount : BankAccount, IReportable
{
    public double AnnualRatePercent { get; }
    
    public SavingsAccount(
        double annualRatePercent, string owner, double balance)
        : base(owner, balance)
    {
        AnnualRatePercent = annualRatePercent;
    }
    
    
    public override string GetDescription()
    {
        return $"{base.GetDescription()}, annual: {AnnualRatePercent}";
    }
    
    
    public override double CalculateMetric()
    {
        return Balance * AnnualRatePercent / 100;
    }
    
    public string CreateReport()
    {
        return "Report---:  " +  this.GetDescription() + $" Calculate metric: {this.CalculateMetric()}";
    }
    
    
}