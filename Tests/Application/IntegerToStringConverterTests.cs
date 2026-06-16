using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;

namespace Tests.Application
{
    public class IntegerToStringConverterTests
    {
        private readonly IntegerToStringConverter _service;
        public IntegerToStringConverterTests()
        {
            _service = new IntegerToStringConverter();
        }

        [Theory]
        [InlineData(7, "7")]
        [InlineData(9, "Fizz")]
        [InlineData(10, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        public void ConvertToString_Should_Return_Expected_Result(int number, string expected)
        {
            // Arrange
            var divisors = new Dictionary<int, string> { { 3, "Fizz" },  { 5, "Buzz" } };

            // Act
            var result = _service.ConvertToString(number, divisors);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
