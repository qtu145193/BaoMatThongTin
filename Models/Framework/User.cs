namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            ActionDetails = new HashSet<ActionDetail>();
            Orders = new HashSet<Order>();
        }

        [Key]
        public int IDCode { get; set; }

        public int RoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        public int? IDQuestion1 { get; set; }

        [StringLength(10)]
        public string Answer1 { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public bool Follow { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActionDetail> ActionDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual Question1 Question1 { get; set; }

        public virtual Role Role { get; set; }
    }
}
