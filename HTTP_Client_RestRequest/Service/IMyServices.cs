namespace HTTP_Client_RestRequest.Service
{
    public interface IMyServices
    {
        Task<Dictionary<string, object>> getStrockPriceQuote(string stockSymbol);
    }
}