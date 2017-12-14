using System;
using Xunit.Sdk;

namespace Invio.Xunit {

    [TraitDiscoverer("Invio.Xunit.CategoryTraitDiscoverer", "Invio.Xunit")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public abstract class CategoryTraitAttribute : Attribute, ITraitAttribute {

        /// <summary>
        ///   Gets the value of the Category trait.
        /// </summary>
        public string Category { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CategoryTraitAttribute"/> class.
        /// </summary>
        /// <param name="category">
        ///   The category of the test (e.g. "Unit", "Integration", or "Benchmark").
        /// </param>
        protected CategoryTraitAttribute(string category) {
            if (category == null) {
                throw new ArgumentNullException(nameof(category));
            } else if (String.IsNullOrWhiteSpace(category)) {
                throw new ArgumentException(
                    $"The {nameof(category)} cannot be null or whitespace.",
                    nameof(category)
                );
            }

            this.Category = category;
        }

    }

}
