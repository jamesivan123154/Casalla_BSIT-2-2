using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.IO;

namespace GradeManagement
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        // Constructor that reads appsettings.json
        public EmailService()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public void SendEmail(string studentName, string subjectName, double finalGrade, string equivalent)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(
                    _configuration["EmailSettings:FromName"],
                    _configuration["EmailSettings:FromEmail"]
                ));

                // NOTE: In Mailtrap sandbox, this "To" email doesn't matter.
                message.To.Add(new MailboxAddress(studentName, "student@example.com"));
                message.Subject = $"Grade Report: {subjectName}";

                message.Body = new TextPart("plain")
                {
                    Text = $"Hello {studentName},\n\n" +
                           $"Here is your grade report for {subjectName}.\n\n" +
                           $"Final Grade: {finalGrade:F2}%\n" +
                           $"Equivalent: {equivalent}\n\n" +
                           $"Keep up the good work!"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(
                        _configuration["EmailSettings:SmtpHost"],
                        int.Parse(_configuration["EmailSettings:SmtpPort"]),
                        SecureSocketOptions.StartTls
                    );

                    client.Authenticate(
                        _configuration["EmailSettings:Username"],
                        _configuration["EmailSettings:Password"]
                    );

                    client.Send(message);
                    client.Disconnect(true);

                    Console.WriteLine("\n[SYSTEM] Grade report email sent to Mailtrap successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n[SYSTEM ERROR] Failed to send email: " + ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("Details: " + ex.InnerException.Message);
            }
        }
    }
}