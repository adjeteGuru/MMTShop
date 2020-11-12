using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MMTShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTShopApi.Database
{
    public class SeedData
    {
        //this function is to allow database seeding whenever the database is empty

        public static void EnsureSeedData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MMTShopContext>();
                //check context then execute the seeding if empty through EnsureCreated method
                context.Database.EnsureCreated();

                //check if product has data if yes then return products
                if (context.Products != null && context.Products.Any() || context.Categories != null && context.Categories.Any())

                    return; //DB already beed seeded

                //if it doesn't have data then call GetProducts to return product and save
                var products = GetProducts().ToArray();
                context.Products.AddRange(products);
                context.SaveChanges();

                var categories = GetCategories(context).ToArray();
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }


        }

        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>()
            {
                 new Category
                 {
                     Name="Home"
                 },

                 new Category
                 {
                     Name="Garden"
                 },

                  new Category
                 {
                     Name="Electronics"
                 },

                 new Category
                 {
                     Name="Fitness"
                 },

                 new Category
                 {
                     Name="Toys"
                 },

            };
            return categories;

        }//end category


        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>()
            {
                    new Product
                    {
                    SKU = "1HMCR",
                    Name = "Chair",
                    Description = "wooden dinner table chair",
                    Price = 20,
                    },

                    //new Product
                    //{
                    //SKU = "2GDLM",
                    //Name = "Lawnmower",
                    //Description = "use to cut grass",
                    //Price = 55,
                    //},

                    //new Product
                    //{
                    //SKU = "3ELSA",
                    //Name = "Samsung 55 UHD TV",
                    //Description = "latest 7 series of 4k definition tv",
                    //Price = 395,
                    //},

                    //new Product
                    //{
                    //SKU = "4FSTM",
                    //Name = "Tredmill",
                    //Description = "user friendly runner",
                    //Price = 295,
                    //},

                    //new Product
                    //{
                    //SKU = "5TYIR",
                    //Name = "IRobot",
                    //Description = "motion detect friendly artifitial intelligent robot",
                    //Price = 99,
                    //},
            };

            return products;

        } //end products

        public static List<Category> GetCategories(MMTShopContext db)
        {
            List<Category> categories = new List<Category>()
            {
                new Category
                {
                    Name = "Garden",
                    Products = new List<Product>(db.Products.Take(1))
                }
            };

            return categories;
        }

        //public static List<Product> GetProducts(MMTShopContext db)
        //{
        //    List<Product> products = new List<Product>()
        //    {
        //        new Product
        //        {
        //            Name = "Lawnmower",

        //        }
        //    };

        //    return products;
        //}
    }
}
