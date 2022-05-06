namespace Server.Services.MathService;

public class MathService : IMathService
{
    public int GetRandomPrime(int min, int max)
    {
        // get random prime number
        var random = new Random();
        int number;
        do
        {
            number = random.Next(min, max);
        } while (!IsPrime(number));

        return number;
    }

    private bool IsPrime(int number)
    {
        if (number == 1)
            return false;

        for (var i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}