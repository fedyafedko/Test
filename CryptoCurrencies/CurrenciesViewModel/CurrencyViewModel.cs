using Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel;
public class CurrencyViewModel : INotifyPropertyChanged
{
    private List<Currency> _topCurrencies;
    private Currency _selectedCurrency;
    private List<Exchange> _topExchanges;
    private Exchange _selectedExchanges;
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
        get { return _selectedCurrency; }
        set
        {
            _selectedCurrency = value;
            OnPropertyChanged();
        }
    }
    public List<Exchange> Exchanges
    {
        get { return _topExchanges; }
        set
        {
            _topExchanges = value;
            OnPropertyChanged();
        }
    }

    public Exchange SelectedExchanges
    {
        get { return _selectedExchanges; }
        set
        {
            _selectedExchanges = value;
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
    public async Task<List<string>> LoadSimilarCurrenciesAsync()
    {
        List<Currency> currencies = await LoadCurrenciesAsync();
        var similarNames = currencies.Select(c => c.Id).ToList();
        SimilarNames = similarNames;
        return similarNames;
    }
    public async Task<List<string>> LoadSimilarExchangesAsync()
    {
        List<Exchange> currencies = await LoadExchangesAsync();
        var similarNames = currencies.Select(c => c.ExchangeId).ToList();
        SimilarNames = similarNames;
        return similarNames;
    }

    public async Task<List<Currency>> LoadCurrenciesAsync()
    {
        ResponseModelCurrencies<List<Currency>> currencies = await Service.GetTopCurrencies();
        TopCurrencies = currencies.Data;
        return TopCurrencies;
    }
    public async Task<Currency> LoadCurrencyByIdAsync(string id, double amount)
    {
        Currency currency = await Service.GetByIdCurrencies(id, amount);
        SelectedCurrency = currency;
        return SelectedCurrency;
    }
    public async Task<List<Exchange>> LoadExchangesAsync()
    {
        ResponseModelExchanges<List<Exchange>> exchanges = await Service.GetExchanges();
        Exchanges = exchanges.Data;
        return Exchanges;
    }
    public async Task<Exchange> LoadExchangesByIdAsync(string id)
    {
        Exchange exchanges = await Service.GetByIdExchanges(id);
        SelectedExchanges = exchanges;
        return SelectedExchanges;
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}