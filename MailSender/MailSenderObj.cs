using System;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace MailSenderWpf
{
	internal class MailSenderObj
	{
		public bool Send(string from, string to, string subject, string body, string smtpAddress, int smtpPort, string login, SecureString password)
		{
			try
			{
				var mailSender = new MailAddress(from, from);
				var recipient = new MailAddress(to);

				using var message = new MailMessage(mailSender, recipient)
				{
					Subject = subject,
					Body = body,
				};

				using (var client = new SmtpClient(smtpAddress, smtpPort))
				{
					client.Credentials = new NetworkCredential(login, password);
					client.EnableSsl = true;
					client.Send(message);
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}
	}
}
