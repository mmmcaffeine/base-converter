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
    }
}