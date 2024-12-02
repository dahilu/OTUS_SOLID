public class OddRandomNumberGenerator : RandomNumberGenerator
{
    public override int Generate(int min, int max)
    {
        int result;
        do
        {
            result = base.Generate(min, max);
        } while (result % 2 == 0);

        return result;
    }
}
