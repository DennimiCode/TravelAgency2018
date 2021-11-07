using System;
using System.Windows;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Threading;

namespace TravelAgency2018.View.Windows
{
    public partial class LoadingScreenWindow : Window
    {
        private const string Slogan = "Путешествуй\r\t по России";

        public LoadingScreenWindow()
        {
            InitializeComponent();
            SloganTextBlock.Text = Slogan;
        }

        private async void LoadingScreenWindowOnLoaded(object sender, RoutedEventArgs e)
        {
            await this.Dispatcher.InvokeAsync(() =>
            {
                /*Utils.PreloadTourControls.Initialize();
                Utils.PreloadTourControls.CreateControls();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();*/
                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += (o, args) =>
                {
                    Utils.PreloadTourControls.Initialize();
                    Utils.PreloadTourControls.CreateControls();
                };
                worker.RunWorkerCompleted += (o, args) =>
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                };
                worker.RunWorkerAsync();
            }, DispatcherPriority.Background);
        }
        
        /*public static void CreateControls()
        {
            foreach (var tour in _tours)
            {
                string[] hotels = tour.Hotels.Split(',');
                string[] tourTypes = tour.TourTypes.Split(',');

                foreach (var hotel in DataModel.TravelAgencyEntities.GetContext().Hotel)
                {
                    for (int j = 0; j < hotels.Length; j++)
                    {
                        if (hotels[j] == Convert.ToString(hotel.Id))
                        {
                            hotels[j] = $"{hotel.Name}, ";
                        }
                    }
                    hotels[hotels.Length - 1] = hotels.Last().Replace(',', '.');
                    tour.Hotels = string.Join(null, hotels);
                }

                foreach (var tourType in DataModel.TravelAgencyEntities.GetContext().TourType)
                {
                    for (int k = 0; k < tourTypes.Length; k++)
                    {
                        if (tourTypes[k] == Convert.ToString(tourType.Id))
                        {
                            tourTypes[k] = $"{tourType.Name}, ";
                        }
                        tourTypes[tourTypes.Length - 1] = tourTypes.Last().Replace(',', '.');
                        tour.TourTypes = string.Join(null, tourTypes);
                    }
                }
            }
            var tempToursList = _tours.Join(
                DataModel.TravelAgencyEntities.GetContext().Country,
                t => t.Country,
                c => c.Code,
                (t, c) => new
                {
                    Name = t.Name,
                    Hotels = t.Hotels,
                    TicketsCount = t.TicketsCount,
                    Price = t.Price,
                    TourTypes = t.TourTypes,
                    Description = t.Description,
                    Country = c.Name
                }).ToList();
            foreach (var tour in tempToursList)
                TourControls.Add(new View.Controls.TourControl(tour.Name, tour.Country, tour.Hotels,
                    Convert.ToString(tour.TicketsCount), Convert.ToString(tour.Price, CultureInfo.CurrentCulture), tour.TourTypes, tour.Description));
        }*/
    }
}
