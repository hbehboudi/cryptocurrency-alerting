namespace WebSite.Application.Services.Rules.Queries.GetRule
{
    public class GetRuleRequest
    {
        public int Page { get; }

        public int Size { get; }

        public string SearchValue { get; }

        public string Owner { get; }

        public GetRuleRequest(string owner, int page, int size, string searchValue)
        {
            Owner = owner;
            Page = page;
            Size = size;
            SearchValue = searchValue;
        }
    }
}
