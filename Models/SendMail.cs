
using System;
using System.Net;
using System.Net.Mail;

namespace webapi.Models
{
    public class SendMail
    {
        public static SmtpResponse Send(ConfEmailViewModel conf)
        {
            
            var smtpClient = new SmtpClient
            {
                Host = conf.smtp.endereco, // set your SMTP server name here
                Port = conf.smtp.porta, // Port 
                EnableSsl = true,
                Credentials = new NetworkCredential(conf.revendedor.emailSmtp, conf.revendedor.senha)
            };
            var corpo = conf.ModeloEmail.corpo.Replace("[nome]", conf.cliente.nome);
            corpo = corpo.Replace("[usuario]",conf.cliente.login);
            corpo = corpo.Replace("[senha]",conf.cliente.senha);
            corpo = corpo.Replace("[dataVencimento]", conf.Financeiro.dataVencimento.ToString("dd/MM/yy hh:mm"));
            corpo = corpo.Replace("[servidor]",conf.servidor.urlCam);
            using (var message = new MailMessage(conf.revendedor.emailSmtp, conf.cliente.email)
            {
                IsBodyHtml = true,
                Subject = conf.ModeloEmail.titulo,
                Body = corpo
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