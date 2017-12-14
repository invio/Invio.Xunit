using System;

namespace Invio.Xunit {

    /// <summary>
    ///   Indicates the test is checking for performance benchmarks.
    /// </summary>
    public sealed class BenchmarkTestAttribute : CategoryTraitAttribute {

        public BenchmarkTestAttribute() : base("Benchmark") { }

    }

}
