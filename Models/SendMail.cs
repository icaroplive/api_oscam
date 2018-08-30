
using System;
using System.Net;
using System.Net.Mail;

namespace webapi.Models
{
    public class SendMail
    {
        public static SmtpResponse Send()
        {
            
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com", // set your SMTP server name here
                Port = 587, // Port 
                EnableSsl = true,
                Credentials = new NetworkCredential("icaroplive@gmail.comm", "@Aa102030")
            };

            using (var message = new MailMessage("icaroplive@gmail.com", "icaropinheiro@live.com")
            {
                Subject = "Subject",
                Body = "Body"
            })
            {
            try {
               smtpClient.Send(message);
               return new SmtpResponse { sucesso=true} ;
               }
               catch (Exception e) {
                   return new SmtpResponse { sucesso=false, retorno= e.Message };
               }
               
            }

        }

    }
}