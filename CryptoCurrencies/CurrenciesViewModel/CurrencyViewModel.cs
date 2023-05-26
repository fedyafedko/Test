using CurrenciesModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel;
public class CurrencyViewModel : INotifyPropertyChanged
{
    private List<Currency> _topCurrencies;
    private Currency selectedCurrency;
    private List<string> _similarNames;
    public List<Currency> TopCurrencies
    {
        get { return _topCurrencies; }
        set
        {
            _topCurrencies = value;
            OnPropertyChanged();
        }
    }
    public Currency SelectedCurrency
    {
        get { return selectedCurrency; }
        set
        {
            selectedCurrency = value;
            OnPropertyChanged();
        }
    }
    public List<string> SimilarNames
    {
        get => _similarNames;
        set
        {
            if (value != _similarNames)
            {
                _similarNames = value;
                OnPropertyChanged(); 
            }
        }
    }
    public async Task<List<string>> LoadSimilarNamesAsync()
    {
        List<Currency> currencies = await LoadCurrenciesAsync();
        var similarNames = currencies.Select(c => c.Id).ToList();
        SimilarNames = similarNames;
        return similarNames;
    }
    public async Task<List<Currency>> LoadCurrenciesAsync()
    {
        ResponseModel<List<Currency>> currencies = await CurrencyService.GetTop();
        TopCurrencies = currencies.Data;
        return TopCurrencies;
    }
    public async Task<Currency> LoadCurrencyByIdAsync(string id, double amount)
    {
        Currency currency = await CurrencyService.GetById(id, amount);
        SelectedCurrency = currency;
        return SelectedCurrency;
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}