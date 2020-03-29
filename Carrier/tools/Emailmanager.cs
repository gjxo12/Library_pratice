using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail; // 이걸로 메일 사용가능
using System.Net;
using System.Configuration;

namespace Carrier.tools
{
    public class Emailmanager
    {
        private MailMessage _mailmessage;
        private SmtpClient _smptclient;

        public Emailmanager(string host, int port, string id, string password)
        {
            _smptclient = new SmtpClient(host, port);
            _smptclient.Credentials = new NetworkCredential(id, password);
            // smtp 클라 생성, emial메니저 객체 생성될때 smtp 바로 설정

            _mailmessage = new MailMessage();
            _mailmessage.IsBodyHtml = true;
            _mailmessage.Priority = MailPriority.Normal;
            //메일 메세지 기본값도 바로 설정

        }

        public string From
        {
            get { return _mailmessage.From == null ? string.Empty : _mailmessage.From.Address; }
            set { _mailmessage.From = new MailAddress(value); }
            //string으로 받아서 처리할 경우, emailmanager 객체를 위와같이 사용가능
        }

        public MailAddressCollection To
        {
            get { return _mailmessage.To; }
            //컬렉션이라 get만 정의하면 됨
        }

        public string subject
        {
            get { return _mailmessage.Subject; }
            set { _mailmessage.Subject = value; }
        }
        public string body
        {
            get { return _mailmessage.Body; }
            set { _mailmessage.Body = value; }
        }

        public void send()
        {
            _smptclient.Send(_mailmessage);
        }

        #region static method
        public static void send(string from, string to, string subject, string content,string cc,string bcc)
        {

            if (string.IsNullOrEmpty(from)) throw new ArgumentException("Sender is empty....");
            if (string.IsNullOrEmpty(to)) throw new ArgumentException("To is empty......");
            //from 과 To 대한 예외체크
            


            string smtpHost = ConfigurationManager.AppSettings["SMTPHost"];

            int smtpPort = 0;
            if (ConfigurationManager.AppSettings["SMTPPort"] == null ||
                int.TryParse(ConfigurationManager.AppSettings["SMTPPort"], out smtpPort) == false)
            {
                smtpPort = 25;
            }

            string smtpId = ConfigurationManager.AppSettings["SMTPId"];
            string smtpPw = ConfigurationManager.AppSettings["SMTPPassword"];
            //하드코딩이 아닌 app.config를 통해 읽음 app.config는 실행하는 .Net Framework 프로젝트에 존재 
            

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from); // q보내는 사람
            //mail.To.Add(new MailAddress(to));
            mail.To.Add(to); // 받는 사람, ,로 구분된 string도 가능

            if (!string.IsNullOrEmpty(cc)) mail.CC.Add(cc);
            if (!string.IsNullOrEmpty(bcc)) mail.Bcc.Add(bcc); 
            //cc 와 bcc 처리 (참조, 숨은참조)


            mail.Subject = subject;
            mail.IsBodyHtml = true; // 텍스트인지 HTML인지 
            mail.Body = content;

            mail.Priority = MailPriority.Normal; // 메일의 중요도
            // 위 내용은 메일에 대한 모든 정보에 대한 패키지라 생각


            SmtpClient sc = new SmtpClient(); // 위 패키지를 보내기위해 smtpClient 사용
            sc.Credentials = new NetworkCredential(smtpId, smtpPw);

            //서버정보 (호스트명과 포트번호) 필요
            sc.Host = smtpHost;
            sc.Port = smtpPort;
            sc.Send(mail); // 이렇게 우리가 만든 메일 패키지를 smtp로 보냄

        }

        public static void send(string from,string to, string subject, string content)
        {
            send(from, to, subject, content, null, null);
        }


        public static void send(string to, string subject,string content)
        {
            string sender = ConfigurationManager.AppSettings["SMTPSender"]; //[]로 읽음, appsetting의 key네임에서 value를 읽음
            send(sender, to, subject, content);

            /*
            string smtpHost = "Medium.com";
            int smtpPort = 1234;

            string smtpId = "id";
            string smtpPw = "password";
            // 하드코딩을 통한 값
            */
        }
        #endregion 
    }
}
