namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Images { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyDate { get; set; }

        [StringLength(250)]
        public string ModifyBy { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        [StringLength(50)]
        public string MetaDescription { get; set; }

        public int? Status { get; set; }

        [StringLength(500)]
        public string Tag { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
