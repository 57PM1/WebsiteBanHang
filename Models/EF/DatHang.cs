namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatHang")]
    public partial class DatHang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? Khachhang_ID { get; set; }

        public double? TotalMoney { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public int? Status { get; set; }

        public virtual Feedback Feedback { get; set; }
    }
}
