using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Validators;
using Domain.Dtos;

namespace Tests.Application
{
    
    public class FizzBuzzRequestValidatorTests
    {

        [Fact]
        public void Should_Pass_When_Request_Is_Valid()
        {
            // Arrange
            var validator = new FizzBuzzRequestValidator();

            var request = new FizzBuzzRequest { Limit = 15, Divisors = new Dictionary<int, string>{ { 3, "Fizz" }, { 5, "Buzz" } } };

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Fail_When_Limit_Is_Invalid(int limit)
        {
            var validator = new FizzBuzzRequestValidator();

            var request = new FizzBuzzRequest { Limit = limit, Divisors = new Dictionary<int, string>{ { 3, "Fizz" }, { 5, "Buzz" } } };

            var result = validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Limit");
        }



        [Fact]
        public void Should_Fail_When_Divisors_Is_Null()
        {
            var validator = new FizzBuzzRequestValidator();

            var request = new FizzBuzzRequest  {   Limit = 15,   Divisors = null! };

            var result = validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Divisors");
        }


        [Fact]
        public void Should_Fail_When_Divisors_Is_Empty()
        {
            var validator = new FizzBuzzRequestValidator();

            var request = new FizzBuzzRequest  { Limit = 15, Divisors = new Dictionary<int, string>() };

            var result = validator.Validate(request);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void Should_Fail_When_Less_Than_Two_Rules()
        {
            var validator = new FizzBuzzRequestValidator();

            var request = new FizzBuzzRequest { Limit = 15, Divisors = new Dictionary<int, string> { { 3, "Fizz" } } };

            var result = validator.Validate(request);

            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        public void Should_Fail_When_Divisor_Key_Is_Invalid(int key)
        {
            var validator = new FizzBuzzRequestValidator();

            var request = new FizzBuzzRequest { Limit = 15, Divisors = new Dictionary<int, string> { { key, "Fizz" }, { 5, "Buzz" }  }  };

            var result = validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Divisors");
        }
    }
}
