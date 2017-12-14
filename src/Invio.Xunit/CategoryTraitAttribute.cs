using System;
using Xunit.Sdk;

namespace Invio.Xunit {

    /// <summary>
    ///   A standard representation of a xUnit trait called "Category" that allows
    ///   developers to create various, statically typed categories to their tests
    ///   classes, such as "Unit", "Integration", or "Benchmark".
    /// </summary>
    [TraitDiscoverer("Invio.Xunit.CategoryTraitDiscoverer", "Invio.Xunit")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public abstract class CategoryTraitAttribute : Attribute, ITraitAttribute {

        /// <summary>
        ///   Gets the value of the Category trait.
        /// </summary>
        public string Category { get; }

        /// <summary>
        ///   Instantiates a new instance of the <see cref="CategoryTraitAttribute"/> class.
        /// </summary>
        /// <param name="category">
        ///   The category of the test (e.g. "Unit", "Integration", or "Benchmark").
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   Thrown when <paramref name="category" /> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   Thrown when <paramref name="category" /> is empty or whitespace.
        /// </exception>
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
