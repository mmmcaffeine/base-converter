using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Dgt.BaseConverter.Benchmarks
{
    [MemoryDiagnoser]
    public class CalculatorBenchmarks
    {
        public static IEnumerable<object[]> DividendsAndDivisors()
        {
            yield return new object[] { 12, 4 };
            yield return new object[] { 36, 5 };
            yield return new object[] { 1211, 11 };
            yield return new object[] { int.MaxValue, 2 };
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(DividendsAndDivisors))]
        public (int Quotient, int Remainder) Divide_Using_MathDivRem(int dividend, int divisor)
        {
            var quotient = Math.DivRem(dividend, divisor, out var remainder);

            return (quotient, remainder);
        }

        [Benchmark]
        [ArgumentsSource(nameof(DividendsAndDivisors))]
        public (int Quotient, int Remainder) Divide_Using_CalculatorDivide(int dividend, int divisor) =>
            Calculator.Divide(dividend, divisor);

        // This is clearly not a robust implementation, and only exists for us to get an idea about whether the
        // performance of this is worth pursuing
        [Benchmark]
        [ArgumentsSource(nameof(DividendsAndDivisors))]
        public (int Quotient, int Remainder) Divide_Using_BitShifting(int dividend, int divisor)
        {
            var unsignedDividend = (uint)dividend;
            var unsignedDivisor = (uint)divisor;

            long answer = 0;
            for (var i = 28; i >= 0; i--)
            {
                if (unsignedDivisor << i <= unsignedDividend)
                {
                    unsignedDividend -= unsignedDivisor << i;
                    answer += 1 << i;
                }
            }

            return ((int)answer, (int)(dividend - answer));
        }
    }
}