namespace SimpleMVC.App.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleMVC.App.Data.SharpStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SimpleMVC.App.Data.SharpStoreContext context)
        {
            context.Knives.AddOrUpdate(k => k.Name, 
                new Knife
                {
                    ImageUrl = "http://www.mostluxuriouslist.com/wp-content/uploads/2016/02/Yoshihiro-Miyazaki-Honyaki.jpg",
                    Name = "First Knife",
                    Price = 150
                }, 
                new Knife
                {
                    ImageUrl = "http://japanesechefknives.weebly.com/uploads/5/1/2/6/51264193/__6144457_orig.jpg",
                    Name = "Second Knife",
                    Price = 199.85m
                },
                new Knife
                {
                    ImageUrl = "http://www.stone-wood.com/assets/images/knife-233-2.jpg",
                    Name = "Third Knife",
                    Price = 53.26m
                },
                new Knife
                {
                    ImageUrl = "http://kyoceraadvancedceramics.com/media/wysiwyg/FAQ-level-2-1.jpg",
                    Name = "Ceramic",
                    Price = 88.77m
                },
                new Knife
                {
                    ImageUrl = "https://makeitsharp.net/wp-content/uploads/2015/02/swiss_army_knife.jpeg",
                    Name = "Swiss Army Knife",
                    Price = 35.99m
                });
        }
    }
}