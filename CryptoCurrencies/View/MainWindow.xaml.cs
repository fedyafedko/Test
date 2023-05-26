using CurrenciesModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using ViewModel;

namespace View
{
    public partial class MainWindow : Window
    {
        private CurrencyViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new CurrencyViewModel();
            DataContext = _viewModel;
        }
        private async void LoadCurrencies_Click(object sender, RoutedEventArgs e)
        {
            List<Currency> currencies = await _viewModel.LoadCurrenciesAsync();
            var Top10 = currencies.Where(p => p.Rank <= 10).ToList();
            Top10.ForEach(c => c.Supply = (decimal)(double)c.Supply);
            currencyDataGrid.ItemsSource = Top10;
        }
        private async void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox.Text) || string.IsNullOrWhiteSpace(amountInput.EnteredText))
            {
                MessageBox.Show("Please enter currency and amount", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!double.TryParse(amountInput.EnteredText, out _))
            {
                MessageBox.Show("Enter the correct amount", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                string currency = comboBox.Text as string;
                double amount = double.Parse(amountInput.EnteredText);
                var currencies = await _viewModel.LoadCurrencyByIdAsync(currency, amount);
                result.Text = $"{amount} {currencies.Symbol} = {currencies.PriceUSD} USD";
            }
        }

        private async void comboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadSimilarNamesAsync();
        }

        private void currencyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
