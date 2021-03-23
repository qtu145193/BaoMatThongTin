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
        [Key]
        public int IDCode { get; set; }

        public int RoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        public DateTime? DateTimeLogin { get; set; }

        public int? IDQuestion1 { get; set; }

        [StringLength(10)]
        public string Answer1 { get; set; }

        public virtual Question1 Question1 { get; set; }

        public virtual Role Role { get; set; }
    }
}
