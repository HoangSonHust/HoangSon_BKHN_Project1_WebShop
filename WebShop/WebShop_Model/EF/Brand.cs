namespace WebShop_Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Brand")]
    public partial class Brand
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string BrandName { get; set; }

        [StringLength(300)]
        public string MetaTitle { get; set; }

        public bool? Status { get; set; }
    }
}
