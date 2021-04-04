namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WeaponClass")]
    public partial class WeaponClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WeaponClass()
        {
            Weapons = new HashSet<Weapon>();
        }

        [Key]
        public int IDclass { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}
