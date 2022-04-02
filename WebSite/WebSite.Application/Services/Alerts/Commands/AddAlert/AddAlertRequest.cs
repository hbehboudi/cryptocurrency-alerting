using System;

namespace WebSite.Application.Services.Alerts.Commands.AddAlert
{
    public class AddAlertRequest
    {
        public long RuleId { get; }

        public double Price { get; }

        public DateTime Time { get; }

        public AddAlertRequest(long ruleId, double price, DateTime time)
        {
            RuleId = ruleId;
            Price = price;
            Time = time;
        }
    }
}
