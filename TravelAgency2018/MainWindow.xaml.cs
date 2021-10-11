using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TravelAgency2018
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        private const string Slogan = "Путешествуй\r\t по России";
        private static Frame _frame;
        private readonly byte[] _sessionIntervals = new byte [3] { 165, 175, 180 };
        private int _showTime = 0;
        private readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        private readonly Stopwatch _sessionStopwatch = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
            SloganTextBlock.Text = Slogan;
            _frame = MainFrame;
            MainFrame.Navigate(new Pages.AuthorizationPage());

            _sessionStopwatch.Start();
            _dispatcherTimer.Interval = new TimeSpan(0,0,1);
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
                MainWindow._frame.NavigationService.RemoveBackEntry();
                _sessionStopwatch.Reset();
                _sessionStopwatch.Start();
                MainWindow.NavigateTo(new Pages.AuthorizationPage());
                _showTime = 0;
            }
        }

        public static void NavigateTo(Page page)
        {
            if (page != null) 
                _frame.Navigate(page);
            else 
                throw new ArgumentNullException(nameof(page), @"Page not defined");
        }
    }
}
    