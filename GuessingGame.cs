
public class GuessingGame
{
    private readonly IRandomNumberGenerator _randomNumberGenerator;
    private readonly ISettingsProvider _settingsProvider;
    private readonly IMessageWriter _messageWriter;
    private readonly int _targetNumber;
    private int _attempts;

    public GuessingGame(IRandomNumberGenerator randomNumberGenerator, ISettingsProvider settingsProvider, IMessageWriter messageWriter)
    {
        _randomNumberGenerator = randomNumberGenerator;
        _settingsProvider = settingsProvider;
        _messageWriter = messageWriter;
        _targetNumber = _randomNumberGenerator.Generate(_settingsProvider.MinValue, _settingsProvider.MaxValue);
        _attempts = 0;
    }

    public string MakeGuess(int guess)
    {
        _attempts++;
        if (guess < _targetNumber)
        {
            _messageWriter.Write("Больше");
            return "Больше";
        }
        if (guess > _targetNumber)
        {
            _messageWriter.Write("Меньше");
            return "Меньше";
        }
        _messageWriter.Write("Правильно");
        return "Правильно";
    }

    public bool CanAttempt => _attempts < _settingsProvider.MaxAttempts;
}

