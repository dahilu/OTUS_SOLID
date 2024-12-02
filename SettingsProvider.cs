public class SettingsProvider : ISettingsProvider
{
    public int MinValue { get; }
    public int MaxValue { get; }
    public int MaxAttempts { get; }

    public SettingsProvider(int minValue, int maxValue, int maxAttempts)
    {
        MinValue = minValue;
        MaxValue = maxValue;
        MaxAttempts = maxAttempts;
    }
}
