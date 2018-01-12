using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataNetCore
{
    public class HomeController:Controller
    {
        private StoreDbContext _storeDbContext;
        private Random random = new Random();

        public HomeController(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadData(int count)
        {
            
            if (ModelState.IsValid)
            {
                
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                List<Product> products = new List<Product>();
                for (int i=1; i<1000; i++)
                {
                    var product = new Product()
                    {
                        ExpireOn = DateTime.Now.AddYears(1),
                        ManufacturedOn = DateTime.Now.AddDays(10),
                        Name = new string(Enumerable.Repeat(chars, 10)
                            .Select(s => s[random.Next(s.Length)]).ToArray()),
                        UnitPrice = 10.00m
                    };
                    products.Add(product);
                }

                _storeDbContext.Products.AddRange(products);
                await _storeDbContext.SaveChangesAsync();
                return Ok("Loaded");
            }
            else
                return BadRequest("Incorrect count");
        }
    }
}
