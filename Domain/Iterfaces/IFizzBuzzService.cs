using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Iterfaces
{
    public interface IFizzBuzzService
    {
        public List<string> GenerateFizzBuzz(FizzBuzzRequest request);
    }
}
