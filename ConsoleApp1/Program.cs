using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carrier.tools;
using Carrier.Extension; //우리가 만든 확장 메서드 추가

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //emailmanager의 객체를 생성하는 방식으로 해보자
            Emailmanager emial = new Emailmanager("sssss.com", 25, "id", "password");
            emial.From = "sender.com";
            emial.To.Add("reciver.com");
            emial.subject = "subjcet";
            emial.body = "content";
            emial.send(); //이렇게하면 메일이 나감
            */
            

            //메일 컨텐츠를 사용해보자... : tools/EmailManager 클래스
            //app.config에 설정된 방식으로 하자 -> static method 부분
            string content = "Hello there <br> this is mail test....";
            Emailmanager.send("reciver@test.com, recevier2@test.com", "Hi test......", content);

            // 클래스 생성자를 보고 다양하게 생성자 호출 가능 -> Emailmanager.send("??","??" "....")

            /*
            //확장 메서드를 사용해보자... : Extension 폴더
            string s = "123456789";
            Console.WriteLine("is numeric? : " + s.isnumeric());
            Console.WriteLine("is DateType? : " + s.isDateType());
            */
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