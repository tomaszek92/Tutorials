using BenchmarkDotNet.Running;
using Library.BenchmarkDotNet.Benchmarks;

namespace Library.BenchmarkDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var benchmarkSwitcher = new BenchmarkSwitcher(new[]
            {
                typeof(Md5VsSha256Test),
                typeof(StringBuilderVsStringTest)
            });
            benchmarkSwitcher.RunAll();

            //BenchmarkRunner.Run<Md5VsSha256Test>();
            //BenchmarkRunner.Run<StringBuilderVsStringTest>();

            //BenchmarkRunner.Run<StringBuildVsStringTest>(
            //    ManualConfig
            //        .Create(new ManualConfig())
            //        .With(Job.Clr.With(Platform.X64))
            //        .With(HtmlExporter.Default)
            //        .With(TargetMethodColumn.Method)
            //        .With(StatisticColumn.Mean)
            //        .With(StatisticColumn.Median)
            //        .With(StatisticColumn.Min)
            //        .With(StatisticColumn.Max));

            //BenchmarkRunner.Run<StringBuildVsStringTest>(new StringBuildVsStringTestConfig());
        }
    }
}