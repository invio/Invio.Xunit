using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Invio.Xunit {

    public sealed class CategoryTraitAttributeTests {

        [Fact]
        public void Constructor_NullCategory() {

            // Act

            var exception = Record.Exception(
                () => new PassthroughCategoryTraitAttribute(null)
            );

            // Assert

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\t")]
        public void Constructor_WhiteSpaceCategory(String category) {

            // Act

            var exception = Record.Exception(
                () => new PassthroughCategoryTraitAttribute(category)
            );

            // Assert

            Assert.IsType<ArgumentException>(exception);

            Assert.Equal(
                "The category cannot be null or whitespace." +
                Environment.NewLine + "Parameter name: category",
                exception.Message
            );
        }

        private const string traitName = "Category";

        [Theory]
        [InlineData("UnitTestTrait", "Unit")]
        [InlineData("IntegrationTestTrait", "Integration")]
        [InlineData("BenchmarkTestTrait", "Benchmark")]
        public void ValidCategoryTrait_OnMethod(String methodName, String categoryName) {

            // Arrange

            var method = typeof(ClassUnderTest).GetMethod(methodName);

            // Act

            var traits = TraitHelper.GetTraits(method);

            // Assert

            var trait = Assert.Single(traits);
            AssertCategoryTrait(categoryName, trait);
        }

        [Fact]
        public void NonCategoryTraitAttribute_OnMethod_Ignored() {

            // Arrange

            var method = typeof(ClassUnderTest).GetMethod(nameof(ClassUnderTest.NoTraits));

            // Act

            var traits = TraitHelper.GetTraits(method);

            // Assert

            Assert.Empty(traits);
        }

        [Theory]
        [InlineData(typeof(UnitTests), "Unit")]
        [InlineData(typeof(IntegrationTests), "Integration")]
        [InlineData(typeof(BenchmarkTests), "Benchmark")]
        public void ValidCategoryTrait_OnClass(Type @class, String categoryName) {

            // Act

            var traits = TraitHelper.GetTraits(@class);

            // Assert

            var trait = Assert.Single(traits);
            AssertCategoryTrait(categoryName, trait);
        }

        [Fact]
        public void NonCategoryTraitAttribute_OnClass_Ignored() {

            // Arrange

            var @class = typeof(NonCategoryTests);

            // Act

            var traits = TraitHelper.GetTraits(@class);

            // Assert

            Assert.Empty(traits);
        }

        [Fact]
        public void MultipleValidCategoryTraits_AllAreApplied() {

            // Arrange

            var @class = typeof(MultipleCategoryTests);

            // Act

            var traits = TraitHelper.GetTraits(@class).ToList();

            // Assert

            Assert.Equal(2, traits.Count);

            foreach (var trait in traits) {
                Assert.Equal(traitName, trait.Key);
                Assert.Contains(trait.Value, new [] { "Integration", "Benchmark" });
            }
        }

        class ClassUnderTest {

            [Obsolete]    // Irrelevant attribute
            public void NoTraits() { }

            [UnitTest]
            public void UnitTestTrait() { }

            [IntegrationTest]
            public void IntegrationTestTrait() { }

            [BenchmarkTest]
            public void BenchmarkTestTrait() { }
        }

        [UnitTest]
        class UnitTests {}

        [IntegrationTest]
        class IntegrationTests {}

        [BenchmarkTest]
        class BenchmarkTests {}

        [IntegrationTest, BenchmarkTest]
        class MultipleCategoryTests {}

        [Serializable]
        class NonCategoryTests {}

        private static void AssertCategoryTrait(
            string categoryName,
            KeyValuePair<string, string> trait) {

            Assert.Equal(traitName, trait.Key);
            Assert.Equal(categoryName, trait.Value);
        }

        public class PassthroughCategoryTraitAttribute : CategoryTraitAttribute {

            public PassthroughCategoryTraitAttribute(String category) : base(category) {}

        }

    }

}
