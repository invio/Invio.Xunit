using System;

namespace Invio.Xunit {

    /// <summary>
    ///   Indicates the test should be testing at the smallest amount
    /// </summary>
    public sealed class UnitTestAttribute : CategoryTraitAttribute {

        public UnitTestAttribute() : base("Unit") { }

    }

}
