namespace WebSite.Application.Services.Rules.Queries.GetRule
{
    public class GetRuleDto
    {
        public long Id { get; }

        public string Owner { get; }

        public string Name { get; }

        public string Symbol { get; }

        public string Description { get; }

        public string Indicator { get; }

        public string MorePriceType { get; }

        public string LessPriceType { get; }

        public int MorePeriod { get; }

        public int LessPeriod { get; }

        public GetRuleDto(long id, string owner, string name, string symbol, string description,
            string indicator, string morePriceType, string lessPriceType, int morePeriod, int lessPeriod)
        {
            Id = id;
            Owner = owner;
            Name = name;
            Symbol = symbol;
            Description = description;
            Indicator = indicator;
            MorePriceType = morePriceType;
            LessPriceType = lessPriceType;
            MorePeriod = morePeriod;
            LessPeriod = lessPeriod;
        }
    }
}
