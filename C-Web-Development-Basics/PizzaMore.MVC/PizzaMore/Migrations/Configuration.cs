namespace PizzaMore.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PizzaMore.Data.PizzaMoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.PizzaMoreContext context)
        {
            context.Users.AddOrUpdate(u => u.Email, new User[]
            {
                new User
                {
                    Email = "default@g",
                    Password = "123"
                }, 
            });

            context.SaveChanges();

            context.Pizzas.AddOrUpdate(p => p.Title, new Pizza[]
            {
                new Pizza
                {
                    Title = "Alfredo",
                    ImageUrl = "http://assets.kraftfoods.com/recipe_images/opendeploy/120201_640x428.jpg",
                    Recipe = "Preheat the oven to 375 degrees F. Adjust racks to the middle of the oven. Put pizza stone in the oven to preheat while you begin the sauce.\r\n\r\nPreheat a grill pan over medium heat.\r\n\r\nSeason the chicken with salt and pepper, to taste. Put the chicken on the grill pan and grill until cooked through. Remove to a cutting board and dice. Set aside.\r\n\r\nMelt the butter in a medium-sized saucepan over medium heat. Add the garlic and red pepper flakes and cook until fragrant. Add the flour and cook until light blonde in color. Whisk in the cream, reduce the heat to low, and let simmer until thickened, about 2 minutes. Stir in Parmesan and season lightly with salt and pepper, to taste.\r\n\r\nFlour your work surface and roll the pizza dough into a 13-inch diameter. Carefully remove the pizza stone from the oven and put the dough on top. Ladle the sauce to cover the bottom of the pizza. Evenly top with the baby spinach, grape tomatoes, grilled chicken and the mozzarella. Brush the edge of the crust with olive oil and season with salt and pepper, to taste. Bake the pizza until crisp and golden, about 25 minutes. Remove from oven and immediately top with another handful of spinach. Slice and serve.",
                    OwnerId = 1
                }, new Pizza
                {
                    Title = "Carbonara",
                    ImageUrl = "https://image.shutterstock.com/z/stock-photo-pizza-carbonara-with-bacon-and-yolk-of-chicken-egg-52806298.jpg",
                    Recipe = "Unroll pizza crust. Press onto a greased 12-in. pizza pan; build up edges slightly. Prick thoroughly with a fork. Bake at 425° for 7-10 minutes or until lightly browned.\r\nMeanwhile, in a large saucepan, saute onion in butter until tender. Add garlic; cook 1 minute longer. Stir in flour and pepper until blended. Gradually add milk and bouillon. Bring to a boil; cook and stir for 2 minutes or until thickened. Reduce heat; stir in Parmesan cheese. Spread over hot crust. Sprinkle with bacon, Monterey Jack cheese and green onions.\r\nBake at 425° for 8-12 minutes or until cheese is melted. Let stand for 5 minutes before cutting. Yield: 4-6 servings.",
                    OwnerId = 1
                }, new Pizza
                {
                    Title = "Barbecue Chicken",
                    ImageUrl = "http://lh5.ggpht.com/_OaYG005JPDs/S8oAO9WPAGI/AAAAAAAABJI/MK-jneaOx88/s640/BBQ%20Chicken%20Pizza.jpg",
                    Recipe = "One hour before baking the pizzas, start preheating the oven at 500 degrees Coat chicken with 2 tablespoons barbecue sauce.\r\nSet aside in the refrigerator.\r\nPrepare dough into pizza shape.\r\nPrecook if needed.\r\nSpread remainder of barbecue sauce over the surface of the dough.\r\nSpread cheese over the sauce.\r\nSpread chicken over the cheese.\r\nPlace the onion rings over the chicken pieces.\r\nPlace the pizza in the oven (on top of pizza stone if available or on pan).\r\nBake until crust is crispy and cheese is bubbling (8-10 minutes).\r\nRemove pizzas from the oven and sprinkle each with 1/2 of the cilantro.",
                    OwnerId = 1
                },new Pizza
                {
                    Title = "Pineapple",
                    ImageUrl = "https://sparkpeo.hs.llnwd.net/e4/7/1/l719944983.jpg",
                    Recipe = "You want pineapple on your pizza? Seriusly? Just kill it with fire",
                    DownVotes = 9999,
                    OwnerId = 1
                },new Pizza
                {
                    Title = "Pepperoni",
                    ImageUrl = "http://www.silviocicchi.com/pizzachef/wp-content/uploads/2015/02/p41.jpg",
                    Recipe = "1. Spoon tomato-and-basil pasta sauce evenly over crust, leaving a 1-inch border around edges. Top with half of pepperoni slices. Sprinkle with cheese. Top with remaining pepperoni.\r\n\r\n2. Bake pizza at 450° directly on oven rack 11 to 12 minutes or until crust is golden and cheese is melted. Cut into 6 slices. Serve immediately.",
                    OwnerId = 1
                },
            });
        }
    }
}
