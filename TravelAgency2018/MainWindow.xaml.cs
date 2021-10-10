using System.Windows;
using System.Windows.Controls;

namespace TravelAgency2018
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        private const string Slogan = "Путешествуй\r\t по России";
        private static Frame _frame;

        public MainWindow()
        {
            InitializeComponent();
            SloganTextBlock.Text = Slogan;
            _frame = MainFrame;
            MainFrame.Navigate(new Pages.AuthorizationPage());
        }

        public static void NavigateTo(Page page)
        {
            if (page != null) _frame.Navigate(page);
        }
    }
}
    