namespace FitmoRE.Application.Models.Models;

public class SubscriptionModel
{
    public string SubscriptionId { get; set; }

    public decimal Price { get; set; }

    public string StartDate { get; set; }

    // public string Duration { get; set; }
    public TariffModel TariffModel { get; set; }

    public string ClientId { get; set; }

    public bool? IsActive { get; set; }

    public SubscriptionModel(string subscriptionId, decimal price, string startDate, TariffModel tariffModel, string clientId, bool isActive)
    {
        SubscriptionId = subscriptionId;
        Price = price;
        StartDate = startDate;
        TariffModel = tariffModel;
        ClientId = clientId;
        IsActive = isActive;
    }

    public SubscriptionModel()
    {
        throw new NotImplementedException();
    }
}
