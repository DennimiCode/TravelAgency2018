using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TravelAgency2018.DataModel;
using TravelAgency2018.View.Controls;

namespace TravelAgency2018.Utils
{
	public sealed class PreloadTourControls
	{
		public static List<TourControl> TourControls { get; } = new List<TourControl>();
		private static readonly List<Tour> Tours = TravelAgencyEntities.GetContext().Tour.ToList();
		private static PreloadTourControls _tourControl;

		public static void Initialize()
		{
			_tourControl = new PreloadTourControls();
		}

		public static void CreateControls()
		{
			foreach (var tour in Tours)
			{
				var hotels = tour.Hotels.Split(',');
				var tourTypes = tour.TourTypes.Split(',');

				foreach (var hotel in TravelAgencyEntities.GetContext().Hotel)
				{
					for (var j = 0; j < hotels.Length; j++)
						if (hotels[j] == Convert.ToString(hotel.Id))
							hotels[j] = $"{hotel.Name}, ";
					hotels[hotels.Length - 1] = hotels.Last().Replace(',', '.');
					tour.Hotels = string.Join(null, hotels);
				}

				foreach (var tourType in TravelAgencyEntities.GetContext().TourType)
					for (var k = 0; k < tourTypes.Length; k++)
					{
						if (tourTypes[k] == Convert.ToString(tourType.Id)) tourTypes[k] = $"{tourType.Name}, ";
						tourTypes[tourTypes.Length - 1] = tourTypes.Last().Replace(',', '.');
						tour.TourTypes = string.Join(null, tourTypes);
					}
			}

			var tempToursList = Tours.Join(
				TravelAgencyEntities.GetContext().Country,
				t => t.Country,
				c => c.Code,
				(t, c) => new
				{
					t.Name,
					t.Hotels,
					t.TicketsCount,
					t.Price,
					t.TourTypes,
					t.Description,
					Country = c.Name
				}).ToList();
			foreach (var tour in tempToursList)
				TourControls.Add(new TourControl(tour.Name, tour.Country, tour.Hotels,
					Convert.ToString(tour.TicketsCount), Convert.ToString(tour.Price, CultureInfo.CurrentCulture),
					tour.TourTypes, tour.Description));
		}
	}
}