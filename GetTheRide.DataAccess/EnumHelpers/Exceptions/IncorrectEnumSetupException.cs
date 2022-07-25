using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTheRide.DataAccess.EnumHelpers.Exceptions
{
    public class IncorrectEnumSetupException : Exception
    {
        public IncorrectEnumSetupException() { }
        public IncorrectEnumSetupException(string message) : base(message) { }
        public IncorrectEnumSetupException(string message, Exception innerException) : base(message, innerException) { }
    }
}
