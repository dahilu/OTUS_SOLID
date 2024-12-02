public class GuessingGame
{
    private readonly IRandomNumberGenerator _randomNumberGenerator;
    private readonly ISettingsProvider _settingsProvider;
    private readonly int _targetNumber;
    private int _attempts;

    public GuessingGame(IRandomNumberGenerator randomNumberGenerator, ISettingsProvider settingsProvider)
    {
        _randomNumberGenerator = randomNumberGenerator;
        _settingsProvider = settingsProvider;
        _targetNumber = _randomNumberGenerator.Generate(_settingsProvider.MinValue, _settingsProvider.MaxValue);
        _attempts = 0;
    }

    public string MakeGuess(int guess)
    {
        _attempts++;
        if (guess < _targetNumber)
        {
            return "Больше";
        }
        if (guess > _targetNumber)
        {
            return "Меньше";
        }
        return "Правильно";
    }

    public bool CanAttempt => _attempts < _settingsProvider.MaxAttempts;
}
