using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class FizzBuzzRequest
    {
        public int Limit { get; set; }
        public Dictionary<int, string> Divisors { get; set; }
    }
}
