using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace TravelAgency2018.View.Controls
{
    /// <summary>
    /// Interaction logic for TourControl.xaml
    /// </summary>
    public partial class TourControl : UserControl
    {
        private readonly Brush _hotTourBrush = new SolidColorBrush(Color.FromRgb(227, 30, 36));
        public TourControl(string name, string country, string hotels, string ticketsCount, string price, string types, string description)
        {
            InitializeComponent();
            TourNameTextBlock.Text = name;
            TourTypesTextBlock.Text = types == "0" ? $"Категории туров: данные отсутсвуют." : $"Категории туров: {types}";
            CountryTextBlock.Text = $"Страна: {country}";
            HotelsTextBlock.Text = hotels == "0" ? $"Отели: данные отсутсвуют." : $"Отели: {hotels}"; ;
            DescriptionTextBlock.Text = string.IsNullOrWhiteSpace(description) ? $"Описание: данные отсутсвуют." : $"Описание: {description}";
            TicketsCountTextBlock.Text = $"{ticketsCount} Шт.";
            if (Convert.ToInt32(ticketsCount) < 50)
            {
                double numPrice = Convert.ToDouble(price);
                PreviewPriceTextBlock.Text = price;
                PriceTextBlock.Text = $"{numPrice - (numPrice * 0.30)} ₽";
                MainGrid.Background = _hotTourBrush;
                TourBorder.Background = _hotTourBrush;
            }
            else
            {
                PriceTextBlock.Text = $"{price} ₽";
            }
        }
    }
}
