namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class News
    {
        WebShopDbContext db = null;
        public News()
        {
            db = new WebShopDbContext();
        }
        //lấy tất cả các post để xem reviews
        public List<News> TakePost()
        {
            return db.News.Where(x => x.Status == true).ToList();

        }
        public News TakeContent(int ID)
        {
            return db.News.Find(ID);

        }
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(300)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

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
