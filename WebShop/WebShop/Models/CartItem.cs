using System;
using System.Collections.Generic;
using WebShop.Models;

namespace WebShop.Models
{
    [Serializable]
    public class CartItem
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }
      


    }
}