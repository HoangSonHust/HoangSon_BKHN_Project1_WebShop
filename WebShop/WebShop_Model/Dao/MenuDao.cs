using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_Model.EF;
namespace WebShop_Model.Dao
{
    public class MenuDao
    {
        WebShop_Model_DB db = null;
        public MenuDao()
        {
            db = new WebShop_Model_DB();
        }
        //lấy tất cả các mục như trang chủ, tin tức, ...
    public List<Menu> ListByGroupID(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId && x.Status==true).ToList();
        }
    }
}
