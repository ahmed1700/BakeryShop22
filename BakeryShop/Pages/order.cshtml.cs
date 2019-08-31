using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.Data;
using BakeryShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;

namespace BakeryShop.Pages
{
    public class orderModel : PageModel
    {
        private BakeryShopContext db;
        public orderModel(BakeryShopContext db) => this.db = db;
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Product Product { get; set; }
        public async Task OnGetAsync() => Product = await db.Products.FindAsync(Id);

    }
}