README
This README provides an overview of the code snippets provided.

Description
The code snippets consist of multiple classes in different namespaces. They appear to be part of a project that involves fetching data from the CoinCap API related to cryptocurrencies and exchanges.

Dependencies
The code relies on the following dependencies:

1.System.Net.Http: Provides HTTP-related functionalities for making requests to web APIs.
2.Newtonsoft.Json: Handles JSON serialization and deserialization.
Namespace: Model
ResponseModelCurrencies<T> Class
1.Generic class that represents a response model for currencies.
2.Contains a property named Data of type T, which can be any class.
Currency Class
1.Represents a cryptocurrency.
2.Contains properties such as Id, Rank, Symbol, Name, Supply, PriceUSD, and ChangePercent24Hr.
Namespace: Model
ResponseModelExchanges<T> Class
1.Generic class that represents a response model for exchanges.
2.Contains a property named Data of type T, which can be any class.
Exchange Class
1.Represents a cryptocurrency exchange.
2.Contains properties such as ExchangeId, Name, Rank, PercentTotalVolume, VolumeUsd, and ExchangeUrl.
Namespace: ViewModel
Service Class
1.Provides methods for fetching data from the CoinCap API related to currencies and exchanges.
2.Contains static methods such as GetTopCurrencies(), GetByIdCurrencies(string id, double amount), GetExchanges(), and GetByIdExchanges(string exchanges).
Namespace: ViewModel
CurrencyViewModel Class
1.Represents the view model for handling currency-related data in the application.
2.Implements the INotifyPropertyChanged interface for property change notifications.
3.Contains properties such as TopCurrencies, SelectedCurrency, Exchanges, SelectedExchanges, and SimilarNames.
4.Provides methods for loading currencies, exchanges, and similar names asynchronously.
Namespace View
1.Main Tab: Displays a list of the top 10 cryptocurrencies by rank. Users can load the currencies by clicking the "Assets" button.
2.Currency Tab: Allows users to convert a specific amount of a selected cryptocurrency to USD. Users can select a currency from the dropdown, enter the amount, and click the "=" button to see the conversion result.
3.Exchanges Tab: Provides information about selected cryptocurrency exchanges. Users can select an exchange from the dropdown and click the "➡️" button to view details such as name, rank, total volume, daily volume, and a link to the exchange's website.
Usage
The provided code snippets demonstrate a structure for fetching currency and exchange data from the CoinCap API. They include classes for modeling the API responses (ResponseModelCurrencies<T> and ResponseModelExchanges<T>) as well as classes for representing the currency and exchange entities (Currency and Exchange).
The CurrencyViewModel class serves as the view model for handling the data related to currencies and exchanges. It provides methods for loading and updating the data asynchronously, as well as properties for storing the retrieved data.
To use the code, you may need to include the required dependencies and make the necessary modifications to integrate it into your project. Additionally, you might need to review and uncomment certain sections of the code that are currently commented out.
