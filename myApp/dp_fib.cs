using System;
namespace DynamicProgramming
{
    public class FibonacciRecursion
    {
        public int fibonacci(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            return fibonacci(n - 1) + fibonacci(n - 2);
        }

        public int fib(int n)
        {
            return fibonacci_dp(n, new int[n]);
        }
        // top-down Dynamic Programming
        public int fibonacci_dp(int n, int[] memo)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;

            if (memo[n] != 0)
                return memo[n];

            memo[n] = fibonacci_dp(n - 1, memo) + fibonacci_dp(n - 2, memo);

            return memo[n];
        }

        // bottom up recursion
        public int fibonacci_bottom_up(int n)
        {
            var memo = new int[n];
            memo[0] = 0;
            memo[1] = 1;

            for (int i = 2; i < n; i++)
                memo[i] = memo[i - 1] + memo[i - 2];

            return memo[n];

        }
    }
}
