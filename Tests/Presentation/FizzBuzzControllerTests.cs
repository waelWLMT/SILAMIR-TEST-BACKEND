using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Iterfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Controllers;

namespace Tests.Presentation
{
    
    public class FizzBuzzControllerTests : IClassFixture<FizzBuzzApiFactory>
    {

        private readonly Mock<IFizzBuzzService> _serviceMock;
        private readonly FizzBuzzController _controller;

        private readonly HttpClient _client;

        public FizzBuzzControllerTests(FizzBuzzApiFactory factory)
        {
            _serviceMock = new Mock<IFizzBuzzService>();
            _controller = new FizzBuzzController(_serviceMock.Object);
            _client = factory.CreateClient();
        }

        [Fact]
        public void GenerateFizzBuzz_Should_Return_Ok_With_Result()
        {
            // Arrange
            var request = new FizzBuzzRequest { Limit = 5, Divisors = new Dictionary<int, string>{ { 3, "Fizz" }, { 5, "Buzz" } } };

            var expectedResult = new List<string>
        {
            "1", "2", "Fizz", "4", "Buzz"
        };

            _serviceMock
                .Setup(s => s.GenerateFizzBuzz(request))
                .Returns(expectedResult);

            // Act
            var result = _controller.GenerateFizzBuzz(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = Assert.IsType<List<string>>(okResult.Value);

            Assert.Equal(expectedResult.Count, value.Count);
            Assert.Equal(expectedResult, value);
        }

        [Fact]
        public async Task Should_Return_OK_When_Request_Is_Sent()
        {
            // Arrange
           var json = GetValidJsonInput();

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/fizzbuzz/generate", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Should_Return_BadRequest_When_Request_Is_Invalid()
        {
            // Arrange → invalid request (limit = 0)
            var json = GetInvalidJsonInput();

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/fizzbuzz/generate", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


       private string GetInvalidJsonInput()
        {           
            return """
        {
            "limit": 0,
            "divisors": {
                "3": "Fizz"
            }
        }
        """;
        }

        private string GetValidJsonInput()
        {
            return """
        {
            "limit": 5,
            "divisors": {
                "3": "Fizz",
                "5": "Buzz"
            }
        }
        """;
        }


    }
}
