using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Domain.Dtos;
using Domain.Iterfaces;
using Moq;

namespace Tests.Application
{
    public class FizzBuzzServiceTests
    {
        private readonly Mock<IIntegerToStringConverter> _converterMock;

        public FizzBuzzServiceTests()
        {
            _converterMock = new Mock<IIntegerToStringConverter>();
        }

        [Fact]
        public void GenerateFizzBuzz_Should_Return_Expected_Result()
        {
            // Arrange
            _converterMock
                .Setup(x => x.ConvertToString(It.IsAny<int>(), It.IsAny<Dictionary<int, string>>()))
                .Returns<int, Dictionary<int, string>>((number, _) => number.ToString());

            var service = new FizzBuzzService(_converterMock.Object);
            var request = new FizzBuzzRequest
            {
                Limit = 3,
                Divisors = new Dictionary<int, string>
            {
                { 3, "Fizz" },
                { 5, "Buzz" }
            }
            };

            // Act
            var result = service.GenerateFizzBuzz(request);

            // Assert
            Assert.Equal(new List<string> { "1", "2", "3" }, result);
        }

        [Fact]
        public void GenerateFizzBuzz_Should_Call_Converter_For_Each_Number()
        {

            // Arrange
            _converterMock
                .Setup(x => x.ConvertToString(It.IsAny<int>(), It.IsAny<Dictionary<int, string>>()))
                .Returns("Value");

            var service = new FizzBuzzService(_converterMock.Object);

            var request = new FizzBuzzRequest  {
                Limit = 10,
                Divisors = new Dictionary<int, string> {   { 3, "Fizz" } } };

            // Act
            service.GenerateFizzBuzz(request);

            // Assert
            _converterMock.Verify(
                x => x.ConvertToString(
                    It.IsAny<int>(),
                    It.IsAny<Dictionary<int, string>>()),
                Times.Exactly(10));
        }

        [Fact]
        public void GenerateFizzBuzz_Should_Pass_Correct_Parameters()
        {
            // Arrange
            var divisors = new Dictionary<int, string> { { 3, "Fizz" }, { 5, "Buzz" } };

            var converterMock = new Mock<IIntegerToStringConverter>();

            converterMock
                .Setup(x => x.ConvertToString(It.IsAny<int>(), divisors))
                .Returns("Value");

            var service = new FizzBuzzService(converterMock.Object);

            var request = new FizzBuzzRequest
            {
                Limit = 5,
                Divisors = divisors
            };

            // Act
            service.GenerateFizzBuzz(request);

            // Assert
            converterMock.Verify(x => x.ConvertToString(1, divisors), Times.Once);
            converterMock.Verify(x => x.ConvertToString(5, divisors), Times.Once);
        }

    }
}
