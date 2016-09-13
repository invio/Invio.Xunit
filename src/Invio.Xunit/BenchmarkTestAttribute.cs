using System;

using CategoryTraits.Xunit2;

namespace Invio.Xunit {

    /// <summary>
    /// Indicates the test is checking for performance benchmarks.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BenchmarkTestAttribute : CategoryTraitAttribute{
        public BenchmarkTestAttribute() : base("Benchmark") { }
    }
}
