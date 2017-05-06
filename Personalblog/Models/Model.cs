using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public string InsertData(string query)
        {
            try
            {
                _unit.Database.ExecuteSqlCommand("insert into student(studentname) values('New Student')");
            }
            catch(Exception e)
            {
                return e.InnerException.Message;
            }
            return "success";
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

        public string GetRequestCountry(HttpRequest request)
        {
            String UserIP = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(UserIP))
            {
                UserIP = request.ServerVariables["REMOTE_ADDR"];
            }
            string url = "http://freegeoip.net/json/" + UserIP.ToString();
            WebClient client = new WebClient();
            string jsonstring = client.DownloadString(url);
            dynamic dynObj = JsonConvert.DeserializeObject(jsonstring);
            return dynObj.country_code;
        }
    }
}