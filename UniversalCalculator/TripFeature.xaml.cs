using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class TripFeature : Page
	{
		public TripFeature()
		{
			this.InitializeComponent();
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}

		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
				double pricePerKilometer = 0.1;

				double startingKilometers = Convert.ToDouble(startingKilometersTextBox.Text);
			    double endingKilometers = Convert.ToDouble(endingKilometersTextBox.Text);

				double pricePerDay = Convert.ToDouble(pricePerDayTextBox.Text);
				int numberofDayHired = Convert.ToInt32(daysHiredTextBox.Text);

				double totaltraveled = endingKilometers - startingKilometers;
				double totaltravelCost = totaltraveled * pricePerKilometer; 

				double totaldayCost = pricePerDay * numberofDayHired;

				double totalAmount = totaldayCost + totaltravelCost;

				amountToPayTextBox.Text = Convert.ToString(totalAmount);
		}

		private void todayButton_Click(object sender, RoutedEventArgs e)
		{
			datePicker.SelectedDate = DateTime.Today;
		}
	}
}
