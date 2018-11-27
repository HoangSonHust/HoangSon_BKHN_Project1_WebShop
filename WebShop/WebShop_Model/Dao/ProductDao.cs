using PagedList;
using System.Collections.Generic;
using System.Linq;
using WebShop_Model.EF;
namespace WebShop_Model.Dao
{
    public class ProductDao
    {
        WebShop_Model_DB db = null;
        public ProductDao()
        {
            db = new WebShop_Model_DB();
        }

        //lấy các tóm tắt sản phẩm để cho vào shop
        public List<Product> TakeProduct()
        {
            var totalRecord = db.Products.Where(x => x.Status == true && x.Quantity > 0).Count();
            var Model = db.Products.Where(x => x.Status == true && x.Quantity > 0).ToList();
            return Model;
        }

        public int TakeTotalRecordProduct()
        {
            var totalRecord = db.Products.Where(x => x.Status == true && x.Quantity > 0).Count();
            return totalRecord;
        }

        public List<Product> TakeProductByBrand(int ID)
        {
            return db.Products.Where(x => x.BrandID == ID && x.Status == true && x.Quantity > 0).ToList();
        }

        public IEnumerable<Product> ListAllPageProductByBrand(int ID, int page, int pageSize)
        {
            return db.Products.Where(x => x.BrandID == ID && x.Status == true && x.Quantity > 0).OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public List<Product> TakeProductByCategory(int ID)
        {
            return db.Products.Where(x => x.CategoryID == ID && x.Status == true && x.Quantity > 0).ToList();
        }
        public List<Product> TakeProductID(int ID)
        {
            return db.Products.Where(x => x.ID == ID && x.Status == true && x.Quantity > 0).ToList();
        }
        public Product TakeSingleProductID(int ID)
        {
            return db.Products.Find(ID);
        }

        public List<Product> SearchProduct(string searchString)
        {
            // var categoryID = db.ProductCategories.Where(x => x.Name== Category);
            return db.Products.Where(x => x.Name.Contains(searchString) && x.Status == true).ToList();
            //return db.Products.Where()
        }


        public void AddView(int id)
        {
            var view = db.Products.SingleOrDefault(i => i.ID == id);
            if (view.ViewCount == null)
            {
                view.ViewCount = 1;
            }
            else
            {
                view.ViewCount++;
            }

            db.SaveChanges();
        }

        public void DecreaseProductQuantity(int id, int quantity)
        {
            var product = db.Products.SingleOrDefault(x => x.ID == id);
            product.Quantity = product.Quantity - quantity;
            db.SaveChanges();
        }

        public int TakeProductQuantity(int id)
        {

            var product = db.Products.SingleOrDefault(x => x.ID == id);
            return product.Quantity;

        }

        // test truy vấn theo cách khác
        /*public String TakeProductName(int InputID)
        {
            string Product_Name = from PN in db.Products
                                 where PN.ID == InputID
                                 select PN.Name;
            return Product_Name;
        }*/
    }
}
