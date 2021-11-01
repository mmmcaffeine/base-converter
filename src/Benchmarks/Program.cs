using BenchmarkDotNet.Running;
using Dgt.BaseConverter.Benchmarks;

_ = BenchmarkSwitcher.FromAssembly(typeof(AssemblyMarker).Assembly).Run(args);