namespace Lab9Models;

public class CreditAccount : BankAccount, IReportable
{
    public double AnnualFeePercent { get; }
    
    public CreditAccount(
        double annualFeePercent, string owner, double balance)
        : base(owner, balance)
    {
        AnnualFeePercent = annualFeePercent;
    }
    
    
    public override string GetDescription()
    {
        return $"{base.GetDescription()}, annual: {AnnualFeePercent}";
    }
    
    public override double CalculateMetric()
    {
        return this.Balance * this.AnnualFeePercent / 100;
    }

    public string CreateReport()
    {
        return "Report---:  " + this.GetDescription() + $" Calculate metric: {this.CalculateMetric()}";
    }
}