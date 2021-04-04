namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Weapon")]
    public partial class Weapon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Weapon()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int IDweapon { get; set; }

        public int IDclass { get; set; }

        [Required]
        [StringLength(50)]
        public string NameWea { get; set; }

        public decimal? Price { get; set; }

        [StringLength(8)]
        public string Ammunition { get; set; }

        public double? Reloadtime { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual WeaponClass WeaponClass { get; set; }
    }
}
