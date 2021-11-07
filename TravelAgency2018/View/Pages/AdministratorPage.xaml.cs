using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TravelAgency2018.DataModel;
using TravelAgency2018.Utils;
using TravelAgency2018.View.Controls;
using TravelAgency2018.View.Windows;

namespace TravelAgency2018.View.Pages
{
	public partial class AdministratorPage : Page
	{
		private List<TourControl> _filteredTourControls = new List<TourControl>();
		private readonly Regex _numbersOnlyRegex = new Regex(@"[^0-9]+");
		private const byte PageStep = 15;
		private int _currentPagePosition;

		public AdministratorPage()
		{
			InitializeComponent();
			GoBackPageButton.Content = "<-";
			GoForwardPageButton.Content = "->";
			HotelsComboBox.ItemsSource = TravelAgencyEntities.GetContext().Hotel
				.Join(
					TravelAgencyEntities.GetContext().Country,
					h => h.Country,
					c => c.Code,
					(h, c) => new
					{
						h.Name,
						Country = " | " + c.Name
					}).ToList().OrderBy(t => t.Name);

			ResetScrollView();

			var countOfPages = _filteredTourControls.Count / PageStep + 1;
			for (var i = 1; i <= countOfPages; i++)
				CountOfPagesTextBlock.Text += $"{i}.";

			CountOfPagesTextBlock.Text = CountOfPagesTextBlock.Text.Substring(0, CountOfPagesTextBlock.Text.Length - 1);
		}

		private void LogoutButtonOnClick(object sender, RoutedEventArgs e)
		{
			NavigationService?.RemoveBackEntry();
			NavigationService?.Navigate(new AuthorizationPage());
		}

		private void AddNewTourButtonOnClick(object sender, RoutedEventArgs e)
		{
			Window addNewTourWindow = new AddTourWindow();
			addNewTourWindow.Show();
		}

		private void SearchTextBoxOnTextChanged(object sender, TextChangedEventArgs e)
		{
			foreach (var tour in _filteredTourControls)
				if (SearchAlgorithm(tour.Name, SearchTextBox.Text) <= 2)
					_filteredTourControls.Remove(tour);
			UpdateScrollView();
		}

		private void PriceStartsFromTextBoxOnTextChanged(object sender, TextChangedEventArgs e)
		{
			_filteredTourControls = _filteredTourControls
				.Where(t => Convert.ToDecimal(t.PriceTextBlock.Text.Replace('₽', ' ')) >=
				            Convert.ToDecimal(PriceStartsFromTextBox.Text)).ToList();
			UpdateScrollView();
		}

		private void EndPriceTextBoxOnTextChanged(object sender, TextChangedEventArgs e)
		{
			_filteredTourControls = _filteredTourControls
				.Where(t => Convert.ToDecimal(t.PriceTextBlock.Text.Replace('₽', ' ')) <=
				            Convert.ToDecimal(EndPriceTextBox.Text)).ToList();
			UpdateScrollView();
		}

		private void HotelsComboBoxOnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			_filteredTourControls = _filteredTourControls
				.Where(
					t => t.HotelsTextBlock.Text.Contains(HotelsComboBox.SelectedItem.ToString().Split('|')[0].Trim()))
				.ToList();
			UpdateScrollView();
		}

		private void PriceStartsFromTextBoxOnPreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = _numbersOnlyRegex.IsMatch(e.Text);
		}

		private void EndPriceTextBoxOnPreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = _numbersOnlyRegex.IsMatch(e.Text);
		}

		private void GoBackPageButtonOnClick(object sender, RoutedEventArgs e)
		{
			NavigateToPage(false);
		}

		private void GoForwardPageButtonOnClick(object sender, RoutedEventArgs e)
		{
			NavigateToPage(true);
		}

		private void UpdateScrollView()
		{
			_currentPagePosition = 0;
			ToursStackPanel.Children.Clear();
			for (var i = 0; i <= PageStep; i++)
				if (_filteredTourControls.Count != 0)
					ToursStackPanel.Children.Add(_filteredTourControls[i]);
		}

		private void ResetScrollView()
		{
			_filteredTourControls = PreloadTourControls.TourControls;
			_currentPagePosition = 0;
			ToursStackPanel.Children.Clear();
			for (var i = 0; i <= PageStep; i++)
				ToursStackPanel.Children.Add(PreloadTourControls.TourControls[i]);
		}

		public static int SearchAlgorithm(string firstString, string secondString)
		{
			if (firstString == null) throw new ArgumentNullException(nameof(firstString));
			if (secondString == null) throw new ArgumentNullException(nameof(secondString));

			int diff;
			var map = new int[firstString.Length + 1, secondString.Length + 1];
			for (var i = 0; i <= firstString.Length; i++) map[i, 0] = i;
			for (var j = 0; j <= secondString.Length; j++) map[0, j] = j;

			for (var i = 1; i <= firstString.Length; i++)
			for (var j = 1; j <= secondString.Length; j++)
			{
				diff = firstString[i - 1] == secondString[j - 1] ? 0 : 1;

				map[i, j] = Math.Min(Math.Min(map[i - 1, j] + 1, map[i, j - 1] + 1), map[i - 1, j - 1] + diff);
			}

			return map[firstString.Length, secondString.Length];
		}

		private void NavigateToPage(bool isForward)
		{
			ToursStackPanel.Children.Clear();

			if (isForward)
			{
				if (_currentPagePosition + PageStep < _filteredTourControls.Count) _currentPagePosition += PageStep;
				ToursStackPanel.Children.Clear();

				var i = 0;
				foreach (var tourControl in _filteredTourControls.Skip(_currentPagePosition))
				{
					i++;
					if (i <= PageStep) ToursStackPanel.Children.Add(tourControl);
				}
			}
			else
			{
				if (_currentPagePosition > 0) _currentPagePosition -= PageStep;
				ToursStackPanel.Children.Clear();
				var i = 0;
				foreach (var tourControl in _filteredTourControls.Skip(_currentPagePosition))
				{
					i++;
					if (i <= PageStep) ToursStackPanel.Children.Add(tourControl);
				}
			}
		}
	}
}