using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Iterfaces;

namespace Application.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IIntegerToStringConverter _integerToStringConverter;
        public FizzBuzzService(IIntegerToStringConverter integerToStringConverter)
        {
            _integerToStringConverter = integerToStringConverter;
        }
        public List<string> GenerateFizzBuzz(FizzBuzzRequest request)
        {
            var result = new List<string>();
            var limit = request.Limit;
            var diviseurs = request.Divisors;

            for (int i = 1; i <= limit; i++)
            {
                result.Add(_integerToStringConverter.ConvertToString(i, diviseurs));
            }

            return result;

        }
    }
}
