namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActionDetail")]
    public partial class ActionDetail
    {
        [Key]
        public int IDAc { get; set; }

        public int IDCode { get; set; }

        public int IDAction { get; set; }

        public DateTime? Time { get; set; }

        public virtual Action Action { get; set; }

        public virtual User User { get; set; }
    }
}
