namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Page")]
    public partial class Page
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Postdate { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string PageContent { get; set; }
    }
}
