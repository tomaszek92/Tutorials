using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVsList
{
    enum Type
    {
        ArrayFor,
        ArrayForeach,
        ListFor,
        ListForeach
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Type, List<long>> results = new Dictionary<Type, List<long>>
            {
                {Type.ArrayFor, new List<long>()},
                {Type.ArrayForeach, new List<long>()},
                {Type.ListFor, new List<long>()},
                {Type.ListForeach, new List<long>()}
            };

            for (int j = 0; j < 10000; j++)
            {
                int sum = 0;
                const int size = 100;
                int[] arrayvals = new int[size];
                for (int i = 0; i < size; i++)
                {
                    arrayvals[i] = 1;
                }
                List<int> listvals = arrayvals.ToList();

                Stopwatch stopwatch = Stopwatch.StartNew();
                foreach (var val in arrayvals)
                {
                    sum += val;
                }
                stopwatch.Stop();
                results[Type.ArrayForeach].Add(stopwatch.ElapsedMilliseconds);

                sum = 0;
                stopwatch.Restart();
                foreach (var val in listvals)
                {
                    sum += val;
                }
                stopwatch.Stop();
                results[Type.ListForeach].Add(stopwatch.ElapsedMilliseconds);

                sum = 0;
                stopwatch.Restart();
                for (int i = 0; i < arrayvals.Length; i++)
                {
                    sum += arrayvals[i];
                }
                stopwatch.Stop();
                results[Type.ArrayFor].Add(stopwatch.ElapsedMilliseconds);

                sum = 0;
                stopwatch.Restart();
                for (int i = 0; i < listvals.Count; i++)
                {
                    sum += listvals[i];
                }
                stopwatch.Stop();
                results[Type.ListFor].Add(stopwatch.ElapsedMilliseconds);
            }

            Console.WriteLine("Array, foreach: {0}", results[Type.ArrayForeach].Average());
            Console.WriteLine("List, foreach: {0}", results[Type.ListForeach].Average());
            Console.WriteLine("Array, for: {0}", results[Type.ArrayFor].Average());
            Console.WriteLine("List, for: {0}", results[Type.ListFor].Average());

            Console.ReadKey();
        }
    }
}