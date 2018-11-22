using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_Model.EF;
namespace WebShop_Model.Dao
{
    public class CategoriesMenuDao
    {
        WebShop_Model_DB db = null;
        public CategoriesMenuDao()
        {
            db = new WebShop_Model_DB();
        }
        //lấy danh mục sản phẩm
        public List<ProductCategory> ListCategoryByStatus(Boolean Status)
        {
            return db.ProductCategories.Where(x => x.Status == Status).ToList();

        }
    }
}
