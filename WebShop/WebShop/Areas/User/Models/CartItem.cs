using System;
using System.Collections.Generic;
using WebShop_Model.EF;

namespace WebShop.Areas.User.Models
{
    [Serializable]
    public class CartItem
    {
        // trong cartItem này hiện nay có các thuộc tính như Product: là 1 đối tượng sản phẩm
        //(đối tượng này mang trong nó các thuộc tính con khác=> ko quan trong)
        public Product Product { set; get; }
        public int Quantity { set; get; }
      


    }
}