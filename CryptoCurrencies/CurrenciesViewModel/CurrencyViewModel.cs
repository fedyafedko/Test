using CurrenciesModel;
using System.ComponentModel;

namespace ViewModel;
public class CurrencyViewModel : INotifyPropertyChanged
{
    private List<Currency> _topCurrencies;
    public List<Currency> TopCurrencies
    {
        get { return _topCurrencies; }
        set
        {
            _topCurrencies = value;
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
    public async Task<List<Currency>> LoadCurrenciesAsync()
    {
        List<Currency> currencies = await CurrencyService.GetTop();
        TopCurrencies = currencies;
        return TopCurrencies;
    }
    public async Task<Currency> LoadCurrencyByIdAsync(string id, double amount)
    {
        Currency currency = await CurrencyService.GetById(id, amount);
        SelectedCurrency = currency;
        return SelectedCurrency;
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}