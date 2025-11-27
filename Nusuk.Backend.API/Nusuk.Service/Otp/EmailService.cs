using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Nusuk.Services.Otp
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            // إنشاء رسالة الإيميل
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Nusuk App", _config["EmailSettings:SenderEmail"]));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart("html") { Text = body };

            using var smtp = new SmtpClient();

            try
            {
                // الاتصال بخادم Gmail
                await smtp.ConnectAsync(
                    _config["EmailSettings:SmtpServer"],
                    int.Parse(_config["EmailSettings:Port"]),
                    SecureSocketOptions.StartTls
                );

                // المصادقة باستخدام App Password
                await smtp.AuthenticateAsync(
                    _config["EmailSettings:SenderEmail"],
                    _config["EmailSettings:SenderPassword"]
                );

                // إرسال الرسالة
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                // تسجيل
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
            finally
            {
                await smtp.DisconnectAsync(true);
            }
        }
    }
}