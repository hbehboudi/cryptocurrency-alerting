namespace WebSite.Application.Services.Rules.Queries.GetRule
{
    public class GetItemRequest
    {
        public long Id { get; }

        public string Owner { get; }

        public GetItemRequest(string owner, long id)
        {
            Owner = owner;
            Id = id;
        }
    }
}
