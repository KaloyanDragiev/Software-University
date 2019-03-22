namespace SimpleMVC.App.ServiceLayers
{
    using Data;
    using System.Collections.Generic;
    using ViewModels;
    using System.Linq;

    public class RetrieveAllProducts
    {
        public IEnumerable<KnifeViewModel> GetAllKnives(string productName)
        {
            List<KnifeViewModel> knivesVMs = new List<KnifeViewModel>();
            using (var context = new SharpStoreContext())
            {
                var allKnives = context.Knives.Where(k => k.Name.Contains(productName));
                foreach (var knife in allKnives)
                {
                    knivesVMs.Add(new KnifeViewModel
                    {
                        ImageUrl = knife.ImageUrl,
                        Name = knife.Name,
                        Price = knife.Price,
                        Id = knife.Id
                    });
                }
            }
            return knivesVMs;
        }
    }
}