using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Carrier.tools
{
    public enum LogType { Day,Month}

    public class LogManager
    {
        private string _path;


        #region Constructs
        public LogManager()
            :this(System.IO.Path.Combine(Application.Root, "Log"),LogType.Day,null,null) // 경로가 들어오지 않는 생성자에서 경로가 있는 생성자를 호출
        {
            Console.WriteLine("....................");
            //this._path = System.IO.Path.Combine(Application.Root,"Log");
            //경로가 없을경우 Log파일에 파일을 하나 만들어서 저장하도록, 이부분은 이제 필요가 없다.
            //_settingpath();
        }

        public LogManager(string path, LogType logType,string pre, string post)
        {
            this._path = path;
            _settingpath(logType,pre,post);
        }

        public LogManager(string pre, string post)
            : this(Path.Combine(Application.Root,"Log"),LogType.Day,pre,post)
        {
            //이 생성자는 pre와 post만 받아들이는 생성자 경로는 디폴트, 타입도 디폴트로 사용한다.
            //테스트할때, 이 생성자를 불러보면 이해가능
        }

        #endregion

        #region
        private void _settingpath(LogType type,string pre,string post)
        {// 파일을 만든는데 존재하지 않으면 생성하고 존재하면 추가를 해야함
            string path = String.Empty;
            string name = String.Empty;

            switch (type) // 파일을 만드는데 아래와 같이 경로를 더 추가하여 년도/월/파일 의 경로로 지정하기 위함
            {
                case LogType.Day:
                    path = String.Format(@"{0}/{1}", DateTime.Now.Year, DateTime.Now.ToString("MM"));
                    name = DateTime.Now.ToString("yyyyMMdd");
                    break;
                case LogType.Month:
                    path = String.Format(@"{0}/{1}", DateTime.Now.Year);
                    name = DateTime.Now.ToString("yyyyMM");
                    break;
            }
            Console.WriteLine("합치기 전 파일경로: " + path);
            _path = Path.Combine(_path, path);


            if (!System.IO.Directory.Exists(_path)) System.IO.Directory.CreateDirectory(_path);

            if(string.IsNullOrWhiteSpace(pre) == false)
            {
                name = pre + name;
            }
            if (string.IsNullOrWhiteSpace(post) == false)
            {
                name = name + post;
            }
            name = name + ".txt"; // 

            //string Filename = DateTime.Now.ToString("yyyyMMdd") + ".txt"; //파일 이름 설정- 현재 날자에 txt파일
            _path = Path.Combine(_path, name);
        }

        public void Write(string a)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_path, true)) // 파일을 생성하기 위함 있으면 열기, 
                {//using은 {} 까지고 자동으로 리소스를 해제해준다.
                    Console.WriteLine("!!!!!!!!!!!!!!");
                    writer.Write(a); // a라는 스트링을 기록해줌
                }
            }catch(Exception e)
            {
                Console.WriteLine("예외발생!!!!");
            } 
        }
        public void WriteLine(string a)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_path, true)) // 파일을 생성하기 위함 있으면 열기, 
                {
                    Console.WriteLine("??????");
                    writer.WriteLine(a + DateTime.Now.ToString("yyyymmdd HH:MM:SS\t")); // a라는 스트링을 기록해줌

                }
            }catch(Exception e)
            {
                Console.WriteLine("예외발생?????");
            }
        }

     
        #endregion
    }
}
