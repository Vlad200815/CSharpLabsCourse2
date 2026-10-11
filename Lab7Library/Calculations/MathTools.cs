namespace Lab7Library.Calculations;



public static class MathTools
{
    public static double CalculateCylinderVolume(
        double radius,
        double height)
    {
        if (radius <= 0 || height <= 0)
        {
            return double.NaN;
        }
        
        return Math.PI * radius * radius * height;
    }
}