using System.Collections.Generic;
using System.Linq;
using WebShop_Model.EF;

namespace WebShop_Model.Dao
{
    public class ProductColorDao
    {
        WebShop_Model_DB db = null;
        public ProductColorDao()
        {
            db = new WebShop_Model_DB();

        }

        //lấy màu các sản phẩm
       public List<ProductColor> TakeProductColor(int ID)
        {
            return db.ProductColors.Where(x => x.ProductID == ID).ToList();
        }
      
    }
}
