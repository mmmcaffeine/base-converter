using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Dgt.BaseConverter.Benchmarks
{
    // Benchmarks in this type need to essentially reverse the string when converting from base 10 to some other base
    // because we are finding the digits or characters in the reverse order i.e. finding them right to left, not left
    // to right
    [MemoryDiagnoser]
    public class CharacterManagementBenchmarks
    {
        public static IEnumerable<char[]> Characters()
        {
            yield return new [] { 'A' };
            yield return new [] { 'S', 'h', 'o', 'r', 't' };
            yield return new [] { 'A', 'b', 'i', 't', 'o', 'f', 'a', 'l', 'o', 'n', 'g', 'e', 'r', 's', 't', 'r', 'i', 'n', 'g' };
            yield return Enumerable.Range(0, 500).Select(_ => 'A').ToArray();
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Characters))]
        public string String_Using_Stack(char[] characters)
        {
            var stack = new Stack<char>();
            
            for (var i = 0; i < characters.Length; i++)
            {
                stack.Push(characters[i]);
            }

            return new string(stack.ToArray());
        }

        [Benchmark]
        [ArgumentsSource(nameof(Characters))]
        public string String_Using_InsertIntoList(char[] characters)
        {
            var list = new List<char>();

            for (var i = 0; i < characters.Length; i++)
            {
                list.Insert(0, characters[i]);
            }

            return new string(list.ToArray());
        }

        [Benchmark]
        [ArgumentsSource(nameof(Characters))]
        public string String_Using_ReversedList(char[] characters)
        {
            var list = new List<char>();

            for (var i = 0; i < characters.Length; i++)
            {
                list.Add(characters[i]);
            }
            
            list.Reverse();

            return new string(list.ToArray());
        }

        [Benchmark]
        [ArgumentsSource(nameof(Characters))]
        public string String_Using_InsertIntoStringBuilder(char[] characters)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < characters.Length; i++)
            {
                builder.Insert(0, characters[i]);
            }

            return builder.ToString();
        }

        [Benchmark]
        [ArgumentsSource(nameof(Characters))]
        public string String_Using_StringCreate(char[] characters)
        {
            return string.Create(characters.Length, characters, (span, state) =>
            {
                for (int i = 0, j = characters.Length - 1; i < characters.Length; i++, j--)
                {
                    span[j] = state[i];
                }
            });
        }
    }
}