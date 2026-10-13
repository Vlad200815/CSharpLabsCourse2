namespace Lab9Models;

public abstract class BankAccount : ICalculable
{
    public string Owner { get; }
    public double Balance { get; }
    
    protected BankAccount(
        string owner,
        double balance)
    {
        Owner = owner;
        Balance = balance;
    }
    
    
    public virtual string GetDescription()
    {
        return $"Description: owner: {Owner}, balance: {Balance}";
    }
    public abstract double CalculateMetric();
}