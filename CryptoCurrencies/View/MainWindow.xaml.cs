using System;
using System.Collections.Generic;
using System.Linq;
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
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CurrencyViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            CurrencyViewModel currencyViewModel = new CurrencyViewModel();
            viewModel = new CurrencyViewModel();
            DataContext = viewModel;
        }
        private async void LoadCurrencies_Click(object sender, RoutedEventArgs e)
        {
            await viewModel.LoadCurrenciesAsync();
        }

        private async void LoadSelectedCurrency_Click(object sender, RoutedEventArgs e)
        {
            
                string currencyId = "bitcoin";
                double amount = 10;
                await viewModel.LoadCurrencyByIdAsync(currencyId, amount);
            
        }
    }
}
