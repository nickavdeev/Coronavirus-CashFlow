using CoronavirusCashFlow.Model.Assets;

namespace CoronavirusCashFlow.Controller.StockExchange
{
    public static class StockResult
    {
        public static string GetGoodReport(Stock stock) => $"У {stock.Title} выходят отличные финансовые результаты! Акции прибавляют в цене!";
        public static string GetBadReport(Stock stock) => $"У {stock.Title} выходят плохие финансовые результаты! Акции падают!";
    }
}