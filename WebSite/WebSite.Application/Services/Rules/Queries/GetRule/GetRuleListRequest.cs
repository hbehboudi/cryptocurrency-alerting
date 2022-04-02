namespace WebSite.Application.Services.Rules.Queries.GetRule
{
    public class GetRuleListRequest
    {
        public int Page { get; }

        public int Size { get; }

        public string Owner { get; }

        public GetRuleListRequest(string owner, int page, int size)
        {
            Owner = owner;
            Page = page;
            Size = size;
        }
    }
}
