using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace online_Hall_Booking.Models
{
    public class EmailHelper
    {

        public bool SendEmailPasswordReset(string userEmail, string link)
        {
            if (userEmail!=null && link!=null)
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("husnain.umarhayat@gmail.com");
                mailMessage.To.Add(new MailAddress(userEmail));

                mailMessage.Subject = "Password Reset";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = link;
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential("husnain.umarhayat@gmail.com", "husnain660");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mailMessage);
                    
                }
                return true;
            }

            else
            {
                return false;
            }
                

            
            
        }
    }
}
