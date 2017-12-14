using System;

namespace Invio.Xunit {

    /// <summary>
    ///   Indicates the test is checking for performance benchmarks.
    /// </summary>
    public sealed class BenchmarkTestAttribute : CategoryTraitAttribute {

        /// <summary>
        ///   Instantiates a <see cref="CategoryTraitAttribute" /> with a
        ///   <see cref="CategoryTraitAttribute.Category" /> value of "Benchmark".
        /// </summary>
        public BenchmarkTestAttribute() : base("Benchmark") { }

    }

}
