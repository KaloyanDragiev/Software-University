namespace SimpleMVC.App.ServiceLayers
{
    using Data;
    using Models;
    using ViewModels;

    public class GetDesiredKnife
    {
        public KnifeViewModel GetKnife(int id)
        {
            using (var context = new SharpStoreContext())
            {
                Knife knife = context.Knives.Find(id);
                return new KnifeViewModel
                {
                    Id = knife.Id,
                    ImageUrl = knife.ImageUrl,
                    Name =  knife.Name,
                    Price = knife.Price
                };
            }
        }
    }
}