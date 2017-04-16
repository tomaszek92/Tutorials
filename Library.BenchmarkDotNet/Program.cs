using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Library.BenchmarkDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<StringBuildVsStringTest>(
                ManualConfig
                    .Create(new ManualConfig())
                    .With(Job.Clr.With(Platform.X64))
                    .With(HtmlExporter.Default)
                    .With(TargetMethodColumn.Method)
                    .With(StatisticColumn.Mean)
                    .With(StatisticColumn.Median)
                    .With(StatisticColumn.Min)
                    .With(StatisticColumn.Max));

            //BenchmarkRunner.Run<StringBuildVsStringTest>(new StringBuildVsStringTestConfig());
        }
    }

    public class StringBuildVsStringTest
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

    public class StringBuildVsStringTestConfig : ManualConfig
    {
        public StringBuildVsStringTestConfig()
        {
            // Jobs
            Add(Job.Clr.With(Platform.X64));

            // Exporters
            Add(CsvExporter.Default);
            Add(HtmlExporter.Default);
            Add(MarkdownExporter.GitHub);
            Add(PlainExporter.Default);
            Add(JsonExporter.Brief);
            Add(JsonExporter.Full);

            // Columns
            Add(TargetMethodColumn.Method);
            Add(StatisticColumn.Mean);
            Add(StatisticColumn.Median);
            Add(StatisticColumn.Min);
            Add(StatisticColumn.Max);
            Add(StatisticColumn.OperationsPerSecond);
        }
    }
}