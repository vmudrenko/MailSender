using System;
using System.Windows;
using MailSenderWpf;

namespace MailSender
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly MailSenderObj _sender;

		public MainWindow()
		{
			InitializeComponent();
			_sender = new MailSenderObj();
		}

		private void BtnSend_OnClick(object sender, RoutedEventArgs e)
		{
			if (_sender.Send(TbFrom.Text, TbFrom.Text, TbSubject.Text,
				TbText.Text, TbServerAddress.Text, Convert.ToInt32(TbServerPort.Text),
				TbLogin.Text, TbPassword.SecurePassword))
			{
				MessageBox.Show(this, "Письмо отправлено", "Внимание");
			}
		}
	}
}
