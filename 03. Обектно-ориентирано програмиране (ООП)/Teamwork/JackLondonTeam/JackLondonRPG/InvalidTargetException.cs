using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
    class InvalidTargetException:ApplicationException
    {
        public InvalidTargetException(string message):base(message)
        {
        }

        public InvalidTargetException(string message, Exception exception)
            : base(message, exception)
        {
        }       
    }
}
