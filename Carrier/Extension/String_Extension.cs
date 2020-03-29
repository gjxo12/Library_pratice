using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrier.Extension
{
    public static class String_Extension // string과 관련된 확장 메서드를 만들거임
    {// static 클래스로 만들어야함
        public static bool isnumeric(this string s) //static 메서드로 선언, 첫 인자는 this 키워드로 확장할 클래스나 타입
        {
            long result;
            return long.TryParse(s, out result);
        }
        public static bool isDateType(this string s)
        {
            if (String.IsNullOrEmpty(s)) return false;
            else
            {
                DateTime result;
                return DateTime.TryParse(s, out result);
            }
        }
    }
}
