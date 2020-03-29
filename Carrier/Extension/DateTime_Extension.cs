using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrier.Extension
{
    public static class DateTime_Extension
    {
        public static DateTime First_month(this DateTime s)
        {
            return new DateTime(s.Year, s.Month, 1); // 그 달의 1일을 리턴
        }
        public static DateTime last_month(this DateTime s)
        {
            return new DateTime(s.Year, s.Month, DateTime.DaysInMonth(s.Year, s.Month));
            //마지막 날짜를 리턴, 마지막 인자의 함수가 해당 연도 월의 마지막 날을 가짐
        }
    }
}

