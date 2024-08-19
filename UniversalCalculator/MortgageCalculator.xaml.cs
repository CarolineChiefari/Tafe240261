using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
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
	public sealed partial class MortgageCalculator : Page
	{

		/// <summary>
		/// Calculate Monthly Interest Rate Method
		/// </summary>
		/// <param name="yearlyInterestRate"></param>
		/// <returns></returns>
		public static double calculateMonthlyRate(double yearlyInterestRate)
		{
			double monthlyInterestRate;

			monthlyInterestRate = ((yearlyInterestRate/100)/12);

			return monthlyInterestRate;
		}



		/// <summary>
		/// Calculate Monthly Repayments Method
		/// </summary>
		/// <param name="monthlyInterestRate"></param>
		/// <param name="principalBorrow"></param>
		/// <param name="months"></param>
		/// <returns></returns>
		public static double calculateMonthlyRepayments(double monthlyInterestRate, int principalBorrow, int months, int years)
		{
			double monthlyRepayments;

			monthlyRepayments = (principalBorrow * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, months)) /
				(Math.Pow(1 + monthlyInterestRate, months) - 1);

			return monthlyRepayments;

		}


		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			int principalBorrow;
			int years;
			int months;
			double yearlyInterestRate;


			try
			{
				principalBorrow = int.Parse(principalBorrowTextBox.Text);
			}
			catch (Exception)
			{
				var dialog = new MessageDialog("Incorrect price format. Please enter whole numbers only)");
				await dialog.ShowAsync();
				principalBorrowTextBox.Focus(FocusState.Programmatic);
				return;
			}

			try
			{
				years = int.Parse(yearsTextBox.Text);
			}
			catch (Exception)
			{
				var dialog = new MessageDialog("Incorrect format. Please enter a valid numbers of years)");
				await dialog.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				return;
			}

			try
			{
				months = int.Parse(monthsTextBox.Text);
			}
			catch (Exception)
			{
				var dialog = new MessageDialog("Incorrect format. Please enter a valid numbers of months");
				await dialog.ShowAsync();
				monthsTextBox.Focus(FocusState.Programmatic);
				return;
			}

			try
			{
				yearlyInterestRate = double.Parse(yearsInterestRateTextBox.Text);
			}
			catch (Exception)
			{
				var dialog = new MessageDialog("Incorrect interest format. Please enter a interest rate");
				await dialog.ShowAsync();
				yearsInterestRateTextBox.Focus(FocusState.Programmatic);
				return;
			}

			months = (years*12) + months;

			double monthlyInterestRate = calculateMonthlyRate(yearlyInterestRate);
			monthlyInterestRateTextBox.Text = monthlyInterestRate.ToString("F4") + "%";


			double monthlyRepayment = calculateMonthlyRepayments(monthlyInterestRate, principalBorrow, months, years);
			monthlyRepaymentsTextBox.Text = monthlyRepayment.ToString("C");

		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			return MainPage;
		}
	}
}

