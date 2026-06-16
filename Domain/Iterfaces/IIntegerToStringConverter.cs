using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Iterfaces
{
    public interface IIntegerToStringConverter
    {
        public string ConvertToString(int number, Dictionary<int,string> Divseurs);
    }
}
