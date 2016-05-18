namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
    public partial class LienHe
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Company { get; set; }

        [Column(TypeName = "ntext")]
        public string Address { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [StringLength(500)]
        public string Mail { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
    }
}
