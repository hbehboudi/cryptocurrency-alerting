namespace WebSite.Application.Services.Alerts.Queries.GetAlert
{
    public class GetAlertListRequest
    {
        public int Page { get; }

        public int Size { get; }

        public string Owner { get; }

        public GetAlertListRequest(string owner, int page, int size)
        {
            Owner = owner;
            Page = page;
            Size = size;
        }
    }
}
