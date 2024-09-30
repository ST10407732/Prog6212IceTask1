using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2BIceTask1
{
    public class Product
    {
        public Product(int productId, string name, double price, int quantity, string category, string url)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
            Url = url;
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string Url { get; set; }
    }
}
