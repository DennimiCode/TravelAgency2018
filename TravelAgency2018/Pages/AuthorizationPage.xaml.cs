using System;
using System.Windows;
using System.Windows.Controls;

namespace TravelAgency2018.Pages
{
    public partial class AuthorizationPage : Page
    {
        private readonly Random _random = new Random();

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

            for (int i = 0; i < 11; i++)
            {
                rndCharType = _random.Next(0, 2);
                if (rndCharType == 0)
                    CaptchaTextBlock.Text += _random.Next(0, 10);
                
                else
                    CaptchaTextBlock.Text += _captchaDictionary[_random.Next(0, 52)];
            }
        }

        private void ReloadCaptchaButtonOnClick(object sender, RoutedEventArgs e) => GetCaptcha();

        private void LoginButtonOnClick(object sender, RoutedEventArgs e) => AuthorizationVerification();

        private void AuthorizationVerification()
        {
            if (CaptchaInputTextBox.Text == CaptchaTextBlock.Text)
            {
                string userLoginDb = "";
                string userPasswordDb = "";

                if (CheckEmptyEntries())
                {
                    if (UserInputLoginTextBox.Text == userLoginDb && UserInputPasswordBox.Password == userPasswordDb)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Не верный логин или пароль!", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        GetCaptcha();
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
            }
        }

        private bool CheckEmptyEntries()
        {
            if (UserInputLoginTextBox.Text != string.Empty || UserInputPasswordBox.Password != string.Empty)
                return true;
            else
                return false;
        }
    }
}