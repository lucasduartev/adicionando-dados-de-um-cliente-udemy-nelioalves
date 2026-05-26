using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(int quantity, Product price)
        {
            Quantity = quantity;
             Product = price;
        }

        public double SubTotal()
        {
            return Product.Price * Quantity;
        }
    }
}
