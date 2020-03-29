using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrier.tools
{
    public static class Application
    {
        public static string Root
        {
            // Root 폴더를 리턴
            get { return AppDomain.CurrentDomain.BaseDirectory; }
            //전체 프로젝트에 2개의 어플리케이션이 들어가있음
            //test는 테스트용 어플리케이션
        } 
    }
}
