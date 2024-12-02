
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace OTUS_SOLID2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();


            int minValue = int.Parse(configuration["GameSettings:MinValue"]);   
            int maxValue = int.Parse(configuration["GameSettings:MaxValue"]); 
            int maxAttempts = int.Parse(configuration["GameSettings:MaxAttempts"]);

            ISettingsProvider settingsProvider = new SettingsProvider(minValue, maxValue, maxAttempts);

            IRandomNumberGenerator randomNumberGenerator;

            Console.WriteLine("Выберите тип генератора: 1 - Четные числа, 2 - Нечетные числа");

            int choice = -1;

            while (!int.TryParse(Console.ReadLine(),out choice))
            {
                Console.WriteLine("Выберите тип генератора: 1 - Четные числа, 2 - Нечетные числа");
            }

            if (choice == 1)
            {
                randomNumberGenerator = new EvenRandomNumberGenerator();
                Console.WriteLine("Угадайте четное число:");
            }
            else
            {
                randomNumberGenerator = new OddRandomNumberGenerator();
                Console.WriteLine("Угадайте нечетное число:");
            }

            var game = new GuessingGame(randomNumberGenerator, settingsProvider);

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
}

//class Program
//{
//    static void Main(string[] args)
//    {
//        var configuration = new ConfigurationBuilder()
//            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//            .Build();

//        int minValue = configuration.GetValue<int>("GameSettings:MinValue");
//        int maxValue = configuration.GetValue<int>("GameSettings:MaxValue");
//        int maxAttempts = configuration.GetValue<int>("GameSettings:MaxAttempts");

//        ISettingsProvider settingsProvider = new SettingsProvider(minValue, maxValue, maxAttempts);

//        IRandomNumberGenerator randomNumberGenerator;
//        Console.WriteLine("Выберите тип генератора: 1 - Четные числа, 2 - Нечетные числа");
//        int choice = int.Parse(Console.ReadLine());
//        if (choice == 1)
//        {
//            randomNumberGenerator = new EvenRandomNumberGenerator();
//            Console.WriteLine("Угадайте четное число:");
//        }
//        else
//        {
//            randomNumberGenerator = new OddRandomNumberGenerator();
//            Console.WriteLine("Угадайте нечетное число:");
//        }

//        var game = new GuessingGame(randomNumberGenerator, settingsProvider);

//        while (game.CanAttempt)
//        {
//            int guess = int.Parse(Console.ReadLine());
//            string result = game.MakeGuess(guess);
//            Console.WriteLine(result);
//            if (result == "Правильно")
//            {
//                break;
//            }
//        }

//        if (!game.CanAttempt)
//        {
//            Console.WriteLine("Вы исчерпали все попытки.");
//        }
//    }
//}

