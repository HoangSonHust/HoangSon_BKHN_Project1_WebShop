namespace WebShop_Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductColors = new HashSet<ProductColor>();
        }

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

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductColor> ProductColors { get; set; }
    }
}
