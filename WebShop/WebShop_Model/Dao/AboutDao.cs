using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_Model.EF;
namespace WebShop_Model.Dao
{
    public class AboutDao
    {
        WebShop_Model_DB db = null;
        public AboutDao()
        {
            db = new WebShop_Model_DB();

        }
        //lấy chi tiết post
        public About TakeContent(int ID)
        {
            return db.Abouts.Find(ID);

        }
    }
}
