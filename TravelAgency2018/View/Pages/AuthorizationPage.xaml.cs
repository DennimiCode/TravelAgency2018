using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TravelAgency2018.DataModel;
using TravelAgency2018.Pages;

namespace TravelAgency2018.View.Pages
{
	public partial class AuthorizationPage : Page
	{
		private readonly Random _random = new Random();
		private readonly byte[] _sessionIntervals = new byte[3] {165, 175, 180};
		private int _showTime;
		private readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();
		private readonly Stopwatch _sessionStopwatch = new Stopwatch();

		private readonly char[] _captchaDictionary = new char[52]
		{
			'A', 'B', 'C', 'D',
			'E', 'F', 'G', 'H',
			'I', 'G', 'K', 'L',
			'M', 'N', 'O', 'P',
			'Q', 'R', 'S', 'T',
			'U', 'V', 'W', 'X', 'Y', 'Z',
			'a', 'b', 'c', 'd',
			'e', 'f', 'g', 'h',
			'i', 'g', 'k', 'l',
			'm', 'n', 'o', 'p',
			'q', 'r', 's', 't',
			'u', 'v', 'w', 'x', 'y', 'z'
		};

		public AuthorizationPage()
		{
			InitializeComponent();
			GetCaptcha();
			CaptchaInputTextBox.Text = CaptchaTextBlock.Text;
			_sessionStopwatch.Start();
			_dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
			_dispatcherTimer.Tick += DispatcherTimerOnTick;
			_dispatcherTimer.Start();
		}

		private void DispatcherTimerOnTick(object sender, EventArgs e)
		{
			if (_sessionStopwatch.Elapsed.TotalMinutes >= _sessionIntervals[0] && _showTime == 0)
			{
				MessageBox.Show("До конца сессии осталось 15 мин!", "Внимание",
					MessageBoxButton.OK, MessageBoxImage.Warning);
				_showTime++;
			}
			else if (_sessionStopwatch.Elapsed.TotalMinutes >= _sessionIntervals[1] && _showTime == 1)
			{
				MessageBox.Show("До конца сессии осталось 5 мин!", "Внимание",
					MessageBoxButton.OK, MessageBoxImage.Warning);
				_showTime++;
			}
			else if (_sessionStopwatch.Elapsed.TotalMinutes >= _sessionIntervals[2])
			{
				MessageBox.Show("Сессия завершена!", "Ошибка",
					MessageBoxButton.OK, MessageBoxImage.Error);
				NavigationService?.RemoveBackEntry();
				_sessionStopwatch.Reset();
				_sessionStopwatch.Start();
				NavigationService?.Navigate(new AuthorizationPage());
				_showTime = 0;
			}
		}

		private void GetCaptcha()
		{
			int rndCharType;
			CaptchaTextBlock.Text = string.Empty;
			FirstCaptchaLine.X1 = _random.Next(0, 61);
			FirstCaptchaLine.X2 = _random.Next(100, 251);
			FirstCaptchaLine.Y1 = _random.Next(30, 71);
			FirstCaptchaLine.Y2 = _random.Next(0, 21);

			SecondCaptchaLine.X1 = _random.Next(0, 61);
			SecondCaptchaLine.X2 = _random.Next(100, 251);
			SecondCaptchaLine.Y1 = _random.Next(0, 21);
			SecondCaptchaLine.Y2 = _random.Next(30, 71);

			for (var i = 0; i < 11; i++)
			{
				rndCharType = _random.Next(0, 2);
				if (rndCharType == 0)
					CaptchaTextBlock.Text += _random.Next(0, 10);

				else
					CaptchaTextBlock.Text += _captchaDictionary[_random.Next(0, 52)];
			}
		}

		private void ReloadCaptchaButtonOnClick(object sender, RoutedEventArgs e)
		{
			GetCaptcha();
		}

		private void LoginButtonOnClick(object sender, RoutedEventArgs e)
		{
			AuthorizationVerification();
		}

		private void AuthorizationVerification()
		{
			if (CaptchaInputTextBox.Text == CaptchaTextBlock.Text)
			{
				if (CheckEmptyEntries())
				{
					var athorizationStatus = TravelAgencyEntities.GetContext().User
						.Any(u => u.Login == UserInputLoginTextBox.Text && u.Password == UserInputPasswordBox.Password);

					if (athorizationStatus)
					{
						var userRole = TravelAgencyEntities.GetContext().User
							.Where(u => u.Login == UserInputLoginTextBox.Text &&
							            u.Password == UserInputPasswordBox.Password)
							.Select(u => u.UserRole).First();
						switch (userRole)
						{
							case 1:
								NavigationService?.Navigate(new AdministratorPage());
								break;
							case 2:
								NavigationService?.Navigate(new ManagerPage());
								break;
							case 3:
								NavigationService?.Navigate(new ClientPage());
								break;
						}
					}
					else
					{
						MessageBox.Show("Не верный логин или пароль!", "Ошибка",
							MessageBoxButton.OK, MessageBoxImage.Error);
						GetCaptcha();
						UserInputPasswordBox.Password = string.Empty;
					}
				}
				else
				{
					MessageBox.Show("Все поля должны быть заполнены!", "Ошибка",
						MessageBoxButton.OK, MessageBoxImage.Error);
					GetCaptcha();
				}
			}
			else
			{
				MessageBox.Show("Проверка на робота не пройдена!", "Ошибка",
					MessageBoxButton.OK, MessageBoxImage.Error);
				GetCaptcha();
				CaptchaInputTextBox.Text = string.Empty;
			}
		}

		private bool CheckEmptyEntries() => UserInputLoginTextBox.Text != string.Empty || UserInputPasswordBox.Password != string.Empty;
	}
}