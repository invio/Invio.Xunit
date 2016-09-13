using System;

using CategoryTraits.Xunit2;

namespace Invio.Xunit {

    /// <summary>
    /// Indicates the test should be testing at the smallest amount
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UnitTestAttribute : CategoryTraitAttribute {

        public UnitTestAttribute() : base("Unit") { }
    }
}
