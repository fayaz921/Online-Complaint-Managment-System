using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Web;
using System.Windows.Forms;

namespace OCMS.Helper.Emailservice
{
    public class EmailService
    {

        public bool SendOtp(string toEmail, string otp)
        {
            try
            {
                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("mfayaz21703@gmail.com", "evgd nsde xlkp jryx");

                    using (var mail = new MailMessage("mfayaz21703@gmail.com", toEmail))
                    {
                        mail.Subject = "Your OTP Code";
                        mail.Body = $"Your OTP code is: {otp}";
                        mail.IsBodyHtml = false;

                        client.Send(mail);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
