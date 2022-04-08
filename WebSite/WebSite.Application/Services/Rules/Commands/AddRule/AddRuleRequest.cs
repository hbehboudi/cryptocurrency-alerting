namespace WebSite.Application.Services.Rules.Commands.AddRule
{
    public class AddRuleRequest
    {
        public string Name { get; }

        public string Symbol { get; }

        public string Description { get; }

        public string Owner { get; }

        public string Indicator { get; }

        public string MorePriceType { get; }

        public string LessPriceType { get; }

        public int MorePeriod { get; }

        public int LessPeriod { get; }

        public AddRuleRequest(string name, string symbol, string description, string owner,
            string indicator, string morePriceType, string lessPriceType, int morePeriod, int lessPeriod)
        {
            Name = name;
            Symbol = symbol;
            Description = description;
            Owner = owner;
            Indicator = indicator;
            MorePriceType = morePriceType;
            LessPriceType = lessPriceType;
            MorePeriod = morePeriod;
            LessPeriod = lessPeriod;
        }
    }
}
