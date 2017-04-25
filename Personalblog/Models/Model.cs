using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Personalblog
{
    public class Model
    {
        MohansGlobeEntity _unit = new MohansGlobeEntity();

        public ProfileIdentity GetData()
        {
            return _unit.ProfileIdentities.FirstOrDefault();
        }

        public bool SaveContact(Contact contact)
        {
            try
            {
                _unit.Contacts.Add(contact);
                _unit.SaveChanges();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("mohansglobe@gmail.com");
                mail.To.Add("mohanraobala@gmail.com");
                mail.Subject = "Contact from mohansglobe.com";
                mail.Body = "Name:" + contact.Name + " /nSubject:" + contact.Subject + " /nMessage:" + contact.Content;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("mohansglobe", "Mohan@123");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}