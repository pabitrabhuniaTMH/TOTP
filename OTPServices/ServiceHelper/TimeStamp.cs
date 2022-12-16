using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPServices.ServiceHelper
{
    public static class TimeStamp
    {
        public static long GetTimeStamp()
        {
            var baseDate = new DateTime(1970, 01, 01);           
            var numberOfSeconds = DateTime.Now.Subtract(baseDate).TotalSeconds;
            return Convert.ToInt64(numberOfSeconds);
        }
        public static long GetTimeStamp(DateTime dateTime)
        {
            var baseDate = new DateTime(1970, 01, 01);
            var numberOfSeconds = dateTime.Subtract(baseDate).TotalSeconds;
            return Convert.ToInt64(numberOfSeconds);
        }
    }
}
