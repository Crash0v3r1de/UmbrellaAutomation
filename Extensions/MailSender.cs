using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UmbrellaAutomation.Extensions
{
    public class MailSender
    {
        public void SendMail(string error)
        {
            using (SmtpClient client = new SmtpClient("<server address>"))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("The Umbrella threat feed automation tool has encountered an error during execution.");
                sb.Append("\n\r");
                sb.Append("\n\r");
                sb.Append("=================================================================================\n\r");
                sb.Append(error+"\n\r");
                sb.Append("=================================================================================");
                MailMessage msg = new MailMessage("<from>","<to>","Threat feed Umbrella Automation Failure",sb.ToString());
                
                

                client.Send(msg);
            }
        }
    }
}
