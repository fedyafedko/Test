using CurrenciesModel;
using System.ComponentModel;

namespace ViewModel;
public class CurrencyViewModel : INotifyPropertyChanged
{
    private List<Currency> topCurrencies;
    public List<Currency> TopCurrencies
    {
        get { return topCurrencies; }
        set
        {
            topCurrencies = value;
            OnPropertyChanged(nameof(TopCurrencies));
        }
    }
    private Currency selectedCurrency;
    public Currency SelectedCurrency
    {
        get { return selectedCurrency; }
        set
        {
            selectedCurrency = value;
            OnPropertyChanged(nameof(SelectedCurrency));
        }
    }
    public async Task LoadCurrenciesAsync()
    {
        List<Currency> currencies = await CurrencyService.GetTop();
        TopCurrencies = currencies;
    }
    public async Task LoadCurrencyByIdAsync(string id, double amount)
    {
        Currency currency = await CurrencyService.GetById(id, amount);
        SelectedCurrency = currency;
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}