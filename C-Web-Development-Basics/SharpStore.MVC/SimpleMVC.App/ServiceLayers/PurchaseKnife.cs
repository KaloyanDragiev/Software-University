namespace SimpleMVC.App.ServiceLayers
{
    using System;
    using BindingModels;
    using Data;
    using Models;

    public class PurchaseKnife
    {
        public void BuyKnife(PurchaseBindingModel model)
        {
            using (var context = new SharpStoreContext())
            {
                Purchase purchase = new Purchase
                {
                    Address = model.Address,
                    Name = model.Name,
                    Phone = model.Phone,
                    DeliveryType = (DeliveryType)Enum.Parse(typeof(DeliveryType), model.DeliveryType),
                    KnifeId = model.KnifeId
                };
                context.Purchases.Add(purchase);
                context.SaveChanges();
            }           
        }
    }
}