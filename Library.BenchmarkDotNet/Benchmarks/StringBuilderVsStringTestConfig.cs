using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Jobs;

namespace Library.BenchmarkDotNet.Benchmarks
{
    public class StringBuilderVsStringTestConfig : ManualConfig
    {
        public StringBuilderVsStringTestConfig()
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