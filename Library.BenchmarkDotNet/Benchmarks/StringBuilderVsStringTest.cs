using System.Text;
using BenchmarkDotNet.Attributes;

namespace Library.BenchmarkDotNet.Benchmarks
{
    public class StringBuilderVsStringTest
    {
        private readonly int _stringLength = 10000;

        [Benchmark]
        public string GenerateStringByString()
        {
            string result = "";
            for (int i = 0; i < _stringLength; i++)
            {
                result += "A";
            }
            return result;
        }

        [Benchmark]
        public string GenerateStringByStringBuilder()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < _stringLength; i++)
            {
                result.Append("A");
            }
            return result.ToString();
        }
    }
}