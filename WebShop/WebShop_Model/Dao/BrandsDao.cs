using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_Model.EF;
namespace WebShop_Model.Dao
{
    public class BrandsDao
    {
        WebShop_Model_DB db = null;
        public BrandsDao()
        {
            db = new WebShop_Model_DB();
        }
        //lấy danh sách các thương hiệu để hiển thị trong sitebar
        public List<Brand> TakeBrands()
        {
            return db.Brands.Where(x => x.Status == true).ToList();

        }
    }
}
