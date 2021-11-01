using System.Text;
using BenchmarkDotNet.Attributes;

namespace Dgt.BaseConverter.Benchmarks
{
    [MemoryDiagnoser]
    public class FromHexString
    {
        [Benchmark(Baseline = true)]
#pragma warning disable CA1822
        public string FromHexString_Using_SystemConvertAndEncoding()
#pragma warning restore CA1822
        {
            var bytes = System.Convert.FromHexString("2A");
            return Encoding.ASCII.GetString(bytes);
        }
    }
}