using BakeryShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.Data
{
    public static class ModelBuilderExtenstions
    {
        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {
            Product[] products = {
                new Product
                {
                    Id= 1,
                    Name="Carrot Cake",
                    Description= "Carrot Cake Any Description",
                    ImageName= "carrot_cake.jpg"
                },
                 new Product
                {
                    Id= 2,
                    Name="Lemo Tart",
                    Description= "Lemo Tart Any Description",
                    ImageName= "lemon_tart.jpg"
                },
                  new Product
                {
                    Id= 3,
                    Name="Cup Cakes",
                    Description= "Cup Cakes Any Description",
                    ImageName= "carrot_cake.jpg"
                },
                   new Product
                {
                    Id= 4,
                    Name="ITShare Carrot Cake",
                    Description= "ITShare Carrot Cake Any Description",
                    ImageName= "cupcakes.jpg"
                },
                    new Product
                {
                    Id= 5,
                    Name="Bread",
                    Description= "Bread Any Description",
                    ImageName= "bread.jpg"
                },
                     new Product
                {
                    Id= 6,
                    Name="Chocolate Cake",
                    Description= "Chocolate Cake Any Description",
                    ImageName= "chocolate_cake.jpg"
                },
                           new Product
                {
                    Id= 7,
                    Name="Pear Tart",
                    Description= "Pear Tart Any Description",
                    ImageName= "pear_tart.jpg"
                },
            };
            modelBuilder.Entity<Product>().HasData(products);
            return modelBuilder;
        }
    }
}
