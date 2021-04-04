namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDonHang { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSung { get; set; }

        public int? Soluong { get; set; }

        public decimal? Dongia { get; set; }

        public virtual Order Order { get; set; }

        public virtual Weapon Weapon { get; set; }
    }
}
