using CurrenciesModel;
using System.Collections.Generic;
using System.Windows;
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
            currencyDataGrid.ItemsSource = currencies;
        }

        private void LoadSelectedCurrency_Click(object sender, RoutedEventArgs e)
        {
            Page2 page = new Page2();
            page.Show();
            this.Close();
        }
    }
}
