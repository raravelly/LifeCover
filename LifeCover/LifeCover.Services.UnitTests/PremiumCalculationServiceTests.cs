using System.Collections.Generic;
using NUnit.Framework;

namespace LifeCover.Services.UnitTests
{
    public class Tests
    {
        private PremiumCalculationService sut;
        [SetUp]
        public void Setup()
        {
            sut = new PremiumCalculationService();
        }

        [Test]
        [TestCaseSource(nameof(GetPremiumCalculationScenarios))]
        public void Should_Calculate_Premium(long sumInsured, Occupation occupation, int age, decimal expectedPremium)
        {
            // Arrange - see GetPremiumCalculationScenarios

            // Act
            var result = sut.CalculatePremium(sumInsured, occupation, age);
            Assert.AreEqual(expectedPremium, result);
        }

        public static IEnumerable<TestCaseData> GetPremiumCalculationScenarios()
        {
            yield return new TestCaseData(1, Occupation.Doctor, 1, 0.012m);
            yield return new TestCaseData(1, Occupation.Cleaner, 1, 0.018m);
            yield return new TestCaseData(1, Occupation.Author, 1, 0.015m);
            yield return new TestCaseData(1, Occupation.Farmer, 1, 0.021m);
            yield return new TestCaseData(1, Occupation.Mechanic, 1, 0.021m);
            yield return new TestCaseData(1, Occupation.Florist, 1, 0.018m);
        }
    }
}