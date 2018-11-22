using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_Model.EF;
namespace WebShop_Model.Dao
{ 

    public class ShopSideBarDao
    {
        WebShop_Model_DB db = null;
        public ShopSideBarDao()
        {
            db = new WebShop_Model_DB();
        }
        //lấy để cho vào sidebar
       
    }
}
