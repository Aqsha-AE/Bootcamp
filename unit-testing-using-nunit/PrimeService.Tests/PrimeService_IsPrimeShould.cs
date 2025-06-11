using NUnit.Framework;

namespace PrimeService.Tests
{
    public class Tests
    {
        private PrimeService _primeService;

        [SetUp]
        public void Setup()
        {
            _primeService = new PrimeService();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void IsPrime_BasicTest()
        {
            // Arrange
            int number = 7;

            // Act
            bool result = _primeService.IsPrime(number);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}