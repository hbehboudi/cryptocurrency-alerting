using System;

namespace WebSite.Application.Services.Alerts.Queries.GetAlert
{
    public class ResultGetAlertDto
    {
        public long Id { get; }

        public string RuleName { get; }

        public string Symbol { get; }

        public double Price { get; }

        public DateTime Time { get; }

        public ResultGetAlertDto(long id, string ruleName, string symbol, double price, DateTime time)
        {
            Id = id;
            RuleName = ruleName;
            Symbol = symbol;
            Price = price;
            Time = time;
        }
    }
}
