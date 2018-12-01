namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Brand")]
    public partial class Brand
    {
        WebShopDbContext db = null;
        public Brand()
        {
            db = new WebShopDbContext();
        }
        //lấy danh sách các thương hiệu để hiển thị trong sitebar
        public List<Brand> TakeBrands()
        {
            return db.Brands.Where(x => x.Status == true).ToList();

        }
        public int ID { get; set; }

        [StringLength(50)]
        public string BrandName { get; set; }

        [StringLength(300)]
        public string MetaTitle { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public bool Status { get; set; }
    }
}
