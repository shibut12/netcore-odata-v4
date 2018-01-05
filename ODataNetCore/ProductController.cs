using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ODataNetCore
{
    public class ProductController:Controller
    {
        private StoreDbContext _storeDbContext;

        public ProductController(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public IActionResult Get()
        {
            return Ok(_storeDbContext.Products.AsQueryable());
        }
    }
}
