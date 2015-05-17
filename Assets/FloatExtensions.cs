
public static class FloatExtensions
{
    public static bool IsBetween(this float number, float lowerNumber, float higherNumber)
    {
        return number > lowerNumber && number < higherNumber;
    }
}
