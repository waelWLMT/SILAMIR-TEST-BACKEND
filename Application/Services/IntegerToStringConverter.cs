using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Iterfaces;

namespace Application.Services
{
    public class IntegerToStringConverter : IIntegerToStringConverter
    {
        public string ConvertToString(int number, Dictionary<int, string> Divseurs)
        {
            var result = new StringBuilder();

            foreach (var diviseur in Divseurs)
            {
                if (number % diviseur.Key == 0)
                {
                    result.Append(diviseur.Value);
                }   
            }

            return result.Length > 0
                                   ? result.ToString()
                                   : number.ToString();

        }
    }
}
