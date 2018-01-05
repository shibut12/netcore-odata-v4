using System;

namespace ODataNetCore
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime ManufacturedOn { get; set; }
        public DateTime ExpireOn { get; set; }
    }
}
