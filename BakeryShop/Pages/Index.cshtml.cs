using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.Data;
using BakeryShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BakeryShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BakeryShopContext _db;
        public IndexModel(BakeryShopContext db) => this._db = db;
        public List<Product> Products { get; set; }// = new List<Product>();
        public Product FeaturedProduct { get; set; }
        public async Task OnGetAsync()
        {
            Products = await _db.Products.ToListAsync();
            FeaturedProduct = Products.ElementAt(new Random().Next(Products.Count));
        }
    }
}
