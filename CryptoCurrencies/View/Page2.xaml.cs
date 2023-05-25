using CurrenciesModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using View.UserControls;
using ViewModel;

namespace View
{
    public partial class Page2 : Window
    {
        private CurrencyViewModel _viewModel;
        public Page2()
        {
            InitializeComponent();
            _viewModel = new CurrencyViewModel();
            DataContext = _viewModel;
        }
        private void LoadCurrencies_Click(object sender, RoutedEventArgs e)
        {
            MainWindow page = new MainWindow();
            page.Show();
            this.Close();
        }

        private void LoadSelectedCurrency_Click(object sender, RoutedEventArgs e)
        {
            Page2 page = new Page2();
            page.Show();
        }

        private async void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currencyInput.EnteredText) || string.IsNullOrWhiteSpace(amountInput.EnteredText))
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
                string currency = currencyInput.EnteredText;
                double amount = double.Parse(amountInput.EnteredText);
                var currencies = await _viewModel.LoadCurrencyByIdAsync(currency, amount);
                result.Text = $"{amount} {currencies.Symbol} = {currencies.PriceUSD} USD";
            }
        }
    }
}
