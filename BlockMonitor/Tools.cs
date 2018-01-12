using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BlockMonitor
{
    public static class Tools
    {
        public static string HttpPost(string Url, string postData, int timeOut = 5000)
        {
            WebRequest request = WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;
            request.Timeout = timeOut;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }

        public static void SendMail(string to, string from, string subject, string body, int times = 1)
        {
            try
            {
                //邮件发送类 
                using (MailMessage mail = new MailMessage())
                {
                    //是谁发送的邮件 
                    mail.From = new MailAddress("chris@neo.org", from);
                    //发送给谁 
                    mail.To.Add(to);
                    //标题 
                    mail.Subject = subject;
                    //内容编码 
                    mail.BodyEncoding = Encoding.UTF8;
                    //邮件内容 
                    mail.Body = body;
                    //是否HTML形式发送 
                    mail.IsBodyHtml = true;

                    //邮件服务器和端口 
                    using (SmtpClient smtp = new SmtpClient("smtp.office365.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = true;

                        //指定发送方式 
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        //指定登录名和密码 
                        smtp.Credentials = new NetworkCredential("邮箱用户名", "邮箱密码");

                        try
                        {
                            smtp.Send(mail);
                        }
                        catch (SmtpException)
                        {
                            if (times <= 3)
                                SendMail(to, from, subject, body, ++times);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static int GetBlockCount(string node)
        {
            string json;
            try
            {
                json = Tools.HttpPost($"{node}", "{'jsonrpc': '2.0', 'method': 'getblockcount', 'params': [], 'id':   1}");
                return (int)JObject.Parse(json)["result"] - 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public static void SendMail(string msg, string subject)
        {
            foreach (var item in File.ReadAllLines("contact.txt"))
            {
                Tools.SendMail(item, "BlockMonitor", subject, msg);
            }
        }
    }

}
