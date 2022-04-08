namespace WebSite.Application.Services.Rules.Commands.DeleteRule
{
    public class DeleteRuleRequest
    {
        public long Id { get; }

        public string Owner { get; }

        public DeleteRuleRequest(long id, string owner)
        {
            Id = id;
            Owner = owner;
        }
    }
}
