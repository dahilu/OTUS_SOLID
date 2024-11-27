// Интерфейс генератора случайных чисел
public interface IRandomNumberGenerator
{
    int Generate(int min, int max);
}

// Реализация генератора случайных чисел
public class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly Random _random = new Random();

    public int Generate(int min, int max)
    {
        return _random.Next(min, max);
    }
}

// Интерфейс чтения и записи настроек
public interface ISettingsProvider
{
    int MinValue { get; }
    int MaxValue { get; }
    int MaxAttempts { get; }
}

// Реализация чтения и записи настроек
public class SettingsProvider : ISettingsProvider
{
    public int MinValue { get; } = 1;
    public int MaxValue { get; } = 100;
    public int MaxAttempts { get; } = 10;
}

// Класс, содержащий логику игры
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

// Главный класс программы
public class Program
{
    public static void Main(string[] args)
    {
        IRandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
        ISettingsProvider settingsProvider = new SettingsProvider();
        var game = new GuessingGame(randomNumberGenerator, settingsProvider);

        Console.WriteLine("Угадайте число:");
        while (game.CanAttempt)
        {
            int guess = int.Parse(Console.ReadLine());
            string result = game.MakeGuess(guess);
            Console.WriteLine(result);
            if (result == "Правильно")
            {
                break;
            }
        }

        if (!game.CanAttempt)
        {
            Console.WriteLine("Вы исчерпали все попытки.");
        }
    }
}
