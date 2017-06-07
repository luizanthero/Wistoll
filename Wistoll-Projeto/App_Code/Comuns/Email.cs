using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Mail;

/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
	public static string EnviarEmail(string emailDestinatario, string assunto, string corpomsg)
	{

        //Endereço de email do remetente
        MailAddress de = new MailAddress("Wistoll5.0@gmail.com");
        //Endereço de email do destinatário
        MailAddress para = new MailAddress(emailDestinatario);       
        MailMessage mensagem = new MailMessage(de, para);
        mensagem.IsBodyHtml = true;

        //Assunto do email
        mensagem.Subject = assunto;
        //conteudo do emil
        mensagem.Body = corpomsg;
        //Prioridade do Email
        mensagem.Priority = MailPriority.Normal;

        //Crua o objeto que envia o email
        SmtpClient cliente = new SmtpClient();
        //cliente.UseDefaultCredentials = false;

        try
        {
            cliente.Send(mensagem);
            return "Email eviado com sucesso";
        }
        catch (Exception e)
        {
            return "Erro ao enviar email";
        }
	}


    public static string EnviarEmailMassa(string emailDestinatario, string assunto, string corpomsg, List<string>emails)
    {

        //Endereço de email do remetente
        MailAddress de = new MailAddress("Wistoll5.0@gmail.com");
        //Endereço de email do destinatário
        MailAddress para = new MailAddress(emailDestinatario);
        MailMessage mensagem = new MailMessage(de, para);
        mensagem.IsBodyHtml = true;

        //Assunto do email
        mensagem.Subject = assunto;
        //conteudo do emil
        mensagem.Body = corpomsg;
        //Prioridade do Email
        mensagem.Priority = MailPriority.Normal;

        //Foreach
        foreach (string email in emails)
        {
            mensagem.Bcc.Add(email);
        }

        //Crua o objeto que envia o email
        SmtpClient cliente = new SmtpClient();

        try
        {
            cliente.Send(mensagem);
            return "Email eviado com sucesso";
        }
        catch
        {
            return "Erro ao enviar email";
        }
    }

    public static string EnviarEmail(string emailDestinatario, string assunto, string corpomsg, string anexo)
    {

        //Endereço de email do remetente
        MailAddress de = new MailAddress("Wistoll5.0@gmail.com");
        //Endereço de email do destinatário
        MailAddress para = new MailAddress(emailDestinatario);
        MailMessage mensagem = new MailMessage(de, para);
        mensagem.IsBodyHtml = true;

        //Assunto do email
        mensagem.Subject = assunto;
        //conteudo do emil
        mensagem.Body = corpomsg;
        //Prioridade do Email
        mensagem.Priority = MailPriority.Normal;

        Attachment anexar = new Attachment(anexo);
        mensagem.Attachments.Add(anexar);
        //Crua o objeto que envia o email
        SmtpClient cliente = new SmtpClient();


        try
        {
            cliente.Send(mensagem);
            return "Email eviado com sucesso";
        }
        catch
        {
            return "Erro ao enviar email";
        }
    }

}
