namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Menu")]
    public partial class Menu
    {
        WebShopDbContext db = null;
        public Menu()
        {
            db = new WebShopDbContext();
        }
        //lấy danh mục sản phẩm
        public List<ProductCategory> ListCategoryByStatus(Boolean Status)
        {
            return db.ProductCategories.Where(x => x.Status == Status).ToList();

        }
        public List<Menu> ListByGroupID(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId && x.Status == true).ToList();
        }
    
    public int ID { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(50)]
        public string Target { get; set; }

        public int? TypeID { get; set; }

        public bool Status { get; set; }
    }
}
