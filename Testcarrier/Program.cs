using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carrier.tools;
using Carrier.Extension; //우리가 만든 확장 메서드 추가

namespace Testcarrier
{
    class Program
    {
        static void Main(string[] args)
        {
            //확장 메서드를 사용해보자
            string s = "123456789";
            Console.WriteLine("is numeric? : " + s.isnumeric());
            Console.WriteLine("is DateType? : " + s.isDateType());

            /*
            //로그 파일을 생성하여 작업해보자
            LogManager Log = new LogManager("HUR",null);

            Log.WriteLine("Begin Processing........");
            for (int i = 0; i < 10; i++)
            {
                Log.WriteLine("Working......" + i);
                System.Threading.Thread.Sleep(500);
            }
            Log.WriteLine("End Processing..........");

            Console.Write(Application.Root); // 종속성에 라이브러리를 추가하고 using carrier를 포함하여 carrier 클래스의 내의 Root 사용
            Console.WriteLine("Hello World!");
            */

        }
    }
    
}
