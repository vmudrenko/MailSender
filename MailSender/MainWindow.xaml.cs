using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MailSender
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void BtnSend_OnClick(object sender, RoutedEventArgs e)
		{
			var mailSender = new MailAddress(TbFrom.Text, TbFrom.Text);
			var recipient = new MailAddress(TbTo.Text);

			using var message = new MailMessage(mailSender, recipient)
			{
				Subject = TbSubject.Text,
				Body = TbText.Text,
			};

			using (var client = new SmtpClient(TbServerAddress.Text, Convert.ToInt32(TbServerPort.Text)))
			{
				var login = TbLogin.Text;
				var password = TbPassword.SecurePassword;

				client.Credentials = new NetworkCredential(login, password);
				client.EnableSsl = true;
				client.Send(message);
			}

			MessageBox.Show(this, "Письмо отправлено", "Внимание");
		}
	}
}
