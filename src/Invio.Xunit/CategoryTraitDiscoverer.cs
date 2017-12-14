using System;
using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Invio.Xunit {

    /// <summary>
    ///   This class discovers all of the test methods and test classes that have
    ///   applied the <see cref="CategoryTraitAttribute" />.
    /// </summary>
    public sealed class CategoryTraitDiscoverer : ITraitDiscoverer {

        /// <summary>
        ///   Gets the name of the category from the <see cref="CategoryTraitAttribute" />.
        /// </summary>
        /// <param name="traitAttribute">
        ///   The <see cref="ITraitAttribute" /> containing the category values.
        /// </param>
        /// <returns>
        ///   The trait values extracted from the <see cref="ITraitAttribute" />.
        /// </returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(
            IAttributeInfo traitAttribute) {

            var categoryName =
                traitAttribute.GetNamedArgument<string>("Category");

            yield return new KeyValuePair<string, string>("Category", categoryName);
        }

    }

}
