using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using MailKit.Net.Smtp;

namespace BL
{


    public class EmailMessage
    {
        public MailboxAddress Sender { get; set; }
        public MailboxAddress Reciever { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }

    public class MailSender : IMailSender
    {
        public ILogger<MailSender> _logger;
        public MyLocalSite.NotificationMetadata _notificationMetadata;

        MyLocalSite.NotificationMetadata __notificationMetadata;
        public MailSender( ILogger<MailSender> logger , MyLocalSite.NotificationMetadata noti)
        {
            _logger = logger;
            _notificationMetadata = noti;
        }
            private MimeMessage CreateMimeMessageFromEmailMessage(EmailMessage message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(message.Sender);
            mimeMessage.To.Add(message.Reciever);
            mimeMessage.Subject = message.Subject;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            { Text = message.Content };
            return mimeMessage;
        }
        public bool SendEmail()
        {
            EmailMessage message = new EmailMessage();
            message.Sender = new MailboxAddress("Self", _notificationMetadata.Sender);
            message.Reciever = new MailboxAddress("Self", _notificationMetadata.Reciever);
            message.Subject = "Message by company alert";
            message.Content = ">100000";
            var mimeMessage = CreateMimeMessageFromEmailMessage(message);
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Connect(_notificationMetadata.SmtpServer,
                _notificationMetadata.Port, true);
                smtpClient.Authenticate(_notificationMetadata.UserName,
                _notificationMetadata.Password);
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
            }
            return true;

        }
    }
}
