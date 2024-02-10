namespace HTTP_Client_RestRequest.Models
{
    public class StockUpdate
    {
        public string? StockSymbol { get; set; }
        public string? CurrentPrice { get; set; }
        public string? LowesPrice { get; set; }
        public string? HighestPrice { get; set; }
        public string? OpenPrice { get; set; }
    }
}
