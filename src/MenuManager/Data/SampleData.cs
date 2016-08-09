using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using MenuManager.Models;

namespace MenuManager.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }

            if (!context.Categories.Any())
            {

                context.Categories.AddRange(
                   new Category()
                   {
                       Name = "Burgers & Chicken"
                   },

                   new Category()
                   {
                       Name = "Spanish Entrees"
                   },
                   new Category()
                   {
                       Name = "Other Entrees"
                   }
                   );
                context.SaveChanges();

            }

            if (!context.MenuItems.Any())
            {
                context.MenuItems.AddRange(
                new MenuItem()
                {
                    Name = "Cheese Burger",
                    Price = 6.99m,
                    Description = "Description of Cheese Burger",
                    Calories = 600,
                    ImageUrl = "http://media3.giphy.com/media/2aZb4DzJF80NO/giphy.gif",  
                    Category = context.Categories.First(c => c.Name == "Burgers & Chicken")
                },

                new MenuItem()
                {
                    Name = "Crispy Chicken Burger",
                    Price = 5.99m,
                    Description = "Description of Crispy Chicken Burger",
                    Calories = 700,
                    ImageUrl = "http://www.pizzaandgyro.com/wp-content/uploads/2013/11/Crispy-Chicken-Burger.png",
                    Category = context.Categories.First(c => c.Name == "Burgers & Chicken")

                },

                new MenuItem()
                {
                    Name = "Fajita Platter",
                    Price = 9.99m,
                    Description = "Description of Fajita Platter",
                    Calories = 1360,
                    ImageUrl = "http://3.bp.blogspot.com/-xKg9fVIMIMI/UWLxmtBDakI/AAAAAAAAHKM/tWJ0VnLn0BI/s1600/133.JPG",
                    Category = context.Categories.First(c => c.Name == "Spanish Entrees")

                },

                new MenuItem()
                {
                    Name = "Chicken Quesadillas",
                    Price = 6.99m,
                    Description = "Description of Chicken Quesadillas",
                    Calories = 510,
                    ImageUrl = "https://s-media-cache-ak0.pinimg.com/564x/ca/56/26/ca56262b9c059e65fe503b169469c11b.jpg",
                    Category = context.Categories.First(c => c.Name == "Spanish Entrees")
                },

                new MenuItem()
                {
                    Name = "Seekh Kabob roll",
                    Price = 5.99m,
                    Description = "Description of Seekh Kabob roll",
                    Calories = 600,
                    ImageUrl = "https://charcoalwycombe.co.uk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/k/e/kebab-roll.jpg",
                    Category = context.Categories.First(c => c.Name == "Other Entrees")
                },

                new MenuItem()
                {
                    Name = "Chicken Tikka",
                    Price = 4.49m,
                    Description = "Description of Chicken Tikka",
                    Calories = 260,
                    ImageUrl = "http://royalrestauranthouston.com/wp-content/uploads/2013/12/Chicken-Tikka-Leg.jpg",
                    Category = context.Categories.First(c => c.Name == "Other Entrees")
                }
              );
            }

            context.SaveChanges();
        }
    }

}

