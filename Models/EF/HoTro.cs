namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoTro")]
    public partial class HoTro
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        public int? Type { get; set; }

        [StringLength(50)]
        public string Nick { get; set; }

        public int? Order { get; set; }

        public int? Status { get; set; }
    }
}
