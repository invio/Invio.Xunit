using System;
using System.Collections.Generic;
using System.Reflection;

using Xunit;

namespace Invio.Xunit {
    public class CategoryAttributeTests {
        [Theory]
        [InlineData("UnitTestTrait", "Unit")]
        [InlineData("IntegrationTestTrait", "Integration")]
        [InlineData("BenchmarkTestTrait", "Benchmark")]
        public void CheckUnitTestAttribute(String methodName, String categoryName) {
            var currentMethod = typeof(ClassUnderTest).GetMethod(methodName);
            var kvp = new KeyValuePair<String, String>("Category", categoryName);
            var traits = TraitHelper.GetTraits(currentMethod);

            Assert.Contains(kvp, traits);
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
    }
}
