using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class WeaponViewModel
    {
        public int IDweapon { get; set; }

        public int IDclass { get; set; }
        [Required]
        public string NameWea { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public string Ammunition { get; set; }
        [Required]
        public double? Reloadtime { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
        [Required]
        public virtual String WeaponClass { get; set; }
    }
}
