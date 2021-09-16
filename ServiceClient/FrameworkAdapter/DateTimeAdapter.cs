using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceClient.FrameworkAdapter
{
    public class DateTimeAdapter : IDateTimeAdapter
    {
        public DateTime Now => DateTime.Now;
    }
}
