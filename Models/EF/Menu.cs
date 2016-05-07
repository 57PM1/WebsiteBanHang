namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Text { get; set; }

        [StringLength(500)]
        public string Link { get; set; }

        public int? Order { get; set; }

        public int? TypeID { get; set; }

        public bool? Status { get; set; }

        [StringLength(50)]
        public string Target { get; set; }
    }
}
