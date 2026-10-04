// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

Console.WriteLine("Hello, World!");
BenchmarkRunner.Run<FibBenchmark>();




[MemoryDiagnoser]
public class FibBenchmark
{
    [Params(20)]
    public int N;

    [Benchmark]
    public int Fibonacci()
    {
        return Fibonacci(N);
    }

    [Benchmark]
    public int FibonacciDP()
    {
        return FibonacciDP(N, new Dictionary<int, int>());
    }
    [Benchmark]
    public int FibonacciDPB()
    {
        return Fib(N);
    }
    // Recursive
    private int Fibonacci(int n)
    {
        if (n <= 1) return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    // DP (Memoization)
    private int FibonacciDP(int n, Dictionary<int, int> lookup)
    {
        if (n <= 1) return n;

        if (lookup.ContainsKey(n))
            return lookup[n];

        lookup[n] = FibonacciDP(n - 1, lookup) + FibonacciDP(n - 2, lookup);
        return lookup[n];
    }
    public int Fib(int n)
    {
        if (n <= 1) return n;

        int[] dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
            dp[i] = dp[i - 1] + dp[i - 2];

        return dp[n];
    }
       
}