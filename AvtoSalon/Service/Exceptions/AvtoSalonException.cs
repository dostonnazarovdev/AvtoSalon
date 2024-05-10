using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoSalon.Service.Exceptions
{
    public class AvtoSalonException:Exception
    {
        public int statusCode;
        public AvtoSalonException(int code,string message): base(message)
        {
            statusCode=code;
        }
    }
}
