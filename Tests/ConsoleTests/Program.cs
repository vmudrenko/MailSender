using System;
using System.Net;
using System.Net.Mail;

namespace ConsoleTests
{
	class Program
	{
		static void Main(string[] args)
		{
			var sender = new MailAddress("", "");
			var recipient = new MailAddress("");

			using var message = new MailMessage(sender, recipient)
			{
				Subject = "Тестовое сообщение",
				Body = $"Текст письма: {DateTime.Now}",
			};
			
			using (var client = new SmtpClient("smtp.mail.ru", 25))
			{
				var login = sender.Address;
				var password = "";

				client.Credentials = new NetworkCredential(login, password);
				client.EnableSsl = true;
				try
				{
					client.Send(message);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					throw;
				}
			}

			Console.WriteLine("Почта отправлена");
			Console.ReadLine();

		}
	}
}
