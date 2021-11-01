using System.Collections.Generic;
using System.Globalization;
using BenchmarkDotNet.Attributes;

namespace Dgt.BaseConverter.Benchmarks
{
    [MemoryDiagnoser]
    public class ConvertBenchmarks
    {
        public static IEnumerable<string> HexNumbers()
        {
            yield return "0";
            yield return "FF";
            yield return "ABCDEF";
        }

        public static IEnumerable<int> DecimalNumbers()
        {
            yield return 0;
            yield return 10;
            yield return 255;
            yield return 11259375;
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(HexNumbers))]
        public int HexToDecimal_Using_IntParse(string value) => int.Parse(value, NumberStyles.HexNumber);

        [Benchmark]
        [ArgumentsSource(nameof(HexNumbers))]
        public int HexToDecimal_Using_Convert(string value) => Convert.HexToDecimal(value);

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(DecimalNumbers))]
        public string DecimalToHex_Using_FormatString(int value) => value.ToString("X");

        [Benchmark]
        [ArgumentsSource(nameof(DecimalNumbers))]
        public string DecimalToHex_Using_Convert(int value) => Convert.DecimalToHex(value);
    }
}