using System;
using System.Diagnostics;

namespace SquarzUtilities {
    public static class Benchmark {
        public static TimeSpan Time(int iterations, Action action) {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++) action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}