using System.Windows;
using System.Windows.Input;
using TravelAgency2018.Utils;

namespace TravelAgency2018.View.Windows
{
	public partial class MainWindow : Window
	{
		private const string Slogan = "Путешествуй\r\t по России";

		public MainWindow()
		{
			InitializeComponent();
			SloganTextBlock.Text = Slogan;
			WindowTitleLabel.Content = Title;
		}

		private void MainWindowOnLoaded(object sender, RoutedEventArgs e)
		{
			Hide();
			PreloadTourControls.Initialize();
			PreloadTourControls.CreateControls();
			Show();
		}

		private void CloseButtonOnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void ResizeButtonOnClick(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
		}

		private void MinimizeButtonOnClick(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void MainWindowOnMouseDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}
	}
}