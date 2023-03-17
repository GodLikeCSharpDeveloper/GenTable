using BlazorStoreServAppV5.Models.BLogicModel;
using Microsoft.AspNetCore.Components;
using Stripe;
using Stripe.Checkout;

namespace BlazorStoreServAppV5.Repository.StoreLogic.LiqPay;

public class StripeService
{
    private Session session;
    public async Task CreateCheckoutSession(List<ProductModel> products, NavigationManager navigationManager)
    {
        var domain = navigationManager.BaseUri;
        var tempItems = new List<SessionLineItemOptions>();
        foreach (var item in products)
        {
            tempItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = item.Price,
                    Currency = "UAH",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = item.Name,
                    }
                },
                Quantity = 1
            });
        }
        var options = new SessionCreateOptions
        {
            LineItems = tempItems,
            Mode = "payment",
            SuccessUrl = domain+"/success",
            CancelUrl = domain + "/cancel.html",
            
            
        };

        var service = new SessionService();
        session = service.Create(options);
        var response = session.Id;
        navigationManager.NavigateTo(session.Url);

    }
}
   