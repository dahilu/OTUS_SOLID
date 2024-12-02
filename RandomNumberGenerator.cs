
using System;

public class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly Random _random = new Random();

    public virtual int Generate(int min, int max)
    {
        return _random.Next(min, max);
    }
}
