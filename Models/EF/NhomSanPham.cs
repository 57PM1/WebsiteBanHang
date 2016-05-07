namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomSanPham")]
    public partial class NhomSanPham
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public int? ParentID { get; set; }

        public int? Order { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [StringLength(500)]
        public string Images { get; set; }

        public int? Status { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        public bool ShowOnHome { get; set; }
    }
}
