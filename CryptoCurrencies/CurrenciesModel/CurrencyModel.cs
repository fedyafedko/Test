namespace ExchangesModel
{
    public class ResponseModelCurrencies<T> where T : class
    {
        public T Data { get; set; }
    }

    public class Currency
    {
        public string Id { get; set; }
        public int Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Supply { get; set; }
        public double PriceUSD { get; set; }
        public double ChangePercent24Hr { get; set; }

    }
}