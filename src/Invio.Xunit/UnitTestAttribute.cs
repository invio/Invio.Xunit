using System;

namespace Invio.Xunit {

    /// <summary>
    ///   Indicates the test should be testing a single "unit" of business logic.
    /// </summary>
    public sealed class UnitTestAttribute : CategoryTraitAttribute {

        /// <summary>
        ///   Instantiates a <see cref="CategoryTraitAttribute" /> with a
        ///   <see cref="CategoryTraitAttribute.Category" /> value of "Unit".
        /// </summary>
        public UnitTestAttribute() : base("Unit") { }

    }

}
