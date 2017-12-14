using System;

namespace Invio.Xunit {

    /// <summary>
    ///   Indicates the test integrates with other components.
    /// </summary>
    public sealed class IntegrationTestAttribute : CategoryTraitAttribute {

        /// <summary>
        ///   Instantiates a <see cref="CategoryTraitAttribute" /> with a
        ///   <see cref="CategoryTraitAttribute.Category" /> value of "Integration".
        /// </summary>
        public IntegrationTestAttribute() : base("Integration") { }

    }

}
