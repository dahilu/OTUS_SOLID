public interface ISettingsProvider
{
    int MinValue { get; }
    int MaxValue { get; }
    int MaxAttempts { get; }
}
