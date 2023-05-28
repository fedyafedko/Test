using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
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
        private async void btnExchange_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxExchanges.Text))
            {
                MessageBox.Show("Please enter exchange", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                string exchange = comboBoxExchanges.Text as string;
                var exchanges = await _viewModel.LoadExchangesByIdAsync(exchange);
                Hyperlink hyperlink = new Hyperlink();
                hyperlink.Inlines.Add(exchanges.ExchangeUrl);
                hyperlink.NavigateUri = new Uri(exchanges.ExchangeUrl);
                hyperlink.RequestNavigate += Hyperlink_RequestNavigate;
                var PercentTotalVolume = (exchanges.PercentTotalVolume != null ? Math.Round((decimal)exchanges.PercentTotalVolume, 2).ToString() : "0");
                var VolumeUsd = (exchanges.VolumeUsd != null ? Math.Round((decimal)exchanges.VolumeUsd, 2).ToString() : "0");
                resultExchange.Text = $"Name: {exchanges.Name}\nRank: {exchanges.Rank}\nTotal volume: {PercentTotalVolume} %\nDaily volume: {VolumeUsd} $\nLink: "; resultExchange.Inlines.Add(hyperlink);
            }
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string url = e.Uri.ToString();
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
            e.Handled = true;
        }
        private async void comboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadSimilarCurrenciesAsync();
        }
        private async void comboBoxExchanges_GotFocus(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadSimilarExchangesAsync();
        }

        private void currencyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
