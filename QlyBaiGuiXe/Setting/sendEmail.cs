using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.NetworkInformation;

namespace QlyBaiGuiXe.Setting
{
    internal class sendEmail
    {
        
        public static string send(string toEmail)
        {
            if (IsInternetAvailable())
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                MailAddress fromAddress = new MailAddress("1facebook.sieunhan.thanhly@gmail.com", "Quản lý bãi gửi xe");

                mailMessage.From = fromAddress;
                mailMessage.To.Add(toEmail);
                mailMessage.Subject = "Mã khôi khục mật khẩu - Quản lý bãi gửi xe";
                string code = createCODE();
                mailMessage.Body = "Mã khôi phục của bạn là: " + code;

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("1facebook.sieunhan.thanhly", "hvkk ptvs tzzh sgfx");
                smtpClient.EnableSsl = true;

                try
                {
                    smtpClient.Send(mailMessage);
                    return code;
                }
                catch (Exception)
                {
                    throw new Exception("Có lỗi xảy ra trong quá trình gửi gmail. Vui lòng thử lại!");
                }       
            }
            else
            {
                throw new Exception("Vui lòng kiểm tra kết nối Internet và thử lại!");
            }
            
        }
        static bool IsInternetAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
        static string createCODE()
        {
            Random random = new Random();

            // Tạo số ngẫu nhiên từ 0000 đến 9999
            int randomNumber = random.Next(10000);

            // Định dạng số ngẫu nhiên thành chuỗi với độ dài bốn chữ số
            return randomNumber.ToString("D4");
        }
    }
}
