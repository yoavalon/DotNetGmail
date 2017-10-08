using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp10
{
    class Program
    {
        private static void SendMail(string Content)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;       // your gmail address      // your gmail password
                client.Credentials = new NetworkCredential("algoretics@gmail.com", "**password-here**");
                                                                           // to 
                MailMessage mm = new MailMessage("doNotReply@gmail.com", "yoav.alon@walla.co.il", DateTime.Now.ToString(), Content);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            SendMail("19:25");            
            Console.ReadKey();

        }
    }
}
