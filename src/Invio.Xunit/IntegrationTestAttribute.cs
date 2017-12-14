using System;

namespace Invio.Xunit {

    /// <summary>
    ///   Indicates the test integrates with other components.
    /// </summary>
    public sealed class IntegrationTestAttribute : CategoryTraitAttribute {

        public IntegrationTestAttribute() : base("Integration") { }
    }

}
