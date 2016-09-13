using System;

using CategoryTraits.Xunit2;

namespace Invio.Xunit {

    /// <summary>
    /// Indicates the test integrates with other components.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class IntegrationTestAttribute : CategoryTraitAttribute {

        public IntegrationTestAttribute() : base("Integration") { }
    }
}
