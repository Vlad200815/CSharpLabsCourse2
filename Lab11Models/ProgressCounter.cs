namespace Lab11Models;

public class ProgressCounter
{
    public event ValueHandler? ThresholdReached;
    
    
    public void CountTo(int last, int threshold)
    {
        for (int current = 1; current <= last; current++)
        {
            if (current == threshold)
            {
                ThresholdReached?.Invoke(current);
            }
        }
    }
}