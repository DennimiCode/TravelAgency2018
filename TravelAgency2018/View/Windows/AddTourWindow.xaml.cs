using System.Linq;
using System.Windows;
using TravelAgency2018.DataModel;

namespace TravelAgency2018.View.Windows
{
    public partial class AddTourWindow : Window
    {
        public AddTourWindow()
        {
            InitializeComponent();
            HotelsDataGrid.ItemsSource = DataModel.TravelAgencyEntities.GetContext().Hotel
                .Join(
                TravelAgencyEntities.GetContext().Country, 
                hotel => hotel.Country, country => country.Code, (hotel, country) => new
                {
                    Hotel = hotel.Name,
                    Country = country.Name
                }).ToList();
        }
    }
}