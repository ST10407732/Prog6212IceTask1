using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2BIceTask1
{
    public class ProductUtil
    {
        public static List<Product> products = new List<Product>();

        public static void Populate()
        {

            products.Clear();

            products.Add(new Product(0, "Jacket", 360.00, 15, "Clothes", "https://p7.hiclipart.com/preview/818/634/469/coca-cola-cherry-fizzy-drinks-diet-coke-coca-cola.jpg"));
            products.Add(new Product(1, "Pencil", 10.00, 150, "Stationary", "https://p7.hiclipart.com/preview/818/634/469/coca-cola-cherry-fizzy-drinks-diet-coke-coca-cola.jpg"));
            products.Add(new Product(2, "Bike", 3600.00, 5, "Sports", "https://p7.hiclipart.com/preview/818/634/469/coca-cola-cherry-fizzy-drinks-diet-coke-coca-cola.jpg"));
            products.Add(new Product(3, "Knife set", 160.00, 55, "Kitchen", "https://p7.hiclipart.com/preview/818/634/469/coca-cola-cherry-fizzy-drinks-diet-coke-coca-cola.jpg"));
            products.Add(new Product(4, "Shoes", 560.00, 11, "Clothes", "https://p7.hiclipart.com/preview/818/634/469/coca-cola-cherry-fizzy-drinks-diet-coke-coca-cola.jpg"));
        }
    }

}
