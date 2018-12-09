namespace WebShop.Models
{
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Product")]
    public partial class Product
    {
        WebShopDbContext db = null;
        public Product()
        {
            db = new WebShopDbContext();
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

        public int TakeTotalRecordProductByBrand(int iD)
        {
            var totalRecord = db.Products.Where(x => x.Status == true && x.BrandID== ID && x.Quantity > 0).Count();
            return totalRecord;
        }

        public int TakeTotalRecordProductByCategory(int ID)
        {
            var totalRecord = db.Products.Where(x => x.Status == true && x.CategoryID==ID && x.Quantity > 0).Count();
            return totalRecord;

        }
        public int TakeTotalRecordProductBySearchProduct(string searchString)
        {
            var totalRecord = db.Products.Where(x => x.Status == true && x.Name.Contains(searchString) && x.Quantity > 0).Count();
            return totalRecord;
        }

        // test truy vấn theo cách khác
        /*public String TakeProductName(int InputID)
        {
            string Product_Name = from PN in db.Products
                                 where PN.ID == InputID
                                 select PN.Name;
            return Product_Name;
        }*/

        public int ID { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(300)]
        public string MetaTitle { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public int? BrandID { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int Quantity { get; set; }

        public int? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public int? Warranty { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }

        public bool Status { get; set; }
    }
}
