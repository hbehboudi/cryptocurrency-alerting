namespace WebSite.Application.Services.Rules.Queries.GetRule
{
    public class GetRuleRequest
    {
        public long Id { get; }

        public string Owner { get; }

        public GetRuleRequest(string owner, long id)
        {
            Owner = owner;
            Id = id;
        }
    }
}
