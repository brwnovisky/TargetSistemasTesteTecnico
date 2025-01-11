namespace Solution2;

public static class FibonacciChecker
{
    public static bool IsFibonacciNumber(int n)
    {
        var previous = 0;
        var next = 1;

        while (previous <= n)
        {
            if (previous == n) return true;

            int cache = previous;
            previous = next;
            next = cache + next;
        }

        return false;
    }
}
