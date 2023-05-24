using CurrenciesModel;
using System.ComponentModel;

namespace ViewModel;
public class CurrencyViewModel : INotifyPropertyChanged
{
    private List<CurrencyModel> topCurrencies;
    public List<CurrencyModel> TopCurrencies
    {
        get { return topCurrencies; }
        set
        {
            topCurrencies = value;
            OnPropertyChanged(nameof(TopCurrencies));
        }
    }
    private CurrencyModel selectedCurrency;
    public CurrencyModel SelectedCurrency
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
        List<CurrencyModel> currencies = await CurrencyService.GetTop();
        TopCurrencies = currencies;
    }
    public async Task LoadCurrencyByIdAsync(string id)
    {
        CurrencyModel currency = await CurrencyService.GetById(id);
        SelectedCurrency = currency;
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}