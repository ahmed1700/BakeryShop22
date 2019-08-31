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
        [BindProperty,EmailAddress,Required(ErrorMessage ="Please Enter a valid Email"),Display(Name ="Your Email Adress")]
        public string OrderEmail { get; set; }
        [BindProperty, Required(ErrorMessage ="Please supply a shpping address"), Display(Name = "Shipping Address")]
        public string OrderShipping { get; set; }
        [BindProperty,Display(Name ="Quantity")]
        public int OrderQuantity { get; set; }
        public async Task OnGetAsync() => Product = await db.Products.FindAsync(Id);

        public async Task<IActionResult> OnPostAsync()
        {
            Product = await db.Products.FindAsync(Id);
            if(ModelState.IsValid)
            {
                var body = $"<p>Thank You , We Recevied Your Order for  {OrderQuantity} of Piceces  of {Product.Name}</p>" +
                    $"<p>Your Addess is : {OrderShipping}</p>" +
                    $"<p>Your Total Price is {OrderQuantity * Product.Price}</p>" +
                    "<p> <b>Your Order Will Delivered Without 60 Minutes </b></p>";
                using (var smtp = new SmtpClient())
                {
                    var googleCredential = new NetworkCredential
                    {
                        UserName = "itsharetest@gmail.com",
                        Password = "ahmed@itshare123"
                    };
                    smtp.Credentials = googleCredential;
                    smtp.Host = "smtp.gmail.com	";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    var message = new MailMessage();
                    message.To.Add(OrderEmail);
                    message.Subject = "ITShare Coffe - New Order";
                    message.Body = body;
                    message.IsBodyHtml = true;
                    message.From = new MailAddress("ahmed@gmail.com");
                    await smtp.SendMailAsync(message);
                }
                return RedirectToPage("OrderSucess");
            }
            return Page();
        }

    }
}